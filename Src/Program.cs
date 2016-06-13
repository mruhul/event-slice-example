using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BookStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();

            Console.WriteLine("Hello World!!");
        }
    }

    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return Content("Hello world this is attribute routing");
        }
    }
}
