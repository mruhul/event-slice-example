using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BookWorm.Web.Features.Shared.SavedBooks;

namespace BookWorm.Web.Features.Home.CategoryMenu
{
    public class LatestBooksViewComponent : ViewComponent
    {
        private readonly ILatestBooksProvider provider;

        public LatestBooksViewComponent(ILatestBooksProvider provider)
        {
            this.provider = provider;
        }
        

        public IViewComponentResult Invoke()
        {
            var vm = provider.Get();

            return View("~/Features/Home/LatestBooks/Views/LatestBooks.cshtml", vm);
        } 
    }
}
