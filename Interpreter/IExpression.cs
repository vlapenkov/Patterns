namespace Interpreter
{
    interface IExpression<T>
    {
        T Interpret(Context context);
    }
}
