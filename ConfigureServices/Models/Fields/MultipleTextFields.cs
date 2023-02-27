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
