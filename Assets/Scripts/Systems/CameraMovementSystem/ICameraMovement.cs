using UnityEngine;

namespace CameraMovementSystem
{
    public interface ICameraMovement
    {
        void Move(Vector3 direction);
        void Rotate(float angle);
        void Scale(float scaleValue);
    }
}