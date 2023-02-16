using System;
using System.IO;
using System.Text;

namespace Patterns
{

    class Program
    {


        static void Main(string[] args)
        {




            //var newList = Constructor.Compile<Func<int, IList<String>>>(typeof(List<String>));
            //var list = newList(100);

            // 2 кейс: создание из фабрики в которой Activator.CreateInstance
            var fileName = @"c:\3_Source\test1.txt";

            Stream fileStream = File.OpenRead(fileName);

            Stream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes("<html>"));

            using (var service = new StreamService(fileStream))
            {

                FileType fileType = service.GetFileType();

                var fileProcessor = MyFactory.Create(fileType, new Parameter { Type = "param1", Value = 10 }); ;

                var result = fileProcessor.Process(service.GetContent());

                Console.WriteLine(String.Join(',', result));
            }



            Console.ReadKey();
        }
    }
}
