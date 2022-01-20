﻿using System.Collections.Generic;

namespace InputStateSystem
{
    public class InputStateManager : IInputStateManager
    {
        private readonly List<IState> _handlers;
        private IState _target;
        private IState _locker;
        private bool _targetMode;

        public InputStateManager()
        {
            this._handlers = new List<IState>();
            this._locker = new LockState();
        }
        
        public void PushHandler(IState handler, bool isTarget = false)
        {
            if (isTarget)
            {
                this._targetMode = true;
                this._target = handler;
            }

            if (!this._handlers.Contains(handler))
                this._handlers.Add(handler);
        }

        public void PopHandler(IState handler)
        {
            this._handlers.Remove(handler);
            if (this._target == handler)
                this.ResetLock();
        }
        
        public void Update()
        {
            if (this._targetMode)
                this.UpdateTargetState();
            else
                this.UpdateIdleState();
        }

        private void UpdateIdleState()
        {
            if (_handlers.Count <= 0)
                return;

            foreach (var handler in _handlers)
            {
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
                this._target.OnTargetUpdate();
            else
                this.ResetLock();
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