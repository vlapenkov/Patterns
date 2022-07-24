using System;
using System.Linq;

namespace Iterator
{
    class A
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var root = new BaseTreeNode<A>(new A { Id = 1, Name = "A" });

            root.AddChild(new BaseTreeNode<A>(new A { Id = 2, Name = "B" }));

            var child1 = new BaseTreeNode<A>(new A { Id = 3, Name = "C" });

            root.AddChild(child1);

            child1.AddChild(new BaseTreeNode<A>(new A { Id = 3, Name = "D" }));

            var child2 = new BaseTreeNode<A>(new A { Id = 3, Name = "E" });

            child1.AddChild(child2);
            child2.AddChild(new BaseTreeNode<A>(new A { Id = 3, Name = "F" }));

            var iterator = new TreeIterator<A>(root);

            var elements = iterator.GetElements();

            var arrayElements = elements.ToArray();

            Console.WriteLine(arrayElements.Length);

        }
    }
}
