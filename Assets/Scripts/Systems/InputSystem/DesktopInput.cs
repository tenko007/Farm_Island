using UnityEngine;

namespace InputSystem
{
    public class DesktopInput : IInputSystem
    {
        public bool ClickStart()
        {
            return Input.GetMouseButtonDown(0);
        }

        public bool ClickEnd()
        {
            return Input.GetMouseButtonUp(0);
        }

        public bool IsDragging()
        {
            return Input.GetMouseButton(0);
        }
        public bool IsScaling()
        {
            return (Input.GetAxis("Mouse ScrollWheel") != 0);
        }

        public float GetScalingValue()
        {
            return Input.GetAxis("Mouse ScrollWheel");
        }

        public bool IsRotating()
        {
            return (Input.GetMouseButton(2));
        }

        public float GetRotatingValue()
        {
            if (Input.GetMouseButton(2)) // Middle Mouse Button
                return Input.GetAxis("Mouse Y") * 500f;
            return 0f;
        }

        public Vector3 GetMousePosition()
        {
            return Input.mousePosition;
        }
    }
}
