using BookWorm.Api;
using System.Linq;
using System.Collections.Generic;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.Stores;
using Bolt.RestClient;
using Bolt.RequestBus;
using System.Threading.Tasks;
using Bolt.RestClient.Extensions;

namespace BookWorm.Web.Features.Home.RecentlyViewed
{
    public interface IRecentlyViewedProvider
    {
        IEnumerable<BookDto> Get();
    }

    [AutoBind]
    public class RecentlyViewedProvider : IRecentlyViewedProvider, Bolt.RequestBus.IAsyncEventHandler<HomePageRequestedEvent>
    {
        private const string Key = "RecentlyViewedProvider:Get";
        private readonly IContextStore context;
        private readonly IRestClient restClient;
        
        public RecentlyViewedProvider(IContextStore context, IRestClient restClient)
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
            var response = await restClient.For("http://localhost:5000/api/v1/books/recent")
                .AcceptJson()
                .Timeout(300)
                .RetryOnFailure(3)
                .GetAsync<IEnumerable<BookDto>>();

            context.Set(Key, response.Output);
        }
    }
}