using ConfigureServices.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConfigureServices.Models.Wrappers
{
    public class BaseFieldFactory
    {
        private readonly string _rootElement;
        private readonly JsonSerializerOptions _options;
        public BaseFieldFactory(string rootElement, JsonSerializerOptions options)
        {
            _rootElement = rootElement;
            _options = options;
        }
        public BaseField Create(string typeValue)
        {

            return typeValue switch
            {
                "NumberField" => (NumberField)JsonSerializer.Deserialize(_rootElement, typeof(NumberField), _options) as NumberField,
                "TextField" => JsonSerializer.Deserialize<TextField>(_rootElement, _options),
                "MultipleTextField" => JsonSerializer.Deserialize<MultipleTextField>(_rootElement, _options),

                _ => throw new JsonException($"{typeValue} has not been mapped to a custom type yet!")
            };
        }
    }
}
