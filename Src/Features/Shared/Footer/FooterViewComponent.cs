using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Src.Features.Shared.Footer
{
    public class FooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Features/Shared/Footer/Views/Footer.cshtml");
        }
    }
}
