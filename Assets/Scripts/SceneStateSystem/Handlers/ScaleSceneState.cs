using InputSystem;
using PlayerMovementSystem;
using UnityEngine;

namespace SceneStateSystem.Handlers
{
    public sealed class ScaleSceneState : ISceneState
    {
        private IInputSystem _inputSystem = GameManager.Instance.InputSystem;
        private IPlayerMovement _playerMovement = GameManager.Instance.PlayerMovement;

        public bool RequestTarget { get; private set; }
        public void OnIdleUpdate()
        {
            if (_inputSystem.IsScaling())
            {
                this.RequestTarget = true;
            }
        }

        public void OnTargetUpdate()
        {
            if (!_inputSystem.IsScaling())
            {
                RequestTarget = false;
            }
            else
            {
                Debug.Log($"Scale value: {_inputSystem.GetScalingValue().ToString()}");

                _playerMovement.Scale(_inputSystem.GetScalingValue());
            }
        }
    }
}