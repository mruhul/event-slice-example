using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Extensions;
using BookWorm.Api;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.ErrorSafeHelpers;
using Src.Infrastructure.Stores;

namespace BookWorm.Web.Features.Home.BooksOfTheWeek
{

    public interface IBooksOfTheWeekProvider
    {
        IEnumerable<BookDto> Get();
    }

    [AutoBind]
    public class BooksOfTheWeekProvider : IBooksOfTheWeekProvider, IAsyncEventHandler<HomePageRequestedEvent>
    {
        private readonly IContextStore context;
        private readonly IRestClient restClient;
        private readonly ILogger logger;
        private const string Key = "BooksOfTheWeekProvider:Get";

        public BooksOfTheWeekProvider(IContextStore context, IRestClient restClient, ILogger logger)
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
            var response = await ErrorSafe.WithLogger(logger)
                .ExecuteAsync(() => restClient.For("http://localhost:5051/v1/books/featured")
                    .AcceptJson()
                    .Timeout(1000)
                    .RetryOnFailure(2)
                    .GetAsync<IEnumerable<BookDto>>());

            context.Set(Key, response.Value?.Output);
        }
    }
}