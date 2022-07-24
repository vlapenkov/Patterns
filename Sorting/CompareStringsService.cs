using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    static class CompareStringsService
    {
        public static bool Compare(this IEnumerable<char> str1, IEnumerable<char> str2)
        {
            var enumerator1 = str1.GetEnumerator();

            var enumerator2 = str2.GetEnumerator();

            while (enumerator1.MoveNext())
            {

                if (!enumerator2.MoveNext()) return false;

                if (enumerator1.Current != enumerator2.Current)
                    return false;

            }
            if (enumerator2.MoveNext()) return false;

            return true;
        }
    }
}
