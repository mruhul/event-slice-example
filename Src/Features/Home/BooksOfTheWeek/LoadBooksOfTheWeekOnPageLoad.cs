using System.Collections.Generic;
using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Builders;
using Bolt.RestClient.Extensions;
using BookWorm.Api;
using Microsoft.Extensions.Options;
using Src.Features.Shared.Settings;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.ErrorSafeHelpers;

namespace BookWorm.Web.Features.Home.BooksOfTheWeek
{
    [AutoBind]
    public class LoadBooksOfTheWeekOnPageLoad : IAsyncEventHandler<HomePageRequestedEvent>
    {
        private readonly ILogger logger;
        private readonly IBooksOfTheWeekProvider provider;
        private readonly IOptions<ApiSettings> settings;
        private readonly IRestClient restClient;

        public LoadBooksOfTheWeekOnPageLoad(ILogger logger,
            IBooksOfTheWeekProvider provider, 
            IOptions<ApiSettings> settings, 
            IRestClient restClient)
        {
            this.logger = logger;
            this.provider = provider;
            this.settings = settings;
            this.restClient = restClient;
        } 

        public async Task HandleAsync(HomePageRequestedEvent eEvent)
        {
            var response = await ErrorSafe.WithLogger(logger)
                .ExecuteAsync(() => restClient.For(UrlBuilder.Host(settings.Value.BaseUrl).Route("books/featured"))
                    .AcceptJson()
                    .Timeout(1000)
                    .RetryOnFailure(2)
                    .GetAsync<IEnumerable<BookDto>>());

            provider.Set(response.Value?.Output);
        }
    }
}