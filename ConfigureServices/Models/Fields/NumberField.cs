namespace ConfigureServices.Models.Fields
{
    public class NumberField : BaseField
    {

        public NumberField(string type, int? value) : base(type)
        {
            Value = value;
        }
        public int? Value { get; set; }
    }
}
