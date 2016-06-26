using System.Linq;
using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using BookWorm.Web.Features.Shared.Events;
using BookWorm.Web.Features.Shared.SavedBooks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Details
{
    [Route("books")]
    public class DetailsController : Controller
    {
        private readonly IRequestBus bus;
        private readonly ISavedItemsProvider savedItemsProvider;
        private readonly ILogger logger;

        public DetailsController(IRequestBus bus, ISavedItemsProvider savedItemsProvider, ILogger logger)
        {
            this.bus = bus;
            this.savedItemsProvider = savedItemsProvider;
            this.logger = logger;
        }

        [Route("details/{id}/{title?}")]
        public async Task<IActionResult> Index(DetailsQuery query)
        {
            logger.Trace("Start requesting details page...");

            var taskGetDetails = bus.SendAsync<DetailsQuery,DetailsViewModel>(query);

            await Task.WhenAll(taskGetDetails, bus.PublishAsync(new DetailsPageRequestedEvent()));

            var response = taskGetDetails.Result;

            if(response.Value == null) return Redirect("~/");

            response.Value.IsSaved = savedItemsProvider.Get().Any(x => x == response.Value.Id);

            return View(response.Value);
        } 
    }

    public class DetailsPageRequestedEvent : IEvent, IPageRequestedEvent,  IRequireSavedItems
    {
    }
}
