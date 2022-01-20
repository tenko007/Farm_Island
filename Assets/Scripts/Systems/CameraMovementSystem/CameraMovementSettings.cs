using UnityEngine;

namespace CameraMovementSystem
{
    [CreateAssetMenu (menuName = "ScriptableObjects/Settings/CameraMovementSettings")]
    public class CameraMovementSettings : ScriptableObject
    {
        [Header("Speed Setup")]
        public float movingSpeed = 3f;
        public float scalingSpeed = 60f;
        public float rotatingSpeed = 0.05f;
        
        [Header("Move Borders")]
        public float minXCameraPosition = -3f;
        public float maxXCameraPosition = 3f;
        public float minZCameraPosition = -3f;
        public float maxZCameraPosition = 3f;
        
        [Header("Field Of View Borders")]
        public float minFieldOfView = 30f;
        public float maxFieldOfView = 100f;
    }
}