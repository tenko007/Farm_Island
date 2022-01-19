using CameraMovementSystem;
using InputSystem;
using Systems.InputStateSystem.Handlers;
using UnityEngine;
using Utils.Services;

namespace InputStateSystem
{
    public class MonoInputState : MonoBehaviour
    {
        private InputStateManager inputStateManager;

        private void Start()
        {
            inputStateManager = new InputStateManager();
            
            IInputSystem inputSystem = Services.GetService<IInputSystem>();
            ICameraMovement cameraMovement = Services.GetService<ICameraMovement>();
            
            inputStateManager.PushHandler(new IdleState());
            inputStateManager.PushHandler(new MoveState(inputSystem, cameraMovement));
            inputStateManager.PushHandler(new RotateAndScaleState(inputSystem, cameraMovement));
            
            Services.RegisterService<InputStateManager>(inputStateManager);
        }

        private void Update()
        {
            inputStateManager.Update();
        }
    }
}