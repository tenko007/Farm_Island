using UnityEngine;
using Utils;

namespace CameraMovementSystem
{
    public class CameraMovement : ICameraMovement
    {
        private readonly Camera _camera;
        private readonly CameraMovementSetup _setup;
        public CameraMovement(Camera camera, CameraMovementSetup setup)
        {
            this._camera = camera;
            this._setup = setup;
        }

        public void Move(Vector3 direction)
        {
            var cameraTransform = _camera.transform;
            Vector3 yDirection = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;
            Vector3 xDirection = new Vector3(cameraTransform.right.x, 0, cameraTransform.right.z).normalized;

            float fieldOfViewSpeedCoeff = _camera.fieldOfView / 100f;
            
            var newPosition = cameraTransform.position;
            newPosition +=
                yDirection * direction.y * Time.deltaTime * _setup.movingSpeed * fieldOfViewSpeedCoeff + 
                xDirection * direction.x * Time.deltaTime * _setup.movingSpeed * fieldOfViewSpeedCoeff; 

            newPosition = ClampPosition(newPosition);
            
            cameraTransform.position = newPosition;
        }

        private Vector3 ClampPosition(Vector3 position)
        {
            Vector3 newPosition = new Vector3(
                x: Mathf.Clamp(position.x, _setup.minXCameraPosition, _setup.maxXCameraPosition), 
                y: position.y, 
                z: Mathf.Clamp(position.z, _setup.minZCameraPosition, _setup.maxZCameraPosition));
            
            return newPosition;
        }
        
        public void Rotate(float angle)
        {
            angle = angle * _setup.rotatingSpeed;
            if (angle != 0)
            {
                Vector3 cameraViewPoint = WorldPoints.GetCameraCenterPositionOnWorldObject();
                _camera.transform.RotateAround(cameraViewPoint, Vector3.up, angle);
            }
        }

        public void Scale(float scaleValue)
        {
            float newFieldOfView = _camera.fieldOfView - scaleValue * _setup.scalingSpeed;
            newFieldOfView = Mathf.Clamp(newFieldOfView, _setup.minFieldOfView, _setup.maxFieldOfView);

            _camera.fieldOfView = newFieldOfView;
        }
    }
}