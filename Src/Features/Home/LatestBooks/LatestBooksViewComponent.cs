using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BookWorm.Web.Features.Shared.SavedBooks;

namespace BookWorm.Web.Features.Home.CategoryMenu
{
    public class LatestBooksViewComponent : ViewComponent
    {
        private readonly ILatestBooksProvider provider;
        private readonly ISavedItemsProvider savedItemsProvider;

        public LatestBooksViewComponent(ILatestBooksProvider provider, ISavedItemsProvider savedItemsProvider)
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

            return View("~/Features/Home/LatestBooks/Views/LatestBooks.cshtml", vm);
        } 
    }
}
