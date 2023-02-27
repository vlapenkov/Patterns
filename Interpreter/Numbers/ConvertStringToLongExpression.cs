

// интерфейс интерпретатора
using Interpreter;

namespace Numbers
{
    class ConvertStringToLongExpression : IExpression<long>
    {

        IExpression<string> _leftExpression;


        public ConvertStringToLongExpression(IExpression<string> left)
        {
            _leftExpression = left;

        }
        public long Interpret(Context context)
        {

            return long.Parse(_leftExpression.Interpret(context));
        }
    }
}
