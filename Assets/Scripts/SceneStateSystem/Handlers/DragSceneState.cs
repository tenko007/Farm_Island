using UnityEngine;

namespace SceneStateSystem.Handlers
{
    public sealed class DragSceneState : ISceneState
    {
        private const int LEFT_MOUSE_BUTTON = 0;
        private const float MIN_MOUSE_DISTANCE = 1.0f;
        private Vector3 startMousePosition;
        
        public bool RequestTarget { get; private set; }
        public void OnIdleUpdate()
        {
            if (UnityEngine.Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
            {
                startMousePosition = UnityEngine.Input.mousePosition;
                return;
            }

            if (UnityEngine.Input.GetMouseButton(LEFT_MOUSE_BUTTON) && this.isDrag())
            {
                this.RequestTarget = true;
            }
        }

        public void OnTargetUpdate()
        {
            if (UnityEngine.Input.GetMouseButtonUp(LEFT_MOUSE_BUTTON))
            {
                RequestTarget = false;
            }
            else
            {
                Debug.Log($"Mouse position: {UnityEngine.Input.mousePosition.ToString()}");
            }
        }

        private bool isDrag()
        {
            return Vector3.Distance(UnityEngine.Input.mousePosition, this.startMousePosition) >= MIN_MOUSE_DISTANCE;
        }
    }
}