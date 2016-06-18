using System.Threading.Tasks;
using Bolt.RequestBus;
using BookWorm.Web.Features.Shared.Events;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Details
{
    [Route("[controller]")]
    public class DetailsController : Controller
    {
        private readonly IRequestBus bus;

        public DetailsController(IRequestBus bus)
        {
            this.bus = bus;
        }

        [Route("{Id}")]
        public async Task<IActionResult> Index(DetailsQuery query)
        {
            var taskGetDetails = bus.SendAsync<DetailsQuery,DetailsViewModel>(query);

            await Task.WhenAll(taskGetDetails, bus.PublishAsync(new DetailsPageRequestedEvent()));

            var response = taskGetDetails.Result;

            if(response.Value == null) return Redirect("~/");

            return View(response.Value);
        } 
    }

    public class DetailsPageRequestedEvent : IEvent, IPageRequestedEvent
    {
    }
}
