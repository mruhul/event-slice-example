using System.Linq;
using BookWorm.Web.Features.Shared.SavedBooks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Home.BooksOfTheWeek
{
    public class BooksOfTheWeekViewComponent : ViewComponent
    {
        private readonly IBooksOfTheWeekProvider provider;
        private readonly ISavedItemsProvider savedItemsProvider;

        public BooksOfTheWeekViewComponent(IBooksOfTheWeekProvider provider, ISavedItemsProvider savedItemsProvider)
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


            return View("~/Features/Home/BooksOfTheWeek/Views/BooksOfTheWeek.cshtml", vm);
        } 
    }
}
