using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm.BooksApi.Features.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookWorm.BooksApi
{
    [Route("v1/books/featured")]
    public class FeaturedBooksController : Controller
    {
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Featured()
        {
            await Task.Delay(100);

            return Ok(BookData.GetAll().OrderByDescending(x => x.Popularity).Take(4));

            var result = new List<BookListItemDto>
            {
                new BookListItemDto
                {
                    Id = "22522808",
                    Title = "Trigger Warning",
                    Image = "https://d.gr-assets.com/books/1415036119l/22522808.jpg",
                    Price = 23.56m,
                    Author = "Neil Gaiman"
                },new BookListItemDto
                {
                    Id = "22055262",
                    Title = "A Darker Shade of Magic",
                    Image = "https://d.gr-assets.com/books/1400322851l/22055262.jpg",
                    Price = 39.50m,
                    Author = "V.E. Schwab"
                },new BookListItemDto
                {
                    Id = "16065004",
                    Title = "Shadows of Self",
                    Image = "https://d.gr-assets.com/books/1435053013l/16065004.jpg",
                    Price = 25.99m,
                    Author = "Brandon Sanderson"
                },new BookListItemDto
                {
                    Id = "17333171",
                    Title = "Magic Shifts",
                    Image = "https://d.gr-assets.com/books/1414091260l/17333171.jpg",
                    Price = 23.56m,
                    Author = "Ilona Andrews"
                }
            };


            return Ok(result);
        }
    }
}