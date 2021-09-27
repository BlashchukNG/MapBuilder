using System.Collections.Generic;
using Code.Loader;
using Code.Map;
using Code.Parser;
using Code.UserCamera;
using Code.UserInput;
using Code.UserUI;
using UnityEngine;

namespace Code.GameController
{
    public class GameController :
        MonoBehaviour
    {
        [SerializeField] private string _jsonPath;

        private List<ILogicUpdatable> _updatables = new List<ILogicUpdatable>(10);
        private List<IDestroyable> _destroyables = new List<IDestroyable>(10);

        private void Awake()
        {
            IDataLoader loader = new DataLoader();
            var json = loader.Load(_jsonPath);

            IDataParser parser = new DataParser();
            var mapData = parser.Parse(json);

            var map = new MapFactory(mapData).Create();

            var uiController = new UserInterfaceControllerInitializer().GetController();
            var inputController = new InputControllerInitializer().GetController();
            var cameraController = new CameraControllerInitializer(uiController, inputController, map).GetController();

            _updatables.Add(inputController);
            _updatables.Add(cameraController);

            _destroyables.Add(uiController);
            _destroyables.Add(cameraController);
        }

        private void Update()
        {
            var delta = Time.deltaTime;

            foreach (var logicUpdatable in _updatables)
            {
                logicUpdatable.Update(delta);
            }
        }

        private void OnDestroy()
        {
            foreach (var destroyable in _destroyables)
            {
                destroyable.Destroy();
            }
        }
    }
}