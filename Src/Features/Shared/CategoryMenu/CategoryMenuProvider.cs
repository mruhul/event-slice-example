using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Extensions;
using Microsoft.Extensions.Options;
using Src.Features.Shared.Settings;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.ErrorSafeHelpers;
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
        private readonly ILogger logger;
        private readonly IOptions<ApiSettings> settings;

        public LoadCategoryMenuOnPageLoadEventHandler(ICategoryMenuContextStore context, 
            IRestClient restClient, 
            ILogger logger,
            IOptions<ApiSettings> settings)
        {
            this.context = context;
            this.restClient = restClient;
            this.logger = logger;
            this.settings = settings;
        }

        public async Task HandleAsync(T eEvent)
        {
            if(!(eEvent is IRequireCategoryMenu)) return;

            var response = await ErrorSafe.WithLogger(logger)
                .ExecuteAsync(() => restClient.For($"{settings.Value.BaseUrl}/categories")
                .AcceptJson()
                .RetryOnFailure(2)
                .Timeout(1000)
                .GetAsync<IEnumerable<CategoryDto>>());
            
            context.Set(response.Value?.Output);
        }
    }

    public interface IRequireCategoryMenu
    {        
    }


    public class CategoryDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}