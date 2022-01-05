﻿using InputSystem;
using UnityEngine;

namespace Utils
{
    public static class WorldPoints
    {
        private static IInputSystem _inputSystem = GameManager.Instance.InputSystem;
        private static float _maxRayDistance = 1000f;

        public static void SetMaxRayDistance(float maxRayDistance)
        {
            WorldPoints._maxRayDistance = maxRayDistance;
        }
    
        public static bool IsMousePositionOnLayer(LayerMask layerForRaycast)
        {
            Ray rayToMouse = GetRayToMouse();

            RaycastHit hit;
            if (Physics.Raycast(rayToMouse, out hit))
            {
                if (hit.transform.gameObject.layer == layerForRaycast)
                    return true;
            }

            return false;
        }

        public static Vector3 GetMousePositionOnWorldObject()
        {
            Ray rayToMouse = GetRayToMouse();

            RaycastHit hit;
            if (Physics.Raycast(rayToMouse, out hit, _maxRayDistance))
            {
                return hit.point;
            }

            return Vector3.zero;
        }

        public static Vector3 GetMousePositionOnLayer(LayerMask layerForRaycast)
        {
            Ray rayToMouse = GetRayToMouse();

            RaycastHit hit;
            if (Physics.Raycast(rayToMouse, out hit, _maxRayDistance, layerForRaycast))
            {
                return hit.point;
            }

            return Vector3.zero;
        }

        public static GameObject GetObjectUnderMouse()
        {
            Ray rayToMouse = GetRayToMouse();

            RaycastHit hit;
            if (Physics.Raycast(rayToMouse, out hit, _maxRayDistance))
            {
                return hit.transform.gameObject;
            }

            return null;
        }

        public static GameObject GetObjectUnderMouse(LayerMask layerForRaycast)
        {
            Ray rayToMouse = GetRayToMouse();

            RaycastHit hit;
            if (Physics.Raycast(rayToMouse, out hit, _maxRayDistance, layerForRaycast))
            {
                return hit.transform.gameObject;
            }

            return null;
        }

        private static Ray GetRayToMouse()
        {
            Vector3 point = _inputSystem.GetMousePosition();
            return GetRayToPoint(point);
        }

        private static Ray GetRayToPoint(Vector3 point)
        {
            return Camera.current.ScreenPointToRay(point);
        }

        private static Ray GetRayToCenterOfCamera()
        {
            var current = Camera.current;
            Vector3 point = new Vector3(current.pixelWidth/2f, current.pixelHeight/2f, 0);
            return GetRayToPoint(point);
        }

        public static GameObject GetObjectUnderCenterOfCamera()
        {
            Ray rayToCamera = GetRayToCenterOfCamera();

            RaycastHit hit;
            if (Physics.Raycast(rayToCamera, out hit, _maxRayDistance))
            {
                return hit.transform.gameObject;
            }

            return null;
        }

        public static GameObject GetObjectUnderCenterOfCamera(LayerMask layerForRaycast)
        {
            Ray rayToCamera = GetRayToCenterOfCamera();

            RaycastHit hit;
            if (Physics.Raycast(rayToCamera, out hit, _maxRayDistance, layerForRaycast))
            {
                return hit.transform.gameObject;
            }

            return null;
        }

        public static Vector3 GetCameraCenterPositionOnWorldObject()
        {
            Ray rayToCamera = GetRayToCenterOfCamera();

            RaycastHit hit;
            if (Physics.Raycast(rayToCamera, out hit, _maxRayDistance))
            {
                return hit.point;
            }

            return Vector3.zero;
        }

        public static Vector3 GetCameraCenterPositionOnLayer(LayerMask layerForRaycast)
        {
            Ray rayToCamera = GetRayToCenterOfCamera();

            RaycastHit hit;
            if (Physics.Raycast(rayToCamera, out hit, _maxRayDistance, layerForRaycast))
            {
                return hit.point;
            }

            return Vector3.zero;
        }

        ////////////////////////////////////////////////////////////////

        public static Vector3 GetMousePositionOnScreen()
        {
            return Input.mousePosition;
        }

        public static Vector2 GetObjectPositionOnScreen(GameObject obj)
        {
            return Camera.current.WorldToScreenPoint(obj.transform.position);
        }

        public static Vector2 GetPointPositionOnScreen(Vector3 point)
        {
            return Camera.current.WorldToScreenPoint(point);
        }

    }
}        
