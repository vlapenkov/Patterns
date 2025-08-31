using System;
using System.IO;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Rshb;

[MemoryDiagnoser]
public class FileReadTest
{
    string path = "c:\\temp\\1.txt";
    
    [Benchmark]
    public void ReadAllText()
    {
        var str1 = File.ReadAllText(path);
        Console.WriteLine($"Текст из файла: {str1}");
    }
    
    [Benchmark]
    public void FromStream()
    {
        using (FileStream fstream = File.OpenRead(path))
        {
            // выделяем массив для считывания данных из файла
            byte[] buffer = new byte[fstream.Length];
            // считываем данные
             fstream.Read(buffer, 0, buffer.Length);
            // декодируем байты в строку
            string textFromFile = Encoding.Default.GetString(buffer);
            Console.WriteLine($"Текст из файла: {textFromFile}");
        }
    }
}