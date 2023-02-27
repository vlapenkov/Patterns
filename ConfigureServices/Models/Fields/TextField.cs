using System.Text.Json.Serialization;

namespace ConfigureServices.Models.Fields
{
    public class TextField : BaseField
    {
        [JsonConstructor]
        public TextField(string type, string value) : base(type)
        {
            Value = value;
        }
        public string Value { get; set; }
    }
}
