

// интерфейс интерпретатора
using Interpreter;

namespace Booleans
{
    class CompareNumbersExpression : IExpression<bool>
    {
        IExpression<long> _leftExpression;
        IExpression<long> _rightExpression;
        Sign _sign;

        public CompareNumbersExpression(IExpression<long> leftExpression, IExpression<long> rightExpression, Sign sign)
        {
            _leftExpression = leftExpression;
            _rightExpression = rightExpression;
            _sign = sign;
        }

        public bool Interpret(Context context)
        {
            bool result = _sign switch

            {
                Sign.Equal => _leftExpression.Interpret(context) == _rightExpression.Interpret(context),
                Sign.More => _leftExpression.Interpret(context) > _rightExpression.Interpret(context),
                Sign.Less => _leftExpression.Interpret(context) < _rightExpression.Interpret(context),
                _ => throw new ArgumentOutOfRangeException(nameof(_sign), $"Not expected direction value: {_sign}"),
            };
            return result;
        }
    }
}
