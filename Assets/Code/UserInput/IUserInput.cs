using System;
using UnityEngine;

namespace Code.UserInput
{
    public interface IUserInput
    {
        event Action<Vector2> OnPointerPosition;
        event Action<Vector2> OnPointerDown;
        event Action OnPointerUp;

        void GetInput();
    }
}