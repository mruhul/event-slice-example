using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.BooksApi.Features.Users
{
    [Route("v1/[controller]")]
    public class UsersController : Controller
    {
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            await Task.Delay(150);

            return Ok(new
            {
                Name = "Ruhul Amin"
            });
        } 
    }
}
