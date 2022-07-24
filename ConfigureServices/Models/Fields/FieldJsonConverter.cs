using ConfigureServices.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConfigureServices.Models.Fields
{
    public class FieldJsonConverter : JsonConverter<BaseField>
    {
        public override bool CanConvert(Type type)
        {
            return type.IsAssignableFrom(typeof(BaseField));
        }

        public override BaseField Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (JsonDocument.TryParseValue(ref reader, out var doc))
            {
                if (doc.RootElement.TryGetProperty("Type", out var type))
                {
                    var typeValue = type.GetString();
                    var rootElement = doc.RootElement.GetRawText();

                    return typeValue switch
                    {
                        "NumberField" => JsonSerializer.Deserialize(rootElement, typeof(NumberField), options) as NumberField,
                        "TextField" => JsonSerializer.Deserialize<TextField>(rootElement, options),
                        "MultipleTextField" => JsonSerializer.Deserialize<MultipleTextField>(rootElement, options),

                        _ => throw new JsonException($"{typeValue} has not been mapped to a custom type yet!")
                    };
                }

                throw new JsonException("Failed to extract type property, it might be missing?");
            }

            throw new JsonException("Failed to parse JsonDocument");
        }



        public override void Write(Utf8JsonWriter writer, BaseField value, JsonSerializerOptions options)
        {
            var concreteWriter = FieldWriterFactory.Create(value);

            concreteWriter.Write(writer, options);
        }
    }
}