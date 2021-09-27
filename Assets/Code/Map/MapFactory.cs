using UnityEngine;

namespace Code.Map
{
    public sealed class MapFactory :
        IMapFactory
    {
        private const string MAP_ROOT_NAME = "[MAP ROOT]";
        private const float DEVIDE_BY_VALUE = 2f;

        private MapData _mapData;

        public MapFactory(MapData mapData)
        {
            _mapData = mapData;
        }

        public MapList Create()
        {
            var root = new GameObject(MAP_ROOT_NAME);
            var map = new MapList();

            foreach (var data in _mapData.List)
            {
                var segment = new GameObject(data.Id).AddComponent<SpriteRenderer>();
                segment.transform.parent = root.transform;
                segment.transform.position = new Vector2(data.X, data.Y);
                segment.sprite = Resources.Load<Sprite>(data.Id);
                segment.gameObject.AddComponent<BoxCollider2D>();

                if (data.X == 0 && data.Y == 0)
                {
                    map.XCameraBounds.x = data.X;
                    map.YCameraBounds.y = data.Y + segment.bounds.size.y;
                }

                if (data.X != 0 && data.Y != 0)
                {
                    map.XCameraBounds.y = data.X + segment.bounds.size.x;
                    map.YCameraBounds.x = data.Y;
                }

                map.MapSegments.Add(segment);
            }

            return map;
        }
    }
}