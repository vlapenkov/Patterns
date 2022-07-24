using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureServices.Models.Fields
{
    public class MultipleTextField : BaseField
    {
        public MultipleTextField(string type, string[] values) : base(type)
        {
            Values = values;
        }
        public string[] Values { get; set; }
    }
}
