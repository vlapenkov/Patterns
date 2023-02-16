

// интерфейс интерпретатора
using Interpreter;


namespace Numbers
{
    class SubtractExpression : IExpression<long>
    {
        IExpression<long> leftExpression;
        IExpression<long> rightExpression;

        public SubtractExpression(IExpression<long> left, IExpression<long> right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public long Interpret(Context context)
        {

            return leftExpression.Interpret(context) - rightExpression.Interpret(context);
        }
    }
}
