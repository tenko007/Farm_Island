using UnityEngine;
using Utils.Services;

namespace PlayerMovementSystem
{
    public interface IPlayerMovement : IService
    {
        void Move(Vector3 direction);
        void Rotate(float angle);
        void Scale(float scaleValue);
    }
}