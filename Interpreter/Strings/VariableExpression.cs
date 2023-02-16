

// интерфейс интерпретатора
using Interpreter;

namespace Strings
{
    class VariableExpression : IExpression<string>
    {
        string name; // имя переменной


        public VariableExpression(string variableName)
        {
            name = variableName;
        }

        public string Interpret(Context context)
        {
            return context.GetStringVariable(name);
        }
    }
}