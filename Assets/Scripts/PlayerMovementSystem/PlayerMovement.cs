using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using Utils;

namespace PlayerMovementSystem
{
    public class PlayerMovement : MonoBehaviour, IPlayerMovement
    {
        [SerializeField] private Camera _camera;

        [Header("Speed Setup")]
        [SerializeField] private float movingSpeed = 1f;
        [SerializeField] private float scalingSpeed = 60f;
        [SerializeField] private float rotatingSpeed = 0.05f;
        
        [Header("Move Borders")]
        [SerializeField] private float minXCameraPosition = -3f;
        [SerializeField] private float maxXCameraPosition = 3f;
        [SerializeField] private float minZCameraPosition = -3f;
        [SerializeField] private float maxZCameraPosition = 3f;
        
        [Header("Field Of View Borders")]
        [SerializeField] private float minFieldOfView = 30f;
        [SerializeField] private float maxFieldOfView = 100f;

        public void Move(Vector3 direction)
        {
            var cameraTransform = _camera.transform;
            Vector3 yDirection = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;
            Vector3 xDirection = new Vector3(cameraTransform.right.x, 0, cameraTransform.right.z).normalized;

            float fieldOfViewSpeedCoeff = _camera.fieldOfView / 100f;
            
            var newPosition = cameraTransform.position;
            newPosition +=
                yDirection * direction.y * Time.deltaTime * movingSpeed * fieldOfViewSpeedCoeff + 
                xDirection * direction.x * Time.deltaTime * movingSpeed * fieldOfViewSpeedCoeff; 

            newPosition = ClampPosition(newPosition);
            
            cameraTransform.position = newPosition;
        }

        private Vector3 ClampPosition(Vector3 position)
        {
            Vector3 newPosition = new Vector3(
                x: Mathf.Clamp(position.x, minXCameraPosition, maxXCameraPosition), 
                y: position.y, 
                z: Mathf.Clamp(position.z, minZCameraPosition, maxZCameraPosition));
            
            return newPosition;
        }
        
        public void Rotate(float angle)
        {
            angle = angle * rotatingSpeed;
            if (angle != 0)
            {
                Vector3 cameraViewPoint = WorldPoints.GetCameraCenterPositionOnWorldObject();
                _camera.transform.RotateAround(cameraViewPoint, Vector3.up, angle);
            }
        }

        public void Scale(float scaleValue)
        {
            float newFieldOfView = _camera.fieldOfView - scaleValue * scalingSpeed;
            newFieldOfView = Mathf.Clamp(newFieldOfView, minFieldOfView, maxFieldOfView);

            _camera.fieldOfView = newFieldOfView;
        }
    }
}