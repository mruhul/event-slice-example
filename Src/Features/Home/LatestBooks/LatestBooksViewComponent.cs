using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookWorm.Web.Features.Home.CategoryMenu
{
    public class LatestBooksViewComponent : ViewComponent
    {
        private readonly ILatestBooksProvider provider;

        public LatestBooksViewComponent(ILatestBooksProvider provider)
        {
            this.provider = provider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = provider.Get();

            return View("~/Features/Home/LatestBooks/Views/LatestBooks.cshtml", books);
        } 
    }
}
