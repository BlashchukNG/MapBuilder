using System;
using UnityEngine;

namespace Code.UserUI
{
    public interface IUserInterface
    {
        event Action<Vector2> OnPauseOpen;
        event Action OnPauseClose;

        void Initialize();
        void SetText(string text);
    }
}