using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWorm.BooksApi.Features.Shared;
using Microsoft.AspNetCore.Mvc;

[Route("v1/[controller]")]
public class CategoriesController : Controller
{
    [Route("")]
    public async Task<IActionResult> Get()
    {
        
            await Task.Delay(150);

            return Ok(BookData.GetAll().GroupBy(l => l.Category)
                      .Select(g => new
                      CategoryDto{
                          Name = g.Key,
                          Count = g.Select(l => l.Id).Distinct().Count()
                      }).OrderBy(x => x.Name));
    }

    public class CategoryDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}