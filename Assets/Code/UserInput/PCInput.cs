using System;
using UnityEngine;

namespace Code.UserInput
{
    public sealed class PCInput :
        IUserInput
    {
        private const int MOUSE_LEFT_BUTTON = 0;

        public event Action<Vector2> OnPointerPosition;
        public event Action<Vector2> OnPointerDown;
        public event Action OnPointerUp;

        public PCInput()
        {
            //null-object pattern
            OnPointerPosition = context => { };
            OnPointerDown = context => { };
            OnPointerUp = () => { };
        }

        public void GetInput()
        {
            if (Input.GetMouseButtonDown(MOUSE_LEFT_BUTTON)) OnPointerDown.Invoke(Input.mousePosition);
            if (Input.GetMouseButton(MOUSE_LEFT_BUTTON)) OnPointerPosition.Invoke(Input.mousePosition);
            if (Input.GetMouseButtonUp(MOUSE_LEFT_BUTTON)) OnPointerUp.Invoke();
        }
    }
}