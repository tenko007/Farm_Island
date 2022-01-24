using InputStateSystem;
using InputSystem;
using CameraMovementSystem;
using UnityEngine;

namespace Systems.InputStateSystem.Handlers
{
    public sealed class MoveInputState : IState
    {
        private IInputSystem _inputSystem;
        private ICameraMovement _cameraMovement;
        private Vector3 _prevMousePosition;

        public MoveInputState(IInputSystem inputSystem, ICameraMovement cameraMovement)
        {
            this._inputSystem = inputSystem;
            this._cameraMovement = cameraMovement;
        }
        public bool RequestTarget { get; private set; }
        public void OnIdleUpdate()
        {
            if (_inputSystem.IsDragging())// && !EventSystem.current.IsPointerOverGameObject())
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
                Vector3 currentMousePosition = _inputSystem.GetMousePosition();
                _cameraMovement.Move(_prevMousePosition - currentMousePosition);

                _prevMousePosition = currentMousePosition;
            }
        }
        
    }
}