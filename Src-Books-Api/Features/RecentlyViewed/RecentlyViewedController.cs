using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWorm.BooksApi.Features.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.BooksApi.Features.RecentlyViewed
{
    [Route("v1/books")]
    public class RecentlyViewedController : Controller
    {
        [Route("{userId}/recent")]
        public async Task<IActionResult> Get(string userId)
        {
            await Task.Delay(170);
            var rnd = new Random();
            return Ok(BookData.GetAll().Select(x => new {Book = x, Rnd = rnd.Next(1, 100)}).OrderBy(x => x.Rnd).Take(4).Select(x => x.Book));
        } 
    }
}
