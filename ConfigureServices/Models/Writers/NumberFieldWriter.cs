using ConfigureServices.Models.Fields;
using System.Text.Json;

namespace ConfigureServices.Models.Wrappers
{
    public class NumberFieldWriter : IFieldWriter
    {
        NumberField _source;
        public NumberFieldWriter(NumberField source)
        {
            _source = source;
        }

        public void Write(Utf8JsonWriter writer, JsonSerializerOptions options)
        {

            writer.WriteStartObject();

            writer.WriteString("Type", _source.GetType().Name);

            if (_source.Value == null)
                writer.WriteNull(nameof(_source.Value));
            else
                writer.WriteNumber(nameof(_source.Value), (int)_source.Value);

            writer.WriteEndObject();
        }
    }
}
