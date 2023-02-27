using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    static class GuidGenerator
    {
        public static Guid[] GenerateSequence(int length = 100) {

           return Enumerable.Range(1, length).Select(p => Guid.NewGuid()).ToArray();
        }
        
    }
}
