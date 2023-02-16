using Interpreter;
using System.Text;

namespace Strings
{
    class ConcatExpression : IExpression<string>
    {
        IExpression<string>[] _expressions;

        public ConcatExpression(params IExpression<string>[] expressions)
        {
            _expressions = expressions;
        }

        public string Interpret(Context context)
        {
            StringBuilder sb = new();

            foreach (var item in _expressions)
            {
                sb.Append(item.Interpret(context));
            }

            return sb.ToString();
        }
    }
}
