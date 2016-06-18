using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Api
{
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        [Route("{id}")]
        [HttpGet]
         public async Task<IActionResult> Get(string id)
         {
             await Task.Delay(200);
             
             return Ok(new UserDto
             {
                 Name = "Ruhul"
             });
         }
    }

    public class UserDto
    {
        public string Name { get; set; }
    }
}
