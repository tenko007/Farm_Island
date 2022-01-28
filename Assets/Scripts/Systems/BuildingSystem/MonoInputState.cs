using CameraMovementSystem;
using InputSystem;
using Systems.InputStateSystem.Handlers;
using UnityEngine;
using Utils.Services;

namespace InputStateSystem
{
    public class MonoBuildingState : MonoBehaviour
    {
        private InputStateManager inputStateManager;

        private void Start()
        {
            inputStateManager = new InputStateManager();
            
            IInputSystem inputSystem = Services.GetService<IInputSystem>();
            ICameraMovement cameraMovement = Services.GetService<ICameraMovement>();
            
            inputStateManager.PushHandler(new IdleInputState());
            inputStateManager.PushHandler(new MoveInputState(inputSystem, cameraMovement));
            inputStateManager.PushHandler(new RotateAndScaleInputState(inputSystem, cameraMovement));
            
            Services.RegisterService<IInputStateManager>(inputStateManager);
        }

        private void Update()
        {
            inputStateManager.Update();
        }
    }
}