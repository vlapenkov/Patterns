

// интерфейс интерпретатора
using Interpreter;

namespace Booleans
{
    class VariableExpression : IExpression<bool>
    {
        string name; // имя переменной
        public VariableExpression(string variableName)
        {
            name = variableName;
        }
        public bool Interpret(Context context)
        {
            return context.GetBoolVariable(name);
        }
    }
}
