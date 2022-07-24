using ConfigureServices.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConfigureServices.Models.Wrappers
{
    public class TextFieldWriter : IFieldWriter
    {
        TextField _source;
        public TextFieldWriter(TextField source)
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
                writer.WriteString(nameof(_source.Value), _source.Value);

            writer.WriteEndObject();
        }
    }
}
