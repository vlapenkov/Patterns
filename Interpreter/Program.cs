

// интерфейс интерпретатора
using Interpreter;
using Numbers;

class Program
{


    static void Main(string[] args)
    {

        Context context = new Context();

        context.SetVariable("article", "article12345");

        var expression = new Strings.ConcatExpression(
            new Strings.VariableExpression("article1"),
            new Strings.ConstantExpression(" "),
            new Strings.ConstantExpression("Hello"),
            new Strings.ConstantExpression(" ") ,
            new Strings.ConstantExpression("World!"));

        Console.WriteLine(expression.Interpret(context));

        Console.Read();
    }

}
