using UnityEngine;

namespace InputSystem
{
    public class MultiplatformTouchInput : IInputSystem
    {
        ///////////////////////////////////////////////////////////

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
#if (UNITY_ANDROID || UNITY_IOS) && (!UNITY_EDITOR)

        if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == phase))
            return true;
#else
            switch (phase)
            {
                case TouchPhase.Began:
                    return Input.GetMouseButtonDown(0);
                case TouchPhase.Ended:
                    return Input.GetMouseButtonUp(0);
                case TouchPhase.Moved:
                    return Input.GetMouseButton(0);
            }
#endif
            return false;
        }

        ///////////////////////////////////////////////////////////

        public bool IsDragging()
        {
            return ClickByPhase(TouchPhase.Moved);
        }
        public bool IsScaling()
        {
            return ((Input.GetAxis("Mouse ScrollWheel") != 0) || (Input.touchCount == 2));
        }

        public float GetScalingValue()
        {
#if (UNITY_ANDROID || UNITY_IOS) && (!UNITY_EDITOR)
            if (Input.touchCount == 2)
                return GetScalingValueTouches();
#else
            //if (Input.GetAxis("Mouse ScrollWheel") != 0)
                return Input.GetAxis("Mouse ScrollWheel");
#endif
            return 0f;
        }

        public bool IsRotating()
        {
            return ((Input.GetMouseButton(2)) ||(Input.touchCount == 2));
        }

        public float GetRotatingValue()
        {
#if (UNITY_ANDROID || UNITY_IOS) && (!UNITY_EDITOR)
            if (Input.touchCount == 2)
                return GetRotatingValueTouches();
#else
            if (Input.GetMouseButton(2)) // Middle Mouse Button
                return Input.GetAxis("Mouse Y") * 500f;
#endif
            return 0f;
        }

        private float GetScalingValueTouches()
        {
            if ((Input.touchCount < 2))
                return 0f;

            Vector2 A1 = Input.GetTouch(0).position;
            Vector2 A2 = Input.GetTouch(1).position;

            Vector2 B1 = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;
            Vector2 B2 = Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition;

            float lastDistance = Vector2.Distance(B1, B2);
            float newDistance = Vector2.Distance(A1, A2);

            float scaleValue = (newDistance - lastDistance) / 500f;
            return scaleValue;
        }

        private float GetRotatingValueTouches()
        {
            if ((Input.touchCount < 2))
                return 0f;

            Vector2 A1 = Input.GetTouch(0).position;
            Vector2 A2 = Input.GetTouch(1).position;

            Vector2 B1 = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;
            Vector2 B2 = Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition;

            float hypotenuse1 = Vector2.Distance(A1, A2);
            float hypotenuse2 = Vector2.Distance(B1, B2);

            float H1 = B1.y - A1.y;
            float H2 = B2.y - A2.y;

            if (hypotenuse1 == 0) hypotenuse1 = 0.001f;
            if (hypotenuse2 == 0) hypotenuse2 = 0.001f;

            float sinAlpha = H1 / hypotenuse1;
            float sinBeta = H2 / hypotenuse2;

            float alpha = Mathf.Asin(sinAlpha);
            float beta = Mathf.Asin(sinBeta);

            int sign = 1;
            if (Vector2.Distance(Vector2.zero, A2) < Vector2.Distance(Vector2.zero, A1))
                sign = -1;
            float angle;

            angle = (alpha - beta) * 1000f * sign;

            //angle = Vector3.SignedAngle(B1 - A1, B2 - A2, Vector3.forward);
            return angle;
        }

        ///////////////////////////////////////////////////////////

        public Vector3 GetMousePosition()
        {
#if (UNITY_ANDROID || UNITY_IOS) && (!UNITY_EDITOR)
    if (Input.touchCount > 0)
        //return Input.GetTouch(Input.touchCount - 1).position;
        return Input.GetTouch(0).position;
    return Vector3.zero;
#else
            return Input.mousePosition;
#endif
        }
    }
}
