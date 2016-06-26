using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Search
{
    [Route("books")]
    public class SearchController : Controller
    {
        private readonly IRequestBus bus;
        private readonly ILogger logger;

        public SearchController(IRequestBus bus, ILogger logger)
        {
            this.bus = bus;
            this.logger = logger;
        }

        [Route("{category}")]
        public async Task<IActionResult> Index([FromRoute]SearchPageRequestedEvent eEvent)
        {
            logger.Trace("Start requesting search page...");

            await bus.PublishAsync(eEvent);

            return View();
        }
    }
}
