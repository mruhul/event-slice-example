using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWorm.BooksApi.Features.Shared;
using Microsoft.AspNetCore.Mvc;

namespace  BookWorm.BooksApi.Features.Cart
{
    [Route("v1/[controller]")]
    public class CartController : Controller
    {
        private static object _lock = new object();
        private static ICollection<CartItemDto> items;

        [Route("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            await Task.Delay(130);

            if (items != null) return Ok(items);

            lock (_lock)
            {
                if (items != null) return Ok(items);


                var rnd = new Random();

                items = BookData.GetAll()
                    .Select(x => new { Book = x, Rnd = rnd.Next(1, 100) })
                    .OrderBy(x => x.Rnd)
                    .Take(rnd.Next(3,7))
                    .Select(
                        x => new CartItemDto
                        {
                            Quantity = rnd.Next(1, 4),
                            Price = x.Book.Price,
                            BookId = x.Book.Id,
                            Title = x.Book.Title
                        }).ToList();
            }

            return Ok(items);
        } 
    }

    public class CartItemDto
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
