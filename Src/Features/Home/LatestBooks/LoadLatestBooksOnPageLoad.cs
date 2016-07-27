using System.Collections.Generic;
using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Extensions;
using BookWorm.Api;
using Microsoft.Extensions.Options;
using Src.Features.Shared.Settings;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.ErrorSafeHelpers;

namespace BookWorm.Web.Features.Home.CategoryMenu
{
    [AutoBind]
    public class LoadLatestBooksOnPageLoad : IAsyncEventHandler<HomePageRequestedEvent>
    {
        private readonly ILatestBooksProvider provider;
        private readonly IRestClient restClient;
        private readonly ILogger logger;
        private readonly IOptions<ApiSettings> settings;

        public LoadLatestBooksOnPageLoad(ILatestBooksProvider provider,
            IRestClient restClient, 
            ILogger logger,
            IOptions<ApiSettings> settings)
        {
            this.provider = provider;
            this.restClient = restClient;
            this.logger = logger;
            this.settings = settings;
        }
        
        public async Task HandleAsync(HomePageRequestedEvent eEvent)
        {
            var response = await ErrorSafe.WithLogger(logger)
                .ExecuteAsync(() => restClient.For($"{settings.Value.BaseUrl}/books/latest")
                    .AcceptJson()
                    .Timeout(1000)
                    .RetryOnFailure(2)
                    .GetAsync<IEnumerable<BookDto>>());

            provider.Set(response.Value?.Output);
        }
    }
}