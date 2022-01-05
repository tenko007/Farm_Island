using InputSystem;
using PlayerMovementSystem;
using UnityEngine;

namespace SceneStateSystem.Handlers
{
    public sealed class InputSceneState : ISceneState
    {
        private IInputSystem _inputSystem = GameManager.Instance.InputSystem;
        private IPlayerMovement _playerMovement = GameManager.Instance.PlayerMovement;
        private Vector3 _prevMousePosition;
        private const float MIN_MOUSE_DISTANCE = 1.0f;

        public bool RequestTarget { get; private set; }
        public void OnIdleUpdate()
        {
            if (_inputSystem.ClickStart())// || _inputSystem.IsRotating() || _inputSystem.IsScaling())
            {
                _prevMousePosition = _inputSystem.GetMousePosition();
                this.RequestTarget = true;

                return;
            }
        }

        public void OnTargetUpdate()
        {
            if (!_inputSystem.IsDragging())// && !_inputSystem.IsRotating() && !_inputSystem.IsScaling())
            {
                RequestTarget = false;
            }
            else
            {
                Debug.Log($"Mouse position: {_inputSystem.GetMousePosition().ToString()}");
                
                Vector3 currentMousePosition = _inputSystem.GetMousePosition();
                _playerMovement.Move(_prevMousePosition - currentMousePosition);

                _prevMousePosition = currentMousePosition;
            }
        }
        
        private bool isDrag()
        {
            return Vector3.Distance(_inputSystem.GetMousePosition(), this._prevMousePosition) >= MIN_MOUSE_DISTANCE;
        }
    }
}