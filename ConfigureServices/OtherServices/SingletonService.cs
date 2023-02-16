using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace ConfigureServices.OtherServices
{

    internal class SingletonService : IDisposable
    {
        public class Entity
        {
            public int id { get; set; }
            public string title { get; set; }
        }

        private HttpClient _httpClient = new HttpClient();
        private Dictionary<int, string> dictionary;
        private static Lazy<SingletonService> instance = new Lazy<SingletonService>(() => new SingletonService());

        public Dictionary<int, string> Data => dictionary;
        private SingletonService()
        {
            var result = _httpClient.GetStringAsync("https://my-json-server.typicode.com/typicode/demo/posts").GetAwaiter().GetResult();

            var data = JsonSerializer.Deserialize<IEnumerable<Entity>>(result);

            Console.WriteLine("call ctor SingletonService");

            dictionary = data.ToDictionary(x => x.id, x => x.title);
        }


        public static SingletonService Instance => instance.Value;

        public void Dispose()
        {
            Console.WriteLine("befire dispose");
            _httpClient.Dispose();
        }
    }
}