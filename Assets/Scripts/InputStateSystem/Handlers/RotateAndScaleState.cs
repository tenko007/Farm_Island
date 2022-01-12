using InputSystem;
using PlayerMovementSystem;
using Utils.Services;

namespace InputStateSystem
{
    public sealed class RotateAndScaleState : IState
    {
        private IInputSystem _inputSystem;
        private IPlayerMovement _playerMovement;

        public RotateAndScaleState(IInputSystem inputSystem, IPlayerMovement playerMovement)
        {
            this._inputSystem = inputSystem;
            this._playerMovement = playerMovement;
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
                _playerMovement.Rotate((_inputSystem.GetRotatingValue()));
                _playerMovement.Scale((_inputSystem.GetScalingValue()));
            }
        }
    }
}