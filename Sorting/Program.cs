using System;
using System.Linq;

namespace Sorting
{
    class Program
    {

        public static void Main()
        {

            var sequence1 = GuidGenerator.GenerateSequence();

            var previtem = default(Guid);
            foreach (var item in sequence1)
            {
                if (item < previtem)

            }

            return;

            AClass a;

            a = new AClass { X = 10 };
            a.X = 100;

            var stringsArr1 = new[] { "one", "two", "three" };
            var stringsArr2 = new[] { "on", "etwot", "hree" };

            var arr1 = stringsArr1.AsEnumerable().SelectMany(x => x.AsEnumerable());
            var arr2 = stringsArr2.AsEnumerable().SelectMany(x => x.AsEnumerable());

            bool result = arr1.Compare(arr2);

            Console.WriteLine(result);

            Console.ReadKey();

            int[] arr = { 2, 7, 1, 9, 3, 5, 6, 8 };
            //InsertionSort ob = new InsertionSort();
            InsertionSort.Sort(arr);
            InsertionSort.PrintArray(arr);
            Console.ReadKey();
        }
    }
}
