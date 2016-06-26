using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Extensions;
using Src.Infrastructure.ErrorSafeHelpers;

namespace BookWorm.Web.Features.Shared.Cart
{
    public class LoadCartOnPageLoadEventHandler<T> : IAsyncEventHandler<T> where T : IEvent
    {
        private readonly ICartProvider provider;
        private readonly IRestClient restClient;
        private readonly ILogger logger;

        public LoadCartOnPageLoadEventHandler(ICartProvider provider, IRestClient restClient, ILogger logger)
        {
            this.provider = provider;
            this.restClient = restClient;
            this.logger = logger;
        }

        public async Task HandleAsync(T eEvent)
        {
            if (eEvent is IDontRequireCart) return;

            var result = await ErrorSafe.WithLogger(logger).ExecuteAsync(() => restClient
                .For("http://localhost:5051/v1/cart/{0}", "userid")
                .Timeout(1000)
                .GetAsync<IEnumerable<CartItemDto>>()); 

            provider.Set(new CartDto(result.Value?.Output));
        }
    }

    public interface IDontRequireCart
    {
    }
}
