

// интерфейс интерпретатора
using Interpreter;

namespace Strings
{
    class StringIIFExpression : IExpression<string>
    {

        IExpression<bool> _predicateExpression;
        IExpression<string> _leftExpression;
        IExpression<string> _rightExpression;

        public StringIIFExpression(IExpression<bool> predicateExpression, IExpression<string> leftExpression, IExpression<string> rightExpression)
        {
            _predicateExpression = predicateExpression;
            _leftExpression = leftExpression;
            _rightExpression = rightExpression;
        }

        public string Interpret(Context context)
        {
            return _predicateExpression.Interpret(context) ? _leftExpression.Interpret(context) : _rightExpression.Interpret(context);
        }
    }
}
