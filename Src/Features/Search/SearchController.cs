using System.Threading.Tasks;
using Bolt.RequestBus;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Search
{
    [Route("books")]
    public class SearchController : Controller
    {
        private readonly IRequestBus bus;

        public SearchController(IRequestBus bus)
        {
            this.bus = bus;
        }

        [Route("{category}")]
        public async Task<IActionResult> Index([FromRoute]SearchPageRequestedEvent eEvent)
        {
            await bus.PublishAsync(eEvent);

            return View();
        }
    }
}
