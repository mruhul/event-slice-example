using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Builders;
using Bolt.RestClient.Extensions;
using BookWorm.Api;
using Src.Features.Home.BooksOfTheWeek;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.ErrorSafeHelpers;
using Src.Infrastructure.Stores;

namespace BookWorm.Web.Features.Home.BooksOfTheWeek
{

    public interface IBooksOfTheWeekProvider
    {
        IEnumerable<BookDto> Get();
        void Set(IEnumerable<BookDto> value);
    }

    public class LoadBooksOfTheWeekOnPageLoadEventHandler : IAsyncEventHandler<HomePageRequestedEvent>
    {
        private readonly ILogger logger;
        private readonly IBooksOfTheWeekProvider provider;
        private readonly IBooksOfTheWeekSettings settings;
        private readonly IRestClient restClient;

        public LoadBooksOfTheWeekOnPageLoadEventHandler(ILogger logger,
            IBooksOfTheWeekProvider provider, 
            IBooksOfTheWeekSettings settings, 
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
                .ExecuteAsync(() => restClient.For(UrlBuilder.Host(settings.Url).Route("books/featured"))
                    .AcceptJson()
                    .Timeout(1000)
                    .RetryOnFailure(2)
                    .GetAsync<IEnumerable<BookDto>>());

            provider.Set(response.Value?.Output);
        }
    }


    [AutoBind]
    public class BooksOfTheWeekProvider : IBooksOfTheWeekProvider
    {
        private readonly IContextStore context;
        private const string Key = "BooksOfTheWeekProvider:Get";

        public BooksOfTheWeekProvider(IContextStore context)
        {
            this.context = context;
        }

        public IEnumerable<BookDto> Get()
        {
            return context.Get<IEnumerable<BookDto>>(Key) ?? Enumerable.Empty<BookDto>();
        }

        public void Set(IEnumerable<BookDto> value)
        {
            context.Set(Key, value);
        }
    }
}