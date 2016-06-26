using System.Threading.Tasks;
using BookWorm.Web.Features.Shared.Cart;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Shared.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICartProvider cartProvider;

        public HeaderViewComponent(ICartProvider cartProvider)
        {
            this.cartProvider = cartProvider;
        }

        public IViewComponentResult Invoke()
        {
            return View("~/Features/Shared/Header/Views/Header.cshtml",new HeaderViewModel
            {
                TotalItemsInCart = cartProvider.Get().Items?.Count ?? 0
            });
        } 
    }

    public class HeaderViewModel
    {
        public int TotalItemsInCart { get; set; }
    }
}
