using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
