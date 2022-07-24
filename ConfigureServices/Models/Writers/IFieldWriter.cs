using System.Text.Json;

namespace ConfigureServices.Models.Wrappers
{
    public interface IFieldWriter
    {
        public abstract void Write(Utf8JsonWriter writer, JsonSerializerOptions options);

    }
}