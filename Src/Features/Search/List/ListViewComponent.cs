using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bolt.Common.Extensions;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Builders;
using Bolt.RestClient.Extensions;
using BookWorm.Api;
using BookWorm.Web.Features.Search;
using BookWorm.Web.Features.Shared.Cart;
using BookWorm.Web.Features.Shared.CategoryMenu;
using BookWorm.Web.Features.Shared.SavedBooks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Src.Features.Shared.CategoryMenu;
using Src.Features.Shared.Settings;
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
        private readonly ICartProvider cartProvider;

        public BooksListViewComponent(IBooksListProvider provider, 
            ISavedItemsProvider savedItemsProvider,
            ICategoryMenuProvider categoryMenuProvider,
            ICurrentCategoryProvider currentCategoryProvider,
            ICartProvider cartProvider)
        {
            this.provider = provider;
            this.savedItemsProvider = savedItemsProvider;
            this.categoryMenuProvider = categoryMenuProvider;
            this.currentCategoryProvider = currentCategoryProvider;
            this.cartProvider = cartProvider;
        }

        public IViewComponentResult Invoke()
        {
            var savedItems = savedItemsProvider.Get();
            var books = provider.Get();
            var cart = cartProvider.Get();
            var vm = new BookListViewData
            {
                CategoryName = categoryMenuProvider.Get().FirstOrDefault(x => x.Name.ToSlug() == currentCategoryProvider.Get())?.Name,
                Books = books.Select(x =>
                {
                    x.IsSaved = savedItems.Any(i => i == x.Id);
                    x.TotalItemsInCart = cart.Items?.FirstOrDefault(item => item.BookId == x.Id)?.Quantity ?? 0;
                    return x;
                }).ToArray()
            };

            return View("~/Features/Search/List/Views/BooksList.cshtml", vm);
        }
    }

    public class BookListViewData
    {
        public string CategoryName { get; set; }
        public BookDto[] Books { get; set; }
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

    public class LoadBooksOnSearchPageRequestedEventHandler : IAsyncEventHandler<SearchPageRequestedEvent>
    {
        private readonly IBooksListProvider provider;
        private readonly IRestClient restClient;
        private readonly ILogger logger;
        private readonly IOptions<ApiSettings> settings;

        public LoadBooksOnSearchPageRequestedEventHandler(IBooksListProvider provider, 
            IRestClient restClient,
            ILogger logger,
            IOptions<ApiSettings> settings)
        {
            this.provider = provider;
            this.restClient = restClient;
            this.logger = logger;
            this.settings = settings;
        }

        public async Task HandleAsync(SearchPageRequestedEvent eEvent)
        {
            var response = await ErrorSafe.WithLogger(logger)
                .ExecuteAsync(() => restClient.For(UrlBuilder.Host(settings.Value.BaseUrl).Route("/books/list/{0}", eEvent.Category))
                    .AcceptJson()
                    .Timeout(1000)
                    .RetryOnFailure(2)
                    .GetAsync<IEnumerable<BookDto>>());

            provider.Set(response.Value?.Output);
        }
    }
}
