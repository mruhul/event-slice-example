using System.Collections.Generic;
using System.Linq;
using Bolt.Common.Extensions;
using BookWorm.Api;
using BookWorm.Web.Features.Shared.SavedBooks;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.Stores;

namespace BookWorm.Web.Features.Home.RecentlyViewed
{
    public interface IRecentlyViewedProvider
    {
        IEnumerable<BookDto> Get();
        void Set(IEnumerable<BookDto> value);
    }

    [AutoBind]
    public class RecentlyViewedProvider : IRecentlyViewedProvider
    {
        private readonly IContextStore store;
        private readonly ISavedItemsProvider savedItemsProvider;
        private const string Key = "RecentlyViewedProvider:Get";

        public RecentlyViewedProvider(IContextStore store, ISavedItemsProvider savedItemsProvider)
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

        public void Set(IEnumerable<BookDto> value)
        {
            store.Set(Key, value);
        }
    }
}