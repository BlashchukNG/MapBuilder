using System;
using UnityEngine;

namespace Code.UserInput
{
    public sealed class MobileInput :
        IUserInput
    {
        public event Action<Vector2> OnPointerPosition;
        public event Action<Vector2> OnPointerDown;
        public event Action OnPointerUp;

        public MobileInput()
        {
            //null-object pattern
            OnPointerPosition = context => { };
            OnPointerDown = context => { };
            OnPointerUp = () => { };
        }

        public void GetInput()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        OnPointerDown.Invoke(touch.position);
                        break;
                    case TouchPhase.Moved:
                        OnPointerPosition.Invoke(touch.position);
                        break;
                    case TouchPhase.Ended:
                        OnPointerUp.Invoke();
                        break;
                }
            }
        }
    }
}