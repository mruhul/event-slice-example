using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bolt.Common.Extensions;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Extensions;
using BookWorm.Api;
using BookWorm.Web.Features.Search;
using BookWorm.Web.Features.Shared.CategoryMenu;
using BookWorm.Web.Features.Shared.SavedBooks;
using Microsoft.AspNetCore.Mvc;
using Src.Features.Shared.CategoryMenu;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.ErrorSafeHelpers;
using Src.Infrastructure.Stores;

namespace BookWorm.Web.Features.Search.List
{
    public class BooksListViewComponent : ViewComponent
    {
        private readonly IBooksListProvider provider;
        private readonly ISavedItemsProvider savedItemsProvider;
        private readonly ICategoryMenuProvider categoryMenuProvider;
        private readonly ICurrentCategoryProvider currentCategoryProvider;

        public BooksListViewComponent(IBooksListProvider provider, 
            ISavedItemsProvider savedItemsProvider,
            ICategoryMenuProvider categoryMenuProvider,
            ICurrentCategoryProvider currentCategoryProvider)
        {
            this.provider = provider;
            this.savedItemsProvider = savedItemsProvider;
            this.categoryMenuProvider = categoryMenuProvider;
            this.currentCategoryProvider = currentCategoryProvider;
        }

        public IViewComponentResult Invoke()
        {
            var savedItems = savedItemsProvider.Get();
            var vm = new BookListViewData
            {
                CategoryName = categoryMenuProvider.Get().FirstOrDefault(x => x.Name.ToSlug() == currentCategoryProvider.Get())?.Name,
                Books = provider.Get().Select(x =>
                {
                    x.IsSaved = savedItems.Any(i => i == x.Id);
                    return x;
                }).ToList()
            };

            return View("~/Features/Search/List/Views/BooksList.cshtml", vm);
        }
    }

    public class BookListViewData
    {
        public string CategoryName { get; set; }
        public ICollection<BookDto> Books { get; set; }
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
