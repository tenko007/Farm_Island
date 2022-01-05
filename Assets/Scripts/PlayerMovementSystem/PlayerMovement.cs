using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

namespace PlayerMovementSystem
{
    public class PlayerMovement : MonoBehaviour, IPlayerMovement
    {
        [SerializeField] Camera _camera;
        [SerializeField] private float cameraMovingSpeed = 7f;
        [SerializeField] private float cameraScalingSpeed = 12f;
        [SerializeField] private float cameraRotatingSpeed = 5f;
        
        [SerializeField] private float startMainCameraFieldOfView = 10f;
        [SerializeField] private float maxMainCameraFieldOfView = 20f;
        [SerializeField] private float minMainCameraFieldOfView = 2f;
        
        [SerializeField] private float lerpCoefficient = 0.2f;

        public void Move(Vector3 direction)
        {
            Vector3 cameraPosition = _camera.transform.position;
            //Vector3 newCameraPosition = cameraPosition + direction * cameraMovingSpeed;
            Vector3 newCameraPosition = new Vector3(
                x: (cameraPosition.x + direction.x), // * cameraMovingSpeed,
                y: cameraPosition.y,
                z: (cameraPosition.z + direction.y));// * cameraMovingSpeed);
                
            //newCameraPosition = new Vector3(Mathf.Clamp(newCameraPosition.x, minX, maxX), newCameraPosition.y, Mathf.Clamp(newCameraPosition.z, minZ, maxZ));
            _camera.transform.position = Vector3.Lerp(cameraPosition, newCameraPosition, lerpCoefficient);
        }

        public void Rotate(float angle)
        {
            {
                float rotatingValue = angle * Time.deltaTime * cameraRotatingSpeed;
                if (rotatingValue != 0)
                {
                    _camera.transform.Rotate(Vector3.forward, rotatingValue);
                }
            }
        }

        public void Scale(float scaleValue)
        {
            float newFieldOfView = _camera.fieldOfView - scaleValue * cameraScalingSpeed;
            //newFieldOfView = Mathf.Clamp(newFieldOfView, minMainCameraFieldOfView, maxMainCameraFieldOfView);

            _camera.fieldOfView = newFieldOfView;
        }
    }
}