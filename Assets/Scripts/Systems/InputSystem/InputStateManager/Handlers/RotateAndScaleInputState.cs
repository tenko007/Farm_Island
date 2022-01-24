using InputSystem;
using CameraMovementSystem;

namespace InputStateSystem
{
    public sealed class RotateAndScaleInputState : IState
    {
        private IInputSystem _inputSystem;
        private ICameraMovement _cameraMovement;

        public RotateAndScaleInputState(IInputSystem inputSystem, ICameraMovement cameraMovement)
        {
            this._inputSystem = inputSystem;
            this._cameraMovement = cameraMovement;
        }
        public bool RequestTarget { get; private set; }
        public void OnIdleUpdate()
        {
            if (_inputSystem.IsRotating() || _inputSystem.IsScaling())
            {
                this.RequestTarget = true;
            }
        }
        public void OnTargetUpdate()
        {
            if (!_inputSystem.IsRotating() && !_inputSystem.IsScaling())
            {
                RequestTarget = false;
            }
            else
            {                
                _cameraMovement.Rotate((_inputSystem.GetRotatingValue()));
                _cameraMovement.Scale((_inputSystem.GetScalingValue()));
            }
        }
    }
}