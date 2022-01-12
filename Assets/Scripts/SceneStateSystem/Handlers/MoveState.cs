using InputSystem;
using PlayerMovementSystem;
using UnityEngine;

namespace SceneStateSystem.Handlers
{
    public sealed class MoveState : IState
    {
        private IInputSystem _inputSystem = GameManager.Instance.InputSystem;
        private IPlayerMovement _playerMovement = GameManager.Instance.PlayerMovement;
        private Vector3 _prevMousePosition;

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