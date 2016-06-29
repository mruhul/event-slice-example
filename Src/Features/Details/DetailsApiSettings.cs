using Microsoft.Extensions.Configuration;
using Src.Infrastructure.Attributes;

namespace Src.Features.Details
{
    public interface IDetailsApiSettings
    {
        string Url { get; }
    }

    [AutoBindSingleton]
    public class DetailsApiSettings : IDetailsApiSettings
    {
        public DetailsApiSettings(IConfiguration cfg)
        {
            Url = cfg.GetSection("apiSettings:detailsApiSettings")["url"];
        }

        public string Url { get; }
    }
}
