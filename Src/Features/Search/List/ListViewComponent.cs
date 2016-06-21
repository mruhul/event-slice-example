using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Extensions;
using BookWorm.Api;
using BookWorm.Web.Features.Search;
using BookWorm.Web.Features.Shared.SavedBooks;
using Microsoft.AspNetCore.Mvc;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.ErrorSafeHelpers;
using Src.Infrastructure.Stores;

namespace Src.Features.Search.List
{
    public class BooksListViewComponent : ViewComponent
    {
        private readonly IBooksListProvider provider;
        private readonly ISavedItemsProvider savedItemsProvider;

        public BooksListViewComponent(IBooksListProvider provider, ISavedItemsProvider savedItemsProvider)
        {
            this.provider = provider;
            this.savedItemsProvider = savedItemsProvider;
        }

        public IViewComponentResult Invoke()
        {
            var savedItems = savedItemsProvider.Get();
            var vm = provider.Get().Select(x =>
            {
                x.IsSaved = savedItems.Any(i => i == x.Id);
                return x;
            });

            return View("~/Features/Search/List/Views/BooksList.cshtml", vm);
        }
    }

    public interface IBooksListProvider
    {
        IEnumerable<BookDto> Get();
        void Set(IEnumerable<BookDto> value);
    }

    [AutoBind]
    public class BookListProvider : IBooksListProvider
    {
        private readonly IContextStore store;
        private const string Key = "BookListProvider:Books";

        public BookListProvider(IContextStore store)
        {
            this.store = store;
        }

        public IEnumerable<BookDto> Get()
        {
            return store.Get<IEnumerable<BookDto>>(Key) ?? Enumerable.Empty<BookDto>();
        }

        public void Set(IEnumerable<BookDto> value)
        {
            store.Set(Key, value);
        }
    }

    [AutoBind]
    public class LoadBooksOnSearchPageRequestedEventHandler : IAsyncEventHandler<SearchPageRequestedEvent>
    {
        private readonly IBooksListProvider provider;
        private readonly IRestClient restClient;
        private readonly ILogger logger;

        public LoadBooksOnSearchPageRequestedEventHandler(IBooksListProvider provider, 
            IRestClient restClient,
            ILogger logger)
        {
            this.provider = provider;
            this.restClient = restClient;
            this.logger = logger;
        }

        public async Task HandleAsync(SearchPageRequestedEvent eEvent)
        {
            var response = await ErrorSafe.WithLogger(logger)
                .ExecuteAsync(() => restClient.For("http://localhost:5051/v1/books/list/{0}", eEvent.Category)
                    .AcceptJson()
                    .Timeout(1000)
                    .RetryOnFailure(3)
                    .GetAsync<IEnumerable<BookDto>>());

            provider.Set(response.Value?.Output);
        }
    }
}
