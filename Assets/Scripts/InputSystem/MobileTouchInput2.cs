using System.Security.Cryptography;
using UnityEngine;

namespace InputSystem
{
    public class MobileTouchInput2 : IInputSystem
    {
        public bool ClickStart()
        {
            return ClickByPhase(TouchPhase.Began);
        }

        public bool ClickEnd()
        {
            return ClickByPhase(TouchPhase.Ended);
        }

        private bool ClickByPhase(TouchPhase phase)
        {
            if ((Input.GetTouch(0).phase == phase))
                return true;

            return false;
        }

        public bool IsDragging()
        {
            //return ClickByPhase(TouchPhase.Moved);
            return (Input.touchCount == 1);
        }
        public bool IsScaling()
        {
            return (Input.touchCount == 2);
        }
        
        public bool IsRotating()
        {
            return (Input.touchCount == 2);
        }

        public float GetScalingValue()
        {
            if ((Input.touchCount < 2))
                return 0f;

            Vector2 A1 = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;
            Vector2 B1 = Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition;
            
            Vector2 A2 = Input.GetTouch(0).position;
            Vector2 B2 = Input.GetTouch(1).position;

            float lastDistance = Vector2.Distance(A1, B1);
            float newDistance  = Vector2.Distance(A2, B2);

            float scaleValue = (newDistance - lastDistance) / 1000f;
            return scaleValue;
        }

        public float GetRotatingValue()
        {
            if ((Input.touchCount < 2))
                return 0f;

            Vector2 A1 = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;
            Vector2 B1 = Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition;
            
            Vector2 A2 = Input.GetTouch(0).position;
            Vector2 B2 = Input.GetTouch(1).position;

            float alpha = CalcAngleBetweenPoints(A1, A2);
            float beta = CalcAngleBetweenPoints(B1, B2);

            return (alpha + beta) * 1000f;
        }
        
        private float CalcAngleBetweenPoints(Vector2 p1, Vector2 p2)
        {
            float x0 = Screen.width / 2f;
            float y0 = Screen.height / 2f;
            
            float oppositeCathetP1 = Mathf.Abs(p1.y - y0); 
            float oppositeCathetP2 = Mathf.Abs(p2.y - y0); 
            
            float adjacentCathetP1 = Mathf.Abs(p1.x - x0); 
            float adjacentCathetP2 = Mathf.Abs(p2.x - x0);
  
            float angleToP1 = Mathf.Atan(oppositeCathetP1 / adjacentCathetP1);
            float angleToP2 = Mathf.Atan(oppositeCathetP2 / adjacentCathetP2);

            if (Mathf.Abs(angleToP1 - angleToP2) > 0.01f)
                Debug.Log($"Angles Pre Update: angle1 = {angleToP1}, angle2 = {angleToP2}");

            angleToP1 = UpdateAngleByQuarter(angleToP1, p1 - new Vector2(x0, y0));            
            angleToP2 = UpdateAngleByQuarter(angleToP2, p2 - new Vector2(x0, y0));

            if (Mathf.Abs(angleToP1 - angleToP2) > 0.01f)
                Debug.Log($"Angles After Update: angle1 = {angleToP1}, angle2 = {angleToP2}");

            angleToP1 = angleToP1 % 360;
            angleToP2 = angleToP2 % 360;

            float angle = angleToP2 - angleToP1;
            return angle;
        }

        private float UpdateAngleByQuarter(float angle, Vector2 point)
        {
            if (point.x < 0 && point.y > 0)
                return 180 - angle;
            else if (point.x < 0 && point.y < 0)
                return 180 + angle;
            else if (point.x > 0 && point.y < 0)
                return 360 - angle;
            return angle;
        }

        public Vector3 GetMousePosition()
        {
            if (Input.touchCount > 0)
                //return Input.GetTouch(Input.touchCount - 1).position;
                return Input.GetTouch(0).position;
            return Vector3.zero;
        }
    }
}
