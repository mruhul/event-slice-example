using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Src.Features.Home
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("")]
        public Task<IActionResult> Index()
        {
            return Task.FromResult(View() as IActionResult);
        } 
    }
}
