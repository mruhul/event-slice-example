using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Home.RecentlyViewed
{
    public class RecentlyViewedViewComponent : ViewComponent
    {
        private IRecentlyViewedProvider provider;

        public RecentlyViewedViewComponent(IRecentlyViewedProvider provider)
        {
            this.provider = provider;
        }

        public IViewComponentResult Invoke()
        {
            var books = provider.Get(); 

            return View("~/Features/Home/RecentlyViewed/Views/RecentlyViewed.cshtml", books);
        } 
    }
}