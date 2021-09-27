using System;
using Code.GameController;
using UnityEngine;

namespace Code.UserUI
{
    public sealed class UserInterfaceController :
        IDestroyable
    {
        private const float CHECK_RADIUS = 1f;

        public event Action<bool> OnPause;

        private Camera _userCamera;

        private IUserInterface _view;

        public UserInterfaceController(IUserInterface view, Camera camera)
        {
            _userCamera = camera;
            _view = view;
            _view.Initialize();

            _view.OnPauseOpen += PauseOpen;
            _view.OnPauseClose += PauseClose;

            OnPause = context => { };
        }

        private void PauseOpen(Vector2 position)
        {
            OnPause.Invoke(false);

            var texture = Physics2D.OverlapCircle(_userCamera.ScreenToWorldPoint(position), CHECK_RADIUS);
            if (texture)
            {
                _view.SetText(texture.name);
            }
        }

        private void PauseClose()
        {
            OnPause.Invoke(true);
        }

        public void Destroy()
        {
            _view.OnPauseOpen -= PauseOpen;
            _view.OnPauseClose -= PauseClose;
        }
    }
}