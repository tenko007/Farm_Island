using UnityEngine;

namespace InputSystem
{
    public class MobileTouchInput : IInputSystem
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
            return (Input.touchCount == 1 && ClickByPhase(TouchPhase.Moved));
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
            
            float oppositeCathetP1 = p1.y - y0; 
            float oppositeCathetP2 = p2.y - y0; 
            
            float adjacentCathetP1 = p1.x - x0; 
            float adjacentCathetP2 = p2.x - x0;
  
            float angleToP1 = Mathf.Atan(oppositeCathetP1 / adjacentCathetP1);
            float angleToP2 = Mathf.Atan(oppositeCathetP2 / adjacentCathetP2);

            float angle = angleToP2 - angleToP1;
            return angle;
        }

        public Vector3 GetMousePosition()
        {
            if (Input.touchCount > 0)
                return Input.GetTouch(0).position;
            return Vector3.zero;
        }
    }
}
