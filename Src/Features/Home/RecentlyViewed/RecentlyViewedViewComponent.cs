using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BookWorm.Web.Features.Home.RecentlyViewed
{
    public class RecentlyViewedViewComponent : ViewComponent
    {
        private IRecentlyViewedProvider provider;

        public RecentlyViewedViewComponent(IRecentlyViewedProvider provider)
        {
            this.provider = provider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = provider.Get(); 

            return View("~/Features/Home/RecentlyViewed/Views/RecentlyViewed.cshtml", books);
        } 
    }
}