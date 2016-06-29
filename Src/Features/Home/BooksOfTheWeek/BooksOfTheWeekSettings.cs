using Microsoft.Extensions.Configuration;
using Src.Infrastructure.Attributes;

namespace Src.Features.Home.BooksOfTheWeek
{
    public interface IBooksOfTheWeekSettings
    {
        string Url { get; }
    }

    [AutoBindSingleton]
    public class BooksOfTheWeekSettings : IBooksOfTheWeekSettings
    {
        public BooksOfTheWeekSettings(IConfiguration cfg)
        {
            Url = cfg.GetSection("apiSettings:booksApiSettings")["url"];
        }

        public string Url { get; }
    }
}
