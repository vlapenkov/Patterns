using System;
using System.Linq;

namespace Sorting
{
    static class GuidGenerator
    {
        public static Guid[] GenerateSequence(int length = 100)
        {

            return Enumerable.Range(1, length).Select(p => Guid.NewGuid()).ToArray();
        }

    }
}
