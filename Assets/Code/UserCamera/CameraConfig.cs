using UnityEngine;

namespace Code.UserCamera
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Map Builder/Configs/Camera")]
    public sealed class CameraConfig :
        ScriptableObject
    {
        public float zoomStep;
        public float minCamSize;
        public float maxCamSize;
    }
}