using Code.Map;

namespace Code.Parser
{
    public interface IDataParser
    {
        MapData Parse(string json);
    }
}