using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.BooksApi
{
    [Route("v1/books/latest")]
    public class LatestBooksController : Controller
    {
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Latest()
        {
            await Task.Delay(160);

            var result = new List<BookListItemDto>
            {
                new BookListItemDto
                {
                    Id = "24817626",
                    Title = "Go Set a Watchman",
                    Image = "https://d.gr-assets.com/books/1451442088l/24817626.jpg",
                    Price = 23.56m,
                    Author = "Harper Lee"
                },new BookListItemDto
                {
                    Id = "24941288",
                    Title = "After You",
                    Image = "https://d.gr-assets.com/books/1425496284l/24941288.jpg",
                    Price = 39.50m,
                    Author = "Jojo Moyes"
                },new BookListItemDto
                {
                    Id = "22875451",
                    Title = "The Royal We",
                    Image = "https://d.gr-assets.com/books/1421107274l/22875451.jpg",
                    Price = 25.99m,
                    Author = "Heather Cocks"
                },new BookListItemDto
                {
                    Id = "22822858",
                    Title = "A Little Life",
                    Image = "https://d.gr-assets.com/books/1446469353l/22822858.jpg",
                    Price = 23.56m,
                    Author = "Hanya Yanagihara"
                }
            };


            return Ok(result);
        }
    }    

    public class BookListItemDto
    {
        public string Id { get; set; } 
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
    }
}

