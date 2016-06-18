using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Api
{
    [Route("api/v1/books")]
    public class BooksApiController : Controller
    {
        [Route("latest")]
        [HttpGet]
        public async Task<IActionResult> Latest()
        {
            await Task.Delay(160);

            var result = new List<BookDto>
            {
                new BookDto
                {
                    Id = "24817626",
                    Title = "Go Set a Watchman",
                    Image = "https://d.gr-assets.com/books/1451442088l/24817626.jpg",
                    Price = 23.56m,
                    Author = "Harper Lee"
                },new BookDto
                {
                    Id = "24941288",
                    Title = "After You",
                    Image = "https://d.gr-assets.com/books/1425496284l/24941288.jpg",
                    Price = 39.50m,
                    Author = "Jojo Moyes"
                },new BookDto
                {
                    Id = "22875451",
                    Title = "The Royal We",
                    Image = "https://d.gr-assets.com/books/1421107274l/22875451.jpg",
                    Price = 25.99m,
                    Author = "Heather Cocks"
                },new BookDto
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

        [Route("featured")]
        [HttpGet]
        public async Task<IActionResult> Featured()
        {
            await Task.Delay(180);

            var result = new List<BookDto>
            {
                new BookDto
                {
                    Id = "22522808",
                    Title = "Trigger Warning",
                    Image = "https://d.gr-assets.com/books/1415036119l/22522808.jpg",
                    Price = 23.56m,
                    Author = "Neil Gaiman"
                },new BookDto
                {
                    Id = "22055262",
                    Title = "A Darker Shade of Magic",
                    Image = "https://d.gr-assets.com/books/1400322851l/22055262.jpg",
                    Price = 39.50m,
                    Author = "V.E. Schwab"
                },new BookDto
                {
                    Id = "16065004",
                    Title = "Shadows of Self",
                    Image = "https://d.gr-assets.com/books/1435053013l/16065004.jpg",
                    Price = 25.99m,
                    Author = "Brandon Sanderson"
                },new BookDto
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


        [Route("recent")]
        [HttpGet]
        public async Task<IActionResult> Recent()
        {
            await Task.Delay(150);

            var result = new List<BookDto>
            {
                new BookDto
                {
                    Id = "20697410",
                    Title = "Golden Son",
                    Image = "https://d.gr-assets.com/books/1461354417l/20697410.jpg",
                    Price = 23.56m,
                    Author = "Pierce Brown"
                },new BookDto
                {
                    Id = "22055262",
                    Title = "Seveneves",
                    Image = "https://d.gr-assets.com/books/1400322851l/22055262.jpg",
                    Price = 39.50m,
                    Author = "Neal Stephenson"
                },new BookDto
                {
                    Id = "25246752",
                    Title = "Binge",
                    Image = "https://d.gr-assets.com/books/1439787297l/25246752.jpg",
                    Price = 25.99m,
                    Author = "Tyler Oakley"
                },new BookDto
                {
                    Id = "20454635",
                    Title = "The Last American Vampire",
                    Image = "https://d.gr-assets.com/books/1407107369l/20454635.jpg",
                    Price = 23.56m,
                    Author = "Seth Grahame-Smiths"
                }
            };


            return Ok(result);
        }

        [Route("categories")]
        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            await Task.Delay(150);

            return Ok(new[]
            {
                new CategoryDto
                {
                    Name = "Fiction",
                    Count = 156
                },
                new CategoryDto
                {
                    Name = "Mystery & Thriller",
                    Count = 550
                },
                new CategoryDto
                {
                    Name = "Historical Fiction",
                    Count = 400
                },
                new CategoryDto
                {
                    Name = "Fantasy",
                    Count = 198
                },
                new CategoryDto
                {
                    Name = "Romance",
                    Count = 345
                },
                new CategoryDto
                {
                    Name = "Science Fiction",
                    Count = 365
                },
                new CategoryDto
                {
                    Name = "Horror",
                    Count = 245
                },
                new CategoryDto
                {
                    Name = "Humor",
                    Count = 35
                },
                new CategoryDto
                {
                    Name = "Nonfiction",
                    Count = 24
                },
                new CategoryDto
                {
                    Name = "Autobiography",
                    Count = 456
                }
            });
        } 
    }

    public class CategoryDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class BookDto
    {
        public string Id { get; set; } 
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
    }
}
