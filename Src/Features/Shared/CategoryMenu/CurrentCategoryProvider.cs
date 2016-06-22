using System.Threading.Tasks;
using Bolt.RequestBus;
using BookWorm.Web.Features.Search;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.Stores;

namespace Src.Features.Shared.CategoryMenu
{
    public interface ICurrentCategoryProvider
    {
        void Set(string urlFriendlyName);
        string Get();
    }

    [AutoBind]
    public class CurrentCategoryProvider : ICurrentCategoryProvider
    {
        private const string Key = "CurrentCategoryProvider:Name";
        private readonly IContextStore store;

        public CurrentCategoryProvider(IContextStore store)
        {
            this.store = store;
        }

        public void Set(string urlFriendlyName)
        {
            store.Set(Key, urlFriendlyName);
        }

        public string Get()
        {
            return store.Get<string>(Key);
        }
    }

    public class LoadCurrentCategoryOnPageLoadEventHandler : IAsyncEventHandler<SearchPageRequestedEvent>
    {
        private readonly ICurrentCategoryProvider provider;

        public LoadCurrentCategoryOnPageLoadEventHandler(ICurrentCategoryProvider provider)
        {
            this.provider = provider;
        }

        public Task HandleAsync(SearchPageRequestedEvent eEvent)
        {
            provider.Set(eEvent.Category);

            return Task.FromResult(0);
        }
    }
}
