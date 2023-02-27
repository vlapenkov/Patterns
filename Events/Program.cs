namespace DotNetDesignPatternDemos.Behavioral.Observer

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

    public class Demo

    {

        static async Task Main()

        {

            var person = new Person();

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