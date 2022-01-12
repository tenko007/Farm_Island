using UnityEngine;
using Utils.Services;

namespace InputSystem
{
    public interface IInputSystem : IService
    {
        bool ClickStart();
        bool ClickEnd();
        bool IsDragging();
        bool IsScaling();
        float GetScalingValue();
        bool IsRotating();
        float GetRotatingValue();
        Vector3 GetMousePosition();
    }
}