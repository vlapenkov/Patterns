using ConfigureServices.Domain;
using ConfigureServices.Models.Fields;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigureServices.Models.ComplexModels
{

   

    public class ComplexModel : BaseEntity
    {

        public string Name { get; set; }
        public IEnumerable<SimpleModel> AttributeValues { get; set; } = new List<SimpleModel>();
    }

    public class SimpleModel : BaseEntity
    {


        [Column(TypeName = "jsonb")]
        public BaseField Field { get; set; }


        public long AttributeId { get; set; }
    }


    
}
