using InputSystem;
using PlayerMovementSystem;
using UnityEngine;

namespace SceneStateSystem.Handlers
{
    public sealed class RotateAndScaleSceneState : ISceneState
    {
        private IInputSystem _inputSystem = GameManager.Instance.InputSystem;
        private IPlayerMovement _playerMovement = GameManager.Instance.PlayerMovement;

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