using System;
using System.Threading.Tasks;

namespace Delegates
{

    public class SampleEventArgs : EventArgs
    {
        public string Text { get; set; } // readonly
    }

    public class Publisher
    {
        // Declare the delegate (if using non-generic pattern).
        public delegate void SampleEventHandler(object sender, SampleEventArgs e);

        // Declare the event.
        public event EventHandler<SampleEventArgs> SampleEvent;

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void RaiseSampleEvent(string key)
        {
            // Raise the event in a thread-safe manner using the ?. operator.
            SampleEvent?.Invoke(this, new SampleEventArgs { Text = $"Аргументы {key}" });
        }

        public void CheckAndRaise(string key) { if (key == "i") RaiseSampleEvent(key); }
    }



    class Program
    {
        private string _content;

        public delegate int Operation(int x, int y);

        static int Sum(int x, int y) => x + y;
        static int Subtract(int x, int y) => x - y;
        static int Multiply(int x, int y) => x * y;

        static async Task Main(string[] args)
        {
            try
            {
                GetPageAsync("");
            }
            catch
            {
                Console.WriteLine();
            }

            Publisher publisher = new Publisher();

            publisher.SampleEvent += Publisher_SampleEvent;

            var key = Console.ReadLine();

            publisher.CheckAndRaise(key);

            ;

            Console.ReadKey();

            return;
            Console.WriteLine("Enter operation");



            Operation operation = key switch
            {
                "+" => Sum,
                "-" => Subtract,
                "*" => Multiply,
                "/" => (x, y) => x / y
            };

            Console.WriteLine("result is" + operation(5, 5));

            Console.ReadLine();
        }

        private static async void Publisher_SampleEvent(object sender, SampleEventArgs e)
        {
            Console.WriteLine("Raised event " + e.Text);

        }

        private static async void GetPageAsync(string url)
        {
            throw new Exception();
        }

        //public void PrintLenght()
        //{
        //    try
        //    {
        //        this.GetPageAsync("http://ya.ru");
        //        Console.WriteLine("Content length: {0}", this._content.Length);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
    }
}
