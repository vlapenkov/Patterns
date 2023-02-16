using ConfigureServices.Models.Fields;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigureServices.Models.ComplexModels
{
    public class ComplexModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SimpleModel> AttributeValues { get; set; } = new List<SimpleModel>();
    }

    public class SimpleModel
    {
        public long Id { get; set; }

        [Column(TypeName = "jsonb")]
        public BaseField Field { get; set; }


        public long AttributeId { get; set; }
    }
}
