using UnityEngine;
using Utils;

namespace CameraMovementSystem
{
    public class CameraMovement : ICameraMovement
    {
        private readonly Camera _camera;
        private readonly CameraMovementSettings settings;
        public CameraMovement(Camera camera, CameraMovementSettings settings)
        {
            this._camera = camera;
            this.settings = settings;
        }

        public void Move(Vector3 direction)
        {
            var cameraTransform = _camera.transform;
            Vector3 yDirection = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;
            Vector3 xDirection = new Vector3(cameraTransform.right.x, 0, cameraTransform.right.z).normalized;

            float fieldOfViewSpeedCoeff = _camera.fieldOfView / 100f;
            
            var newPosition = cameraTransform.position;
            newPosition +=
                yDirection * direction.y * Time.deltaTime * settings.movingSpeed * fieldOfViewSpeedCoeff + 
                xDirection * direction.x * Time.deltaTime * settings.movingSpeed * fieldOfViewSpeedCoeff; 

            newPosition = ClampPosition(newPosition);
            
            cameraTransform.position = newPosition;
        }

        private Vector3 ClampPosition(Vector3 position)
        {
            Vector3 newPosition = new Vector3(
                x: Mathf.Clamp(position.x, settings.minXCameraPosition, settings.maxXCameraPosition), 
                y: position.y, 
                z: Mathf.Clamp(position.z, settings.minZCameraPosition, settings.maxZCameraPosition));
            
            return newPosition;
        }
        
        public void Rotate(float angle)
        {
            angle = angle * settings.rotatingSpeed;
            if (angle != 0)
            {
                Vector3 cameraViewPoint = WorldPoints.GetCameraCenterPositionOnWorldObject();
                _camera.transform.RotateAround(cameraViewPoint, Vector3.up, angle);
            }
        }

        public void Scale(float scaleValue)
        {
            float newFieldOfView = _camera.fieldOfView - scaleValue * settings.scalingSpeed;
            newFieldOfView = Mathf.Clamp(newFieldOfView, settings.minFieldOfView, settings.maxFieldOfView);

            _camera.fieldOfView = newFieldOfView;
        }
    }
}