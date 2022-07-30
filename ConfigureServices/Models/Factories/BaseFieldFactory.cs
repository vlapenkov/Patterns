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

            string fullTypeName = "ConfigureServices.Models.Fields." + typeValue;
            return (BaseField)JsonSerializer.Deserialize(_rootElement, Type.GetType(fullTypeName), _options);

        }
    }
}
