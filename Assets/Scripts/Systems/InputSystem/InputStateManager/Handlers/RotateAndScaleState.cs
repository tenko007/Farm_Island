using InputSystem;
using CameraMovementSystem;

namespace InputStateSystem
{
    public sealed class RotateAndScaleState : IState
    {
        private IInputSystem _inputSystem;
        private ICameraMovement cameraMovement;

        public RotateAndScaleState(IInputSystem inputSystem, ICameraMovement cameraMovement)
        {
            this._inputSystem = inputSystem;
            this.cameraMovement = cameraMovement;
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
                cameraMovement.Rotate((_inputSystem.GetRotatingValue()));
                cameraMovement.Scale((_inputSystem.GetScalingValue()));
            }
        }
    }
}