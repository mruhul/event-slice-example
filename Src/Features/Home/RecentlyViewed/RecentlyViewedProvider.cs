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
using Microsoft.Extensions.Options;
using Src.Features.Shared.Settings;
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
        private readonly IOptions<ApiSettings> settings;

        public RecentlyViewedProvider(IContextStore context, 
            IRestClient restClient, 
            ILogger logger,
            IOptions<ApiSettings> settings)
        {
            this.context = context;
            this.restClient = restClient;
            this.logger = logger;
            this.settings = settings;
        }

        public IEnumerable<BookDto> Get()
        {
            return context.Get<IEnumerable<BookDto>>(Key) ?? Enumerable.Empty<BookDto>();
        }

        public async Task HandleAsync(HomePageRequestedEvent eEvent)
        {
            var response = await ErrorSafe.WithLogger(logger)
                .ExecuteAsync(() => restClient.For($"{settings.Value.BaseUrl}/books/456/recent")
                .AcceptJson()
                .Timeout(1000)
                .RetryOnFailure(2)
                .GetAsync<IEnumerable<BookDto>>());
            
            context.Set(Key, response.Value?.Output);
        }
    }
}