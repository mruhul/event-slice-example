using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Shared.LoginStatus
{
    public class LoginStatusViewComponent : ViewComponent
    {
        private ILoginStatusProvider provider;

        public LoginStatusViewComponent(ILoginStatusProvider provider)
        {
            this.provider = provider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = provider.Get();
            return View("~/Features/Shared/LoginStatus/Views/LoginStatus.cshtml", vm);
        } 
    }

    public class LoginStatusViewModel
    {
        public string Name {get; set;}
    }
}
