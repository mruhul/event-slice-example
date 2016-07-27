using BookWorm.Web.Features.Shared.SavedBooks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookWorm.Web.Features.Home.RecentlyViewed
{
    public class RecentlyViewedViewComponent : ViewComponent
    {
        private readonly IRecentlyViewedProvider provider;
        
        public RecentlyViewedViewComponent(IRecentlyViewedProvider provider, ISavedItemsProvider savedItemsProvider)
        {
            this.provider = provider;
        }

        public IViewComponentResult Invoke()
        {
            var vm = provider.Get();

            return View("~/Features/Home/RecentlyViewed/Views/RecentlyViewed.cshtml", vm);
        } 
    }
}