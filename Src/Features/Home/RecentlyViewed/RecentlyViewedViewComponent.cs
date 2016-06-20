using BookWorm.Web.Features.Shared.SavedBooks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookWorm.Web.Features.Home.RecentlyViewed
{
    public class RecentlyViewedViewComponent : ViewComponent
    {
        private IRecentlyViewedProvider provider;
        private readonly ISavedItemsProvider savedItemsProvider;

        public RecentlyViewedViewComponent(IRecentlyViewedProvider provider, ISavedItemsProvider savedItemsProvider)
        {
            this.provider = provider;
            this.savedItemsProvider = savedItemsProvider;
        }

        public IViewComponentResult Invoke()
        {
            var savedItems = savedItemsProvider.Get();

            var vm = provider.Get().Select(x =>
            {
                x.IsSaved = savedItems?.Any(id => x.Id == id) ?? false;
                return x;
            });

            return View("~/Features/Home/RecentlyViewed/Views/RecentlyViewed.cshtml", vm);
        } 
    }
}