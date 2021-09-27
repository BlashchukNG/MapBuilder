using System.Collections.Generic;
using UnityEngine;

namespace Code.Map
{
    public sealed class MapList
    {
        public List<SpriteRenderer> MapSegments;
        public Vector2 XCameraBounds;
        public Vector2 YCameraBounds;

        public MapList()
        {
            MapSegments = new List<SpriteRenderer>();
        }
    }
}