using UnityEngine;

namespace Code.Loader
{
    public sealed class DataLoader :
        IDataLoader
    {
        public string Load(string path)
        {
            TextAsset asset = Resources.Load(path) as TextAsset;;
            var json = asset.text;
            return json;
        }
    }
}