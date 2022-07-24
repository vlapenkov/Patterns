using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
