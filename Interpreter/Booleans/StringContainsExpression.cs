

// интерфейс интерпретатора
using Interpreter;

namespace Booleans
{
    class StringContainsExpression : IExpression<bool>
    {
        IExpression<string> _sourceExpression;
        IExpression<string> _subExpression;

        public StringContainsExpression(IExpression<string> sourceExpression, IExpression<string> subExpression)
        {
            _sourceExpression = sourceExpression;
            _subExpression = subExpression;
        }

        public bool Interpret(Context context)
        {
            return _sourceExpression.Interpret(context).Contains(_subExpression.Interpret(context));
        }
    }
}