using Code.Map;
using UnityEngine;

namespace Code.Parser
{
    public sealed class DataParser :
        IDataParser
    {
        public MapData Parse(string json)
        {
            MapData mapData = JsonUtility.FromJson<MapData>(json);
            return mapData;
        }
    }
}