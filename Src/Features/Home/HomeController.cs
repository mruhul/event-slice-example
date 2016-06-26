using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Home
{
    public class HomeController : Controller
    {
        private readonly IRequestBus bus;
        private readonly ILogger logger;

        public HomeController(IRequestBus bus, ILogger logger)
        {
            this.bus = bus;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            logger.Trace("Start requesting home page...");

            await bus.PublishAsync(new HomePageRequestedEvent());

            return View();
        } 
    }
}
