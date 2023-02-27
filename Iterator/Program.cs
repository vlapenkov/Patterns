using System;
using System.IO;
using System.Linq;
using static System.Console;

namespace Iterator
{
    class B {

        FileInfo _fi;

        int _res;

        public B(FileInfo fi, int res)
        {
            _fi = fi;
            _res = res;
        }
    }
    class A
    {
        public A(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; protected set; }

        public string Name { get; protected  set; } = default!;

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var b = new B(default!, default!);

            

            WriteLine("test1");

            var root = new BaseTreeNode<A>(new A ( 1, "A" ));

            root.AddChild(new BaseTreeNode<A>(new A (2, "B")));

            BaseTreeNode<A> child1 = new BaseTreeNode<A>(new A (3, "C"));

            root.AddChild(child1);

            child1.AddChild(new BaseTreeNode<A>(new A (3, "D")));

            var child2 = new BaseTreeNode<A>(new A (3, "E"));

            child1.AddChild(child2);
            child2.AddChild(new BaseTreeNode<A>(new A (3, "F")));

            var iterator = new TreeIterator<A>(root);

            var elements = iterator.GetElements();

            var arrayElements = elements.ToArray();

            Console.WriteLine(root);

            Console.ReadKey();

        }
    }
}
