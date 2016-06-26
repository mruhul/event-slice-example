using System.Linq;
using System.Threading.Tasks;
using BookWorm.BooksApi.Features.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.BooksApi
{
    [Route("v1/books")]
    public class DetailsController : Controller
    {
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            await Task.Delay(100);

            var book = BookData.GetAll().FirstOrDefault(x => x.Id == id);

            if (book == null) return NotFound();

            return Ok(book);
        }
    }
    public class BookDetailsDto
    {
        public string Id {get; set;}
        public string Title {get; set;}
        public string Author {get; set;}
        public string Image {get; set;}
        public decimal Price {get; set;}
        public string Details {get; set;}

        public string ISBN {get; set;}
        
    }
}