

// интерфейс интерпретатора
using Interpreter;

namespace Booleans
{
    class ConstantExpression : IExpression<bool>
    {
        bool _value; // имя переменной
        public ConstantExpression(bool value)
        {
            _value = value;
        }
        public bool Interpret(Context context)
        {
            return _value;
        }
    }
}
