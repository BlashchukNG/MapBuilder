using System;
using UnityEngine;

namespace Code.UserInput
{
    public sealed class InputControllerInitializer
    {
        private InputController _controller;

        public InputControllerInitializer()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    _controller = new InputController(new PCInput());
                    break;
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.Android:
                    _controller = new InputController(new MobileInput());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public InputController GetController() => _controller;
    }
}