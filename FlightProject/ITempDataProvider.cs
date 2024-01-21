using System.IO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

public class CustomTempDataProvider : ITempDataProvider
{
    private readonly JsonSerializerSettings _jsonSerializerSettings;

    public CustomTempDataProvider()
    {
        _jsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };
    }

    public IDictionary<string, object> LoadTempData(HttpContext context)
    {
        var tempData = new Dictionary<string, object>();

        var value = context.Session.GetString("TempData");
        if (!string.IsNullOrEmpty(value))
        {
            using (var reader = new StringReader(value))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var serializer = JsonSerializer.Create(_jsonSerializerSettings);
                tempData = serializer.Deserialize<Dictionary<string, object>>(jsonReader);
            }
        }

        return tempData;
    }

    public void SaveTempData(HttpContext context, IDictionary<string, object> values)
    {
        using (var writer = new StringWriter())
        using (var jsonWriter = new JsonTextWriter(writer))
        {
            var serializer = JsonSerializer.Create(_jsonSerializerSettings);
            serializer.Serialize(jsonWriter, values);

            context.Session.SetString("TempData", writer.ToString());
        }
    }
}