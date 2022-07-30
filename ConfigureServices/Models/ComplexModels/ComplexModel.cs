using ConfigureServices.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureServices.Models.ComplexModels
{
    public class ComplexModel
    {
        public string Name { get; set; }
        public IEnumerable<SimpleModel> AttributeValues { get; set; } = new List<SimpleModel>();
    }

    public class SimpleModel
    {
        public BaseField Field { get; set; }

        public long Id { get; set; }
    }
}
