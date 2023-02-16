

// интерфейс интерпретатора
using Interpreter;
using Numbers;

class Program2
{


    static void Main2(string[] args)
    {



        Context context = new Context();
        // определяем набор переменных
        int x = 50000;
        int y = 80000;
        int z = 20000;

        // добавляем переменные в контекст
        context.SetVariable("x", x);
        context.SetVariable("y", y);
        context.SetVariable("z", z);



        context.SetVariable("str1", "string1");
        context.SetVariable("str2", "str");

        var resultBool = new Booleans.StringContainsExpression(new Strings.VariableExpression("str1"), new Strings.VariableExpression("str2"));

        Console.WriteLine(resultBool.Interpret(context));

        var resultString = new Strings.StringIIFExpression(resultBool, new Strings.VariableExpression("str1"), new Strings.VariableExpression("str2"));

        Console.WriteLine(resultString.Interpret(context));

        Console.ReadKey();

        // создаем объект для вычисления выражения x + y - z
        IExpression<long> expression = new Numbers.SubtractExpression(
            new Numbers.AddExpression(
                new Numbers.VariableExpression("x"), new Numbers.VariableExpression("y")
            ),
            new Numbers.ConstantExpression(100)
        );



        var bce = new Booleans.CompareNumbersExpression(expression, new Numbers.VariableExpression("y"), Sign.More);

        Console.WriteLine("результат: {0}", bce.Interpret(context));

        Console.WriteLine("результат: {0}", expression.Interpret(context));

        var ce = new Strings.SubstringExpression(new Strings.ConvertLongToStringExpression(expression), 3);




        string result = ce.Interpret(context);
        Console.WriteLine("результат: {0}", result);


        var resExpr = new Numbers.ConvertStringToLongExpression(ce);

        IExpression<long> expression2 =
           new AddExpression(
               new VariableExpression("x"), resExpr
           );

        Console.WriteLine("результат: {0}", expression2.Interpret(context));


        //        Console.WriteLine("результат: {0}", resultStr);

        Console.Read();
    }

}
