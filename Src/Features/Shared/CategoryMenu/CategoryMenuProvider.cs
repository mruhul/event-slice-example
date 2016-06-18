using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Extensions;
using BookWorm.Api;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.Stores;

namespace BookWorm.Web.Features.Shared.CategoryMenu
{
    public interface ICategoryMenuProvider
    {
        IEnumerable<CategoryDto> Get();
    }

    [AutoBind]
    public class CategoryMenuProvider : ICategoryMenuProvider
    {
        private readonly ICategoryMenuContextStore contextStore;

        public CategoryMenuProvider(ICategoryMenuContextStore contextStore)
        {
            this.contextStore = contextStore;
        }

        public IEnumerable<CategoryDto> Get()
        {
            return contextStore.Get() ?? Enumerable.Empty<CategoryDto>();
        }
    }

    public interface ICategoryMenuContextStore
    {
        IEnumerable<CategoryDto> Get();
        void Set(IEnumerable<CategoryDto> value);
    }

    [AutoBind]
    public class CatgoryMenuContextStore : ICategoryMenuContextStore
    {
        private const string Key = "CatgoryMenuContextStore:Get";
        private readonly IContextStore context;

        public CatgoryMenuContextStore(IContextStore context)
        {
            this.context = context;    
        }

        public IEnumerable<CategoryDto> Get()
        {
            return context.Get<IEnumerable<CategoryDto>>(Key);
        }

        public void Set(IEnumerable<CategoryDto> value)
        {
            context.Set(Key, value);
        }
    }

    public class LoadCategoryMenuOnPageLoadEventHandler<T> : Bolt.RequestBus.IAsyncEventHandler<T> where T : IEvent
    {
        private readonly ICategoryMenuContextStore context;
        private readonly IRestClient restClient;

        public LoadCategoryMenuOnPageLoadEventHandler(ICategoryMenuContextStore context, IRestClient restClient)
        {
            this.context = context;
            this.restClient = restClient;
        }

        public async Task HandleAsync(T eEvent)
        {
            if(!(eEvent is BookWorm.Web.Features.Shared.Events.IPageRequestedEvent)) return;

            var response = await restClient.For("http://localhost:5000/api/v1/books/categories")
                .AcceptJson()
                .RetryOnFailure(2)
                .Timeout(1000)
                .GetAsync<IEnumerable<CategoryDto>>();

            context.Set(response.Output);
        }
    }
}