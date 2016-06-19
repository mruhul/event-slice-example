using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Src.Features.Shared.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Features/Shared/Header/Views/Header.cshtml");
        } 
    }
}
