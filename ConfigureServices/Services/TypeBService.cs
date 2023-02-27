using ConfigureServices.Models;

namespace ConfigureServices
{
    internal class TypeBService : ITypeService
    {
        public string Name { get; set; } = "TypeB";
        public override string ToString()
        {
            return "TypeB";
        }

        public string DoSomething() => "TypeBService";
    }
}