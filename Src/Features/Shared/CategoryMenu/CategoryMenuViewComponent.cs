using System.Linq;
using System.Threading.Tasks;
using Bolt.Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Src.Features.Shared.CategoryMenu;

namespace BookWorm.Web.Features.Shared.CategoryMenu
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryMenuProvider provider;
        private readonly ICurrentCategoryProvider currentCategoryProvider;

        public CategoryMenuViewComponent(ICategoryMenuProvider provider, ICurrentCategoryProvider currentCategoryProvider)
        {
            this.provider = provider;
            this.currentCategoryProvider = currentCategoryProvider;
        }

        public IViewComponentResult Invoke()
        {
            var currentCategory = currentCategoryProvider.Get();
            var vm = provider.Get().Select(x =>
            {
                var urlFriendlyName = x.Name.ToSlug();
                return new CategoryMenuViewModel
                {
                    Count = x.Count,
                    Name = x.Name,
                    UrlFriendlyName = urlFriendlyName,
                    IsCurrent = currentCategory.NullSafe().IsSame(urlFriendlyName)
                };
            });

            return View("~/Features/Shared/CategoryMenu/Views/CategoryMenu.cshtml", vm);
        } 
    }

    public class CategoryMenuViewModel
    {
        public string UrlFriendlyName { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public bool IsCurrent { get; set; }
    }
}
