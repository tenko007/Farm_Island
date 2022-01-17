using UnityEngine;
using Utils.Services;

namespace CameraMovementSystem
{
    public interface ICameraMovement : IService
    {
        void Move(Vector3 direction);
        void Rotate(float angle);
        void Scale(float scaleValue);
    }
}