using Code.Map;
using Code.UserInput;
using Code.UserUI;
using UnityEngine;

namespace Code.UserCamera
{
    public sealed class CameraControllerInitializer
    {
        private const string PATH = "CameraConfig";

        private CameraController _controller;

        public CameraControllerInitializer
            (
            UserInterfaceController userInterfaceController,
            InputController inputController,
            MapList mapList
            )
        {
            var camera = Camera.allCameras[0];
            var config = Resources.Load<CameraConfig>(PATH);
            _controller = new CameraController(userInterfaceController, inputController, camera, config, mapList);
        }

        public CameraController GetController() => _controller;
    }
}