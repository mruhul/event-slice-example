using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Shared.CategoryMenu
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryMenuProvider provider;

        public CategoryMenuViewComponent(ICategoryMenuProvider provider)
        {
            this.provider = provider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = provider.Get();

            return View("~/Features/Shared/CategoryMenu/Views/CategoryMenu.cshtml", vm);
        } 
    }
}
