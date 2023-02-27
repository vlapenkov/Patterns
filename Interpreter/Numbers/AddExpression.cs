

using Interpreter;


namespace Numbers
{
    class AddExpression : IExpression<long>
    {
        IExpression<long>[] _expressions;

        public AddExpression(params IExpression<long>[] expressions)
        {
            _expressions = expressions;
        }

        public long Interpret(Context context)
        {
            return _expressions.Sum(x => x.Interpret(context));
        }
    }
}
