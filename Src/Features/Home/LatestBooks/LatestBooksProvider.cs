using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Extensions;
using BookWorm.Api;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.Stores;

namespace BookWorm.Web.Features.Home.CategoryMenu
{
    public interface ILatestBooksProvider
    {
        IEnumerable<BookDto> Get();
    }


    [AutoBind]
    public class LatestBooksProvider : ILatestBooksProvider, IAsyncEventHandler<HomePageRequestedEvent>
    {
        private const string Key = "LatestBooksProvider:LatestBooks";
        private readonly IContextStore context;
        private readonly IRestClient restClient;

        public LatestBooksProvider(IContextStore context, IRestClient restClient)
        {
            this.context = context;
            this.restClient = restClient;
        }

        public IEnumerable<BookDto> Get()
        {
            return context.Get<IEnumerable<BookDto>>(Key) ?? Enumerable.Empty<BookDto>();
        }

        public async Task HandleAsync(HomePageRequestedEvent eEvent)
        {
            var response = await restClient.For("http://localhost:5000/api/v1/books/latest")
                .AcceptJson()
                .Timeout(300)
                .RetryOnFailure(3)
                .GetAsync<IEnumerable<BookDto>>();

            context.Set(Key, response.Output);
        }
    }
}