using InputSystem;
using PlayerMovementSystem;
using UnityEngine;

namespace SceneStateSystem.Handlers
{
    public sealed class RotateSceneState : ISceneState
    {
        private IInputSystem _inputSystem = GameManager.Instance.InputSystem;
        private IPlayerMovement _playerMovement = GameManager.Instance.PlayerMovement;

        public bool RequestTarget { get; private set; }
        public void OnIdleUpdate()
        {
            if (_inputSystem.IsRotating())
            {
                this.RequestTarget = true;
            }
        }
        public void OnTargetUpdate()
        {
            if (!_inputSystem.IsRotating())
            {
                RequestTarget = false;
            }
            else
            {                
                Debug.Log($"Rotating value: {_inputSystem.GetRotatingValue().ToString()}");

                _playerMovement.Rotate((_inputSystem.GetRotatingValue()));
            }
        }
    }
}