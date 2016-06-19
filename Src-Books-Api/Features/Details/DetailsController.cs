using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.BooksApi
{
    [Route("v1/books")]
    public class DetailsController : Controller
    {
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            await Task.Delay(200);

            return Ok(new BookDetailsDto{
                Id = id,
                Title = "The Ice Twins", 
                Author = "S.K. Tremayne",
                Price = 45.67m,
                Image = "https://d.gr-assets.com/books/1415872674l/23553419.jpg",
                ISBN = "0007563035",
                Details = @"A year after one of their identical twin daughters, Lydia, dies in an accident, Angus and Sarah Moorcraft move to the tiny Scottish island Angus inherited from his grandmother, hoping to put together the pieces of their shattered lives.
But when their surviving daughter, Kirstie, claims they have mistaken her identity—that she, in fact, is Lydia—their world comes crashing down once again.
As winter encroaches, Angus is forced to travel away from the island for work, Sarah is feeling isolated, and Kirstie (or is it Lydia?) is growing more disturbed. When a violent storm leaves Sarah and her daughter stranded, Sarah finds herself tortured by the past—what really happened on that fateful day one of her daughters died?"
            });   
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