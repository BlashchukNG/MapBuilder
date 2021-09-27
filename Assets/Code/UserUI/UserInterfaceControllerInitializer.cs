using UnityEngine;

namespace Code.UserUI
{
    public sealed class UserInterfaceControllerInitializer
    {
        private const string PATH = "Canvas";

        private UserInterfaceController _controller;

        public UserInterfaceControllerInitializer()
        {
            var prefab = Resources.Load<UserInterfaceView>(PATH);
            var view = Object.Instantiate(prefab);
            var camera = Camera.allCameras[0];
            _controller = new UserInterfaceController(view, camera);
        }

        public UserInterfaceController GetController() => _controller;
    }
}