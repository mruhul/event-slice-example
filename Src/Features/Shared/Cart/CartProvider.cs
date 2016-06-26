using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.Stores;

namespace BookWorm.Web.Features.Shared.Cart
{
    public interface ICartProvider
    {
        CartDto Get();
        void Set(CartDto value);
    }

    [AutoBind]
    public class CartProvider : ICartProvider
    {
        private const string Key = "CartProvider:Get";
        private readonly IContextStore store;

        public CartProvider(IContextStore store)
        {
            this.store = store;
        }

        public CartDto Get()
        {
            return store.Get<CartDto>(Key) ?? new CartDto();
        }

        public void Set(CartDto value)
        {
            store.Set(Key, value);
        }
    }

    public class CartDto
    {
        public CartDto(IEnumerable<CartItemDto> items)
        {
            Items = items?.ToList() ?? new List<CartItemDto>();
        }

        public CartDto()
            : this(new CartItemDto[] {})
        {
        }

        public ICollection<CartItemDto> Items { get; }
        public decimal Subtotal => Items.Sum(x => x.Subtotal);
        public bool IsEmpty => Items.Count == 0;
    }

    public class CartItemDto
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Subtotal => Price*Quantity;
    }
}
