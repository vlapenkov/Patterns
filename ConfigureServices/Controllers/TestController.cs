using ConfigureServices.Models.Fields;
using ConfigureServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConfigureServices
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IBaseTypeFactory _baseTypeFactory;

        AutoResetEvent waitHandler = new AutoResetEvent(true);



        public TestController(IBaseTypeFactory baseTypeFactory)
        {
            _baseTypeFactory = baseTypeFactory;
        }


        [HttpGet("Lock")]
        public async Task Lock()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;

            waitHandler.WaitOne();

            Console.WriteLine($"before lock {threadId} {DateTime.Now}");

            await Task.Delay(10_000).ConfigureAwait(false);

            Console.WriteLine($"after lock {threadId} {DateTime.Now}");

            waitHandler.Set();
        }


        [HttpGet("Delay")]
        public async Task GetDelay()
        {
            Console.WriteLine("Thread is:" + Thread.CurrentThread.ManagedThreadId + " " + Thread.CurrentThread.IsBackground + " " + Thread.CurrentThread.IsThreadPoolThread);

            await Task.Delay(2_000).ConfigureAwait(false);

            Console.WriteLine("Thread is:" + Thread.CurrentThread.ManagedThreadId + " " + Thread.CurrentThread.IsBackground + " " + Thread.CurrentThread.IsThreadPoolThread);
        }

        [HttpGet("Throw")]
        public IActionResult Throw()
        {

            try
            {
                Console.WriteLine("try outer");
                try
                {
                    Console.WriteLine("try inner");
                    throw new Exception("Some exception");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("catch inner");
                    throw new Exception();
                }
                finally
                {
                    Console.WriteLine("finally inner");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("catch outer");
                //   throw;

            }
            finally
            {
                Console.WriteLine("finally outer");
            }

            Console.WriteLine("end");

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<BaseField> model)
        {
            return Ok(model);
        }


    }
}
