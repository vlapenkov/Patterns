

// интерфейс интерпретатора
using Interpreter;

namespace Strings
{
    class SubstringExpression : IExpression<string>
    {
        IExpression<string> _leftExpression;
        int _numberOfSymbols;



        public SubstringExpression(IExpression<string> left, int numberOfSymbols)
        {
            _leftExpression = left;
            _numberOfSymbols = numberOfSymbols;
        }

        public string Interpret(Context context)
        {
            return _leftExpression.Interpret(context).Substring(0, _numberOfSymbols);
        }
    }

}