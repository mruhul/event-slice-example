using System;
using BookWorm.Api;
using System.Linq;
using System.Collections.Generic;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.Stores;
using Bolt.RestClient;
using Bolt.RequestBus;
using System.Threading.Tasks;
using Bolt.Common.Extensions;
using Bolt.Logger;
using Bolt.RestClient.Extensions;
using Src.Infrastructure.ErrorSafeHelpers;

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
        private readonly ILogger logger;

        public RecentlyViewedProvider(IContextStore context, IRestClient restClient, ILogger logger)
        {
            this.context = context;
            this.restClient = restClient;
            this.logger = logger;
        }

        public IEnumerable<BookDto> Get()
        {
            return context.Get<IEnumerable<BookDto>>(Key) ?? Enumerable.Empty<BookDto>();
        }

        public async Task HandleAsync(HomePageRequestedEvent eEvent)
        {
            var response = await ErrorSafe.WithLogger(logger).ExecuteAsync(() => restClient.For("http://localhost:5051/v1/books/456/recent")
                .AcceptJson()
                .Timeout(1000)
                .RetryOnFailure(3)
                .GetAsync<IEnumerable<BookDto>>());
            
            context.Set(Key, response.Value?.Output);
        }
    }
}