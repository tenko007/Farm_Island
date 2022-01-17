using InputStateSystem;
using InputSystem;
using CameraMovementSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Systems.InputStateSystem.Handlers
{
    public sealed class MoveState : IState
    {
        private IInputSystem _inputSystem;
        private ICameraMovement cameraMovement;
        private Vector3 _prevMousePosition;

        public MoveState(IInputSystem inputSystem, ICameraMovement cameraMovement)
        {
            this._inputSystem = inputSystem;
            this.cameraMovement = cameraMovement;
        }
        public bool RequestTarget { get; private set; }
        public void OnIdleUpdate()
        {
            if (_inputSystem.IsDragging() && !EventSystem.current.IsPointerOverGameObject())
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
                cameraMovement.Move(_prevMousePosition - currentMousePosition);

                _prevMousePosition = currentMousePosition;
            }
        }
        
    }
}