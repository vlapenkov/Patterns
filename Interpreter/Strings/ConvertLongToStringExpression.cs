

// интерфейс интерпретатора
using Interpreter;

namespace Strings
{
    class ConvertLongToStringExpression : IExpression<string>
    {

        IExpression<long> _leftExpression;


        public ConvertLongToStringExpression(IExpression<long> left)
        {
            _leftExpression = left;

        }

        public string Interpret(Context context)
        {
            return _leftExpression.Interpret(context).ToString();
        }
    }
}
