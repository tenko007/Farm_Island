using UnityEngine;

namespace PlayerMovementSystem
{
    public interface IPlayerMovement
    {
        void Move(Vector3 direction);
        void Rotate(float angle);
        void Scale(float ScaleValue);
    }
}