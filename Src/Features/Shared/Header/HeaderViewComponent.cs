using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Src.Features.Shared.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Features/Shared/Header/Views/Header.cshtml");
        } 
    }
}
