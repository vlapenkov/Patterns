using System.Diagnostics.Metrics;

namespace Events

{
    public class FallsIllEventArgs : EventArgs
    {

        public string Address;

    }

    public class Person

    {

        public void CatchACold()

        {
            FallsIll(this, new FallsIllEventArgs { Address = "123 London Road" });

            //FallsIll?.Invoke(this,

            //new FallsIllEventArgs { Address = "123 London Road" });

        }

        public event EventHandler<FallsIllEventArgs> FallsIll;

    }

    internal class A
    {
        public int x ;
        public virtual void DoOne() { Console.WriteLine("1"); }
    }

    internal class B : A
    {
        public override void DoOne()
        { Console.WriteLine("2"); }
    }

    static class Closure
    {
        public static int glob = 0;
        public static Action MethodA()
        {
            int x = 0;

            return () =>
            {
                glob++;
                x++;
                Console.WriteLine($"glob is {glob}");
            };
        }
    }

    public class Demo

    {

        static Action CreateAction()

        {

            int count = 0;

            Action action = () =>

            {

                count++;

                Console.WriteLine("Count = {0}", count);

            };

            return action;

        }

        public static int x = 1; 
        private static int inner(int y) {
            int counter = 0;

            return x + y;
        }

        struct AA {
           public int x;
            public int y;
        }

        private static void Main()

        {

            ReadOnlySpan<char> span = new string("12345").AsSpan();

            A? aaa = new A { };

            AA aa = default(AA);

            unsafe {

                AA* aaStr = &aa;

                aaStr->x = 10;

               A* aPtr = &aaa;

                aPtr->x = 100;

                //ReadOnlySpan<char>* pStr = &span;

                //*pStr++ = 'a';

            }

            Closure.glob = 100;
            
          var inner11 =  Closure.MethodA();
            inner11();
            inner11();

            Closure.glob = 10;

            Console.ReadKey();
            
           

            var func1 = inner;

            x = 2;


            var func2 = inner;

            Console.WriteLine(func1(1).ToString() +" " +func1(1).ToString());

            int lim = 2;
            int[] arr =  { 1, 2, 3 };

           var query  = arr.Where(x => x == lim);

            lim= 3;

           var res = query.ToArray();

            A a = new B() ;

            a.DoOne();

            _ = Console.ReadKey();

            Person person = new();

            person.FallsIll += CallDoctor;



            person.CatchACold();
            Thread.Sleep(1000);


        }

        private static async void CallDoctor(object sender, FallsIllEventArgs eventArgs)

        {
            await Task.Delay(500);

            Console.WriteLine($"A doctor has been called to {eventArgs.Address}");

        }

    }

}