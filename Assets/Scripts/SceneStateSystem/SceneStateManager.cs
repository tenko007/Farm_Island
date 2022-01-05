using System.Collections.Generic;
using SceneStateSystem.Handlers;
using UnityEngine;

namespace SceneStateSystem
{
    public class SceneStateManager : MonoBehaviour, ISceneStateManager
    {
        private readonly List<ISceneState> _handlers;
        private ISceneState _target;
        private ISceneState _locker;
        private bool _targetMode;

        public SceneStateManager()
        {
            this._handlers = new List<ISceneState>();
            this._locker = new LockSceneState();
        }

        private void Start()
        {
            PushHandler(new DummySceneState());
            PushHandler(new InputSceneState());
            PushHandler(new RotateSceneState());
            PushHandler(new ScaleSceneState());
        }

        public void PushHandler(ISceneState handler, bool isTarget = false)
        {
            if (isTarget)
            {
                this._targetMode = true;
                this._target = handler;
            }

            if (!this._handlers.Contains(handler))
            {
                this._handlers.Add(handler);
            }
        }

        public void PopHandler(ISceneState handler)
        {
            this._handlers.Remove(handler);
            if (this._target == handler)
            {
                this.ResetLock();
            }
        }
        
        public void Update()
        {
            if (this._targetMode)
            {
                this.UpdateTargetState();
            }
            else
            {
                this.UpdateIdleState();
            }
        }

        private void UpdateIdleState()
        {
            if (_handlers.Count <= 0)
            {
                return;
            }

            for (int i = 0, count = _handlers.Count; i < count; i++)
            {
                var handler = this._handlers[i];
                if (handler.RequestTarget)
                {
                    _targetMode = true;
                    _target = handler;
                    _target.OnTargetUpdate();
                    break;
                }
                handler.OnIdleUpdate();
            }
        }

        private void UpdateTargetState()
        {
            if (this._target.RequestTarget)
            {
                this._target.OnTargetUpdate();
            }
            else
            {
                this.ResetLock();
            }
        }

        private void ResetLock()
        {
            this._targetMode = false;
            this._target = null;
        }

        public void LockInput()
        {
            PushHandler(_locker, isTarget: true);
        }

        public void UnlockInput()
        {
            PopHandler(_locker);
        }

    }
}