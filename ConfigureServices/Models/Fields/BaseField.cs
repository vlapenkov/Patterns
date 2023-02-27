using System.Text.Json.Serialization;

namespace ConfigureServices.Models.Fields
{
    [JsonConverter(typeof(FieldJsonConverter))]
    public class BaseField
    {
        public string Type { get; protected set; }

        [JsonConstructor]
        public BaseField(string type)
        {
            Type = type;
        }
    }
}
