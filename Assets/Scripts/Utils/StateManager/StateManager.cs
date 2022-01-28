using System.Collections.Generic;

namespace InputStateSystem
{
    public abstract class StateManager : IStateManager
    {
        private readonly List<IState> _handlers;
        private IState _target;
        private bool _targetMode;

        public StateManager()
        {
            this._handlers = new List<IState>();
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
    }
}