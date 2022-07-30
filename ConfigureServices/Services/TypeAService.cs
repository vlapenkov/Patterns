using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureServices.Models
{
    public class TypeAService : BaseTypeService
    {
        public int Id { get; set; }
        public override string ToString()
        {
            return "TypeA";
        }
    }
}
