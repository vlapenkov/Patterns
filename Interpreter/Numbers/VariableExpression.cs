

// интерфейс интерпретатора
using Interpreter;


namespace Numbers
{
    class VariableExpression : IExpression<long>
    {
        string name; // имя переменной
        public VariableExpression(string variableName)
        {
            name = variableName;
        }
        public long Interpret(Context context)
        {
            return context.GetLongVariable(name);
        }
    }
}
