using ConfigureServices.Models.Fields;
using System;
using System.Collections.Generic;

namespace ConfigureServices.Models.Wrappers
{
    public class FieldWriterFactory
    {
        /// <summary>
        /// Фабричный метод для создания типа IFieldWriter
        /// </summary>       
        public static IFieldWriter Create(BaseField field)
        {

            var dict = new Dictionary<Type, Func<IFieldWriter>>
            {
                [typeof(TextField)] = () => new TextFieldWriter((TextField)field),
                [typeof(NumberField)] = () => new NumberFieldWriter((NumberField)field),
                [typeof(MultipleTextField)] = () => new MultipleTextFieldWriter((MultipleTextField)field),

            };

            var func = dict[field.GetType()];

            return func();

        }
    }
}
