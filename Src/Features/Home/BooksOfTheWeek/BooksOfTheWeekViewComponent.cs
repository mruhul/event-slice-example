using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Src.Features.Home.CategoryMenu
{
    public class BooksOfTheWeekViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Features/Home/BooksOfTheWeek/Views/BooksOfTheWeek.cshtml");
        } 
    }
}
