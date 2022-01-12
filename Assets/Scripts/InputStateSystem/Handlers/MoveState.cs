using InputSystem;
using PlayerMovementSystem;
using UnityEngine;
using Utils.Services;

namespace InputStateSystem
{
    public sealed class MoveState : IState
    {
        private IInputSystem _inputSystem;
        private IPlayerMovement _playerMovement;
        private Vector3 _prevMousePosition;

        public MoveState(IInputSystem inputSystem, IPlayerMovement playerMovement)
        {
            this._inputSystem = inputSystem;
            this._playerMovement = playerMovement;
        }
        public bool RequestTarget { get; private set; }
        public void OnIdleUpdate()
        {
            if (_inputSystem.IsDragging())
            {
                _prevMousePosition = _inputSystem.GetMousePosition();
                this.RequestTarget = true;
            }
        }

        public void OnTargetUpdate()
        {
            if (!_inputSystem.IsDragging())
            {
                RequestTarget = false;
            }
            else
            {
                Debug.Log($"Mouse position = {_inputSystem.GetMousePosition().ToString()}");
                
                Vector3 currentMousePosition = _inputSystem.GetMousePosition();
                _playerMovement.Move(_prevMousePosition - currentMousePosition);

                _prevMousePosition = currentMousePosition;
            }
        }
        
    }
}