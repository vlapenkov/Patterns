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

        public virtual void DoOne() { Console.WriteLine("1"); }
    }

    internal class B : A
    {
        public override void DoOne()
        { Console.WriteLine("2"); }
    }

    public class Demo

    {
        private static void Main()

        {

            A a = new B() as int;

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