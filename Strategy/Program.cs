// See https://aka.ms/new-console-template for more information
using Strategy;

Console.WriteLine("Hello, World!");

var doMethod = new StrategyPerformer().TaskDoMethod;

var res = await doMethod(async () =>
{
    Console.WriteLine("Some output before");
    await Task.Delay(1000);
    Console.WriteLine("Some output after");
    return new Result() { Success = true };
});




Console.WriteLine("Success is " +res.Success);

Console.ReadKey();