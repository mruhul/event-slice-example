using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BookWorm.BooksApi
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
                .UseUrls("http://localhost:5051")
                .UseWebRoot(Directory.GetCurrentDirectory() + "\\public")
                .Build();

            host.Run();
        }
    }
}
