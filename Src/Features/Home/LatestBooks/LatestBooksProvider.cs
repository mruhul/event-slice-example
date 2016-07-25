using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ILogger logger;
        private readonly IOptions<ApiSettings> settings;

        public LatestBooksProvider(IContextStore context, 
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
                            .ExecuteAsync(() => restClient.For($"{settings.Value.BaseUrl}/books/latest")
                            .AcceptJson()
                            .Timeout(1000)
                            .RetryOnFailure(2)
                            .GetAsync<IEnumerable<BookDto>>());

            context.Set(Key, response.Value?.Output);
        }
    }
}