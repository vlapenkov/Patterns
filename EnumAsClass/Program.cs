// See https://aka.ms/new-console-template for more information
using EnumAsClass;

Console.WriteLine("Hello, World!");


CardType[] values = new[] { CardTypeDerived.Amex, CardType.MasterCard , CardTypeDerived.Sber };

CardType[] values2 = new[] { CardTypeDerived.Amex, CardType.MasterCard, CardTypeDerived.Sber };

var result1 =values.Concat(values2).ToArray();

var result2 = values.Union(values2).ToArray();

Console.WriteLine();

