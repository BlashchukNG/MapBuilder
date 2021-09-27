using Code.GameController;
using Code.Map;
using Code.UserInput;
using Code.UserUI;
using UnityEngine;

namespace Code.UserCamera
{
    public sealed class CameraController :
        ILogicUpdatable,
        IDestroyable
    {
        private const float DIVIDE_BY_VALUE = 2f;

        private CameraConfig _config;
        private MapList _mapList;

        private UserInterfaceController _userInterfaceController;
        private InputController _inputController;
        private Camera _userCamera;
        private Vector2 _pointerPosition;
        private Vector2 _dragOrigin;
        private bool _canDrag;
        private bool _isDraging;

        public CameraController(UserInterfaceController userInterfaceController, InputController inputController,
                                Camera camera, CameraConfig config, MapList mapList)
        {
            _userInterfaceController = userInterfaceController;
            _inputController = inputController;
            _userCamera = camera;
            _mapList = mapList;

            _userCamera.transform.position = new Vector3
                (
                 _mapList.XCameraBounds.y / DIVIDE_BY_VALUE,
                 _mapList.YCameraBounds.x / DIVIDE_BY_VALUE,
                 _userCamera.transform.position.z
                );

            _userInterfaceController.OnPause += Pause;
            inputController.UserInput.OnPointerPosition += UpdatePointerPosition;
            inputController.UserInput.OnPointerDown += PointerDown;
            inputController.UserInput.OnPointerUp += PointerUp;

            _canDrag = true;
        }

        public void Update(float delta)
        {
            if (!_canDrag) return;
            if (_isDraging) Drag();
        }

        #region Call Methods

        private void Pause(bool value) => _canDrag = value;

        private void UpdatePointerPosition(Vector2 position) => _pointerPosition = position;

        private void PointerUp()
        {
            _isDraging = false;
        }

        private void PointerDown(Vector2 position)
        {
            _isDraging = true;
            _dragOrigin = _userCamera.ScreenToWorldPoint(position);
        }

        #endregion

        private void Drag()
        {
            Vector3 difference = _dragOrigin - (Vector2) _userCamera.ScreenToWorldPoint(_pointerPosition);
            _userCamera.transform.position = ClampCamera(_userCamera.transform.position + difference);
        }

        private Vector3 ClampCamera(Vector3 position)
        {
            var camHeight = _userCamera.orthographicSize;
            var camWidth = _userCamera.orthographicSize * _userCamera.aspect;

            var minX = _mapList.XCameraBounds.x + camWidth;
            var maxX = _mapList.XCameraBounds.y - camWidth;
            var minY = _mapList.YCameraBounds.x + camHeight;
            var maxY = _mapList.YCameraBounds.y - camHeight;

            var newX = Mathf.Clamp(position.x, minX, maxX);
            var newY = Mathf.Clamp(position.y, minY, maxY);

            return new Vector3(newX, newY, position.z);
        }

        public void Destroy()
        {
            _userInterfaceController.OnPause -= Pause;
            _inputController.UserInput.OnPointerPosition -= UpdatePointerPosition;
            _inputController.UserInput.OnPointerDown -= PointerDown;
            _inputController.UserInput.OnPointerUp -= PointerUp;
        }
    }
}