using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Src.Features.Home.CategoryMenu
{
    public class LatestBooksViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Features/Home/LatestBooks/Views/LatestBooks.cshtml");
        } 
    }
}
