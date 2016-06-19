using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("v1/[controller]")]
public class CategoriesController : Controller
{
    [Route("")]
    public async Task<IActionResult> Get()
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

    public class CategoryDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}