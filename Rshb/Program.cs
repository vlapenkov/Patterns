using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Running;

namespace Rshb
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
    }

    public class Manager : Employee
    {
        public List<Employee> Employees { get; set; }
    }

    public abstract class Base
    {
        protected Base()
        {
            Console.WriteLine("Run Base");
            Console.WriteLine(Foo());
        }
        protected virtual int Foo()
        {
            return 1;
        }
    }

    public class Foo
    {
        public event EventHandler Event = delegate { };
        public void RaiseEvent() { Event(this, EventArgs.Empty); }
    }

    public struct FooHandler
    {
        public int Count;
        public void Handle(object s, EventArgs e) { ++Count; }
    }



    public class Derived : Base
    {
        private readonly Random _rnd;
        public Derived()
        {
            Console.WriteLine("Run Derived");
            _rnd = new Random();
        }
        protected override int Foo()
        {
            return _rnd.Next(0, 10);
        }
    }
    class Program
    {
        public static void TrhowException()
        {
            try
            {
                throw new NullReferenceException("1");
            }
            catch (NullReferenceException e)
            {
                throw new Exception("11");
            }

            catch (Exception e)
            {
                throw new Exception("2");
            }
            finally
            {
                Console.WriteLine("finally inner");
               // throw new Exception("3");
            }
        }
        static void Main(string[] args)
        {
            
            BenchmarkRunner.Run<StringTest>();
            
            return;
            string path = "c:\\temp\\1.txt";

            string str = "";
            var str1 = File.ReadAllText(path);
            Console.WriteLine(str1);
           string[] strings = { "aa", "bb", "cc", "dd", "dd" };
           
            var dict = strings.GroupBy(x => x).ToDictionary(x => x, x => x.ToArray());
            Console.WriteLine(dict);
            
            // чтение из файла
            // using (FileStream fstream = File.OpenRead(path))
            // {
            //     // выделяем массив для считывания данных из файла
            //     byte[] buffer = new byte[fstream.Length];
            //     // считываем данные
            //      fstream.Read(buffer, 0, buffer.Length);
            //     // декодируем байты в строку
            //     string textFromFile = Encoding.Default.GetString(buffer);
            //     Console.WriteLine($"Текст из файла: {textFromFile}");
            // }
            Console.WriteLine(str);

return;
            //Employee[] employees = {
            //    new Employee { Age = 10, Name = "Vas", Position = "top" },
            //    new Employee { Age = 20, Name = "Test", Position = "top" },
            //    new Employee { Age = 30, Name = "Ton", Position = "top" } ,
            //    new Employee { Age = 40, Name = "Yes", Position = "top" },
            //    new Employee { Age = 50, Name = "Ton", Position = "top" } ,
            //};

            //var dictEmployees = employees.GroupBy(x => x.Name).ToDictionary(x => x, x => x.Sum(empl => empl.Age));

            //Console.WriteLine(dictEmployees);


            //var c = new Foo();
            //var handler = new FooHandler();
            //c.Event += handler.Handle;
            //c.RaiseEvent();
            //Console.WriteLine(handler.Count);

          

          

            try
            {
                TrhowException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally {
                Console.WriteLine("message handled");
            }


            Console.ReadKey();
            object o = 26;

            byte s = (byte)o;

            Console.WriteLine(s);
        }
    }
}
