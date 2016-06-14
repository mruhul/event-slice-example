using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Src.Features.Home
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        } 
    }
}
