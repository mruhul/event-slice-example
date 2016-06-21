using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWorm.BooksApi.Features.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.BooksApi.Features.BooksList
{
    [Route("v1/books/list")]
    public class BooksListController : Controller
    {
        [Route("{category}")]
        public async Task<IActionResult> Get(string category)
        {
            await Task.Delay(180);

            return
                Ok(BookData.GetAll()
                    .Where(x => string.Equals(x.UrlFriendlyCategory, category, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(x => x.Title));
        }  
    }
}
