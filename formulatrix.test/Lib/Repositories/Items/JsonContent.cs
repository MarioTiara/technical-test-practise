using System.Text.Json;
using Formulatrix.Repositories;
using Formulatrix.Repositories.Items;

namespace Formulatrix.Repositories.items;

public class JsonContent : IItemContent
{
    private string _jsonData;
    public JsonContent(string jsonData)
    {
        if (!IsValidJson(jsonData)) throw new ArgumentException("Invalid JSON data.");
        _jsonData = jsonData;
    }
    public string Content => this._jsonData;

    public ContentType ContentType => ContentType.JSON;

    private bool IsValidJson(string json)
    {
        try
        {
            JsonDocument.Parse(json);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}