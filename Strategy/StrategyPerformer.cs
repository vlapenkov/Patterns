using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Result
    {
       public bool Success { get; set; } = false;
    }
    public class StrategyPerformer
    {
        public async Task<Result> TaskDoMethod(Func<Task<Result>> method) {

            Task<Result> result =   method();

            return await result;
        }
    }
}
