
using System.Text.Json;

namespace Json2Csv;

public class Converter
{
    public static string JsonToCsv(string json)
    {
        json = json.Replace("{", string.Empty)
            .Replace("}", string.Empty)
            .Replace("[", string.Empty)
            .Replace("]", string.Empty)
            .Replace("\"", string.Empty)
            .Replace(",", ";");

        return json;
    }
    public static bool IsValidJson(string json)
    {
        try
        {
            _ = JsonDocument.Parse(json);
            return true;
        }
        catch(JsonException)
        {
            return false;
        }
    }
}
