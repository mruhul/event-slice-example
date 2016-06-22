using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWorm.BooksApi.Features.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.BooksApi.Features.SavedBooks
{
    [Route("v1/books")]
    public class SavedBooksController : Controller
    {
        [Route("{userId}/saved")]
        public async Task<IActionResult> Get(string userId)
        {
            await Task.Delay(120);
            var ids = BookData.SavedIds();
            return Ok(ids);
        } 
    }
}
