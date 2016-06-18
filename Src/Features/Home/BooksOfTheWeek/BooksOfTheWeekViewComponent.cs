using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Home.BooksOfTheWeek
{
    public class BooksOfTheWeekViewComponent : ViewComponent
    {
        private readonly IBooksOfTheWeekProvider provider;

        public BooksOfTheWeekViewComponent(IBooksOfTheWeekProvider provider)
        {
            this.provider = provider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = provider.Get();

            return View("~/Features/Home/BooksOfTheWeek/Views/BooksOfTheWeek.cshtml", vm);
        } 
    }
}
