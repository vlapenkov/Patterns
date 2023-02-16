using Interpreter;

namespace Strings
{
    class ConstantExpression : IExpression<string>
    {
        string _value; // имя переменной
        public ConstantExpression(string value)
        {
            _value = value;
        }
        public string Interpret(Context context)
        {
            return _value;
        }
    }
}
