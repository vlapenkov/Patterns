using ConfigureServices.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConfigureServices.Models.Wrappers
{
    public class MultipleTextFieldWriter : BaseFieldWriter
    {
        MultipleTextField _source;
        public MultipleTextFieldWriter(MultipleTextField source)
        {
            _source = source;
        }

        public void Write(Utf8JsonWriter writer, JsonSerializerOptions options)
        {

            writer.WriteStartObject();

            writer.WriteString("Type", _source.GetType().Name);

            if (_source.Values == null)
                writer.WriteNull(nameof(_source.Values));
            else
                writer.WriteStartArray(nameof(_source.Values));
            foreach (var val in _source.Values)
                writer.WriteStringValue(val);

            writer.WriteEndArray();



            writer.WriteEndObject();
        }
    }
}
