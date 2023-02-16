using ConfigureServices.Models.Wrappers;
using System;
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

        /// <summary>
        /// Десериализация типа
        /// </summary>
        public override BaseField Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {


            if (JsonDocument.TryParseValue(ref reader, out var doc))
            {
                // тип задается явно в поле Type
                if (doc.RootElement.TryGetProperty("Type", out var type))
                {
                    var typeValue = type.GetString();
                    var rootElement = doc.RootElement.GetRawText();

                    //  var fieldFactory = new BaseFieldFactory(rootElement, options);
                    string fullTypeName = "ConfigureServices.Models.Fields." + typeValue;
                    return (BaseField)JsonSerializer.Deserialize(rootElement, Type.GetType(fullTypeName), options);
                }

                throw new JsonException("Failed to extract type property, it might be missing?");
            }

            throw new JsonException("Failed to parse JsonDocument");
        }


        /// <summary>
        /// Сериализация типа
        /// </summary>        
        public override void Write(Utf8JsonWriter writer, BaseField value, JsonSerializerOptions options)
        {
            var concreteWriter = FieldWriterFactory.Create(value);

            concreteWriter.Write(writer, options);

        }
    }
}