using System;
using System.Collections.Generic;

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
                throw new Exception("1");
            }
            catch (Exception e)
            {
                throw new Exception("2");
            }
            finally
            {
                // throw new Exception("3");
            }
        }
        static void Main(string[] args)
        {
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


            Console.ReadKey();
            object o = 26;

            byte s = (byte)o;

            Console.WriteLine(s);
        }
    }
}
