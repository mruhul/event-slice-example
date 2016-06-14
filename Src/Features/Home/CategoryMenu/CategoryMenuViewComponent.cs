using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Src.Features.Home.CategoryMenu
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Features/Home/CategoryMenu/Views/CategoryMenu.cshtml");
        } 
    }
}
