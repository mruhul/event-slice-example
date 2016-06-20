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
                    Id = "22816087",
                    Title = "Seveneves",
                    Image = "https://d.gr-assets.com/books/1449142000l/22816087.jpg",
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
        
    }


    public class BookDto
    {
        public string Id { get; set; } 
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }

        public bool IsSaved { get; set; }
    }

    
}
