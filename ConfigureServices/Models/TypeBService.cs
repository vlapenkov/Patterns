using ConfigureServices.Models;

namespace ConfigureServices
{
    internal class TypeBService : BaseTypeService
    {
        public string Name { get; set; } = "TypeB";
        public override string ToString()
        {
            return "TypeB";
        }
    }
}