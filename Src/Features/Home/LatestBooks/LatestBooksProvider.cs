using System;
using System.Collections.Generic;
using System.Linq;
using Bolt.Common.Extensions;
using BookWorm.Api;
using BookWorm.Web.Features.Shared.SavedBooks;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.Stores;

namespace BookWorm.Web.Features.Home.CategoryMenu
{
    public interface ILatestBooksProvider
    {
        IEnumerable<BookDto> Get();
        void Set(IEnumerable<BookDto> books);
    }

    [AutoBind]
    public class LatestBooksProvider : ILatestBooksProvider
    {
        private readonly IContextStore store;
        private readonly ISavedItemsProvider savedItemsProvider;
        private const string Key = "LatestBooksProvider:LatestBooks";

        public LatestBooksProvider(IContextStore store, ISavedItemsProvider savedItemsProvider)
        {
            this.store = store;
            this.savedItemsProvider = savedItemsProvider;
        }

        public IEnumerable<BookDto> Get()
        {
            var savedIds = savedItemsProvider.Get();
            return store.Get<IEnumerable<BookDto>>(Key)
                .NullSafe()
                .Select(x =>
                {
                    x.IsSaved = savedIds.Any(id => id == x.Id);
                    return x;
                });
        }

        public void Set(IEnumerable<BookDto> books)
        {
            store.Set(Key, books);
        }
    }
}