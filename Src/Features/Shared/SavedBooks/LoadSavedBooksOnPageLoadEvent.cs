using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bolt.Common.Extensions;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Extensions;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.ErrorSafeHelpers;
using Src.Infrastructure.Stores;

namespace BookWorm.Web.Features.Shared.SavedBooks
{
    public class LoadSavedBooksOnPageLoadEventHandler<T> : IAsyncEventHandler<T> where T : IEvent
    {
        private readonly IRestClient restClient;
        private readonly ISavedItemsProvider provider;
        private readonly ILogger logger;

        public LoadSavedBooksOnPageLoadEventHandler(IRestClient restClient, ISavedItemsProvider provider, ILogger logger)
        {
            this.restClient = restClient;
            this.provider = provider;
            this.logger = logger;
        }

        public Task HandleAsync(T eEvent)
        {
            if (!(eEvent is IRequireSavedItems)) return Task.FromResult(0);

            return ErrorSafe.WithLogger(logger).ExecuteAsync(async () =>
            {
                var response = await restClient.For("http://localhost:5051/v1/books/{0}/saved", "currentuserid")
                    .GetAsync<IEnumerable<string>>();

                provider.Set(response.Output);
            });
        }
    }

    public interface ISavedItemsProvider
    {
        IEnumerable<string> Get();
        void Set(IEnumerable<string> values);
    }

    [AutoBind]
    public class SavedItemsProvider : ISavedItemsProvider
    {
        private readonly IContextStore contextStore;
        private const string Key = "SavedItemsProvider:Get";

        public SavedItemsProvider(IContextStore contextStore)
        {
            this.contextStore = contextStore;
        }

        public IEnumerable<string> Get()
        {
            return contextStore.Get<IEnumerable<string>>(Key).NullSafe();
        }

        public void Set(IEnumerable<string> values)
        {
            contextStore.Set(Key, values);
        }
    }

    public interface IRequireSavedItems
    {
    }
}
