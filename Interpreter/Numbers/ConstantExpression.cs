using Interpreter;

namespace Numbers
{
    class ConstantExpression : IExpression<long>
    {
        long _value; // значение
        public ConstantExpression(long value)
        {
            _value = value;
        }
        public long Interpret(Context context)
        {
            return _value;
        }
    }
}
