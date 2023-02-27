namespace ConfigureServices.Models
{
    public class TypeAService : ITypeService
    {
        public int Id { get; set; }
        public override string ToString()
        {
            return "TypeA";
        }

        public string DoSomething() => "TypeAService";

    }
}
