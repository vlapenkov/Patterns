using ConfigureServices.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureServices.Models.Wrappers
{
    public static class FieldWriterFactory
    {
        public static IFieldWriter Create(BaseField field)
        {

            var dict = new Dictionary<Type, Func<IFieldWriter>>
            {
                [typeof(TextField)] = () => new TextFieldWriter((TextField)field),
                [typeof(NumberField)] = () => new NumberFieldWriter((NumberField)field),
                [typeof(MultipleTextField)] = () => new MultipleTextFieldWriter((MultipleTextField)field),

            };

            var res = dict[field.GetType()];

            return res();

        }
    }
}
