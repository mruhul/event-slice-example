using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RestClient;
using Bolt.RestClient.Extensions;
using Microsoft.Extensions.Options;
using Src.Features.Shared.Settings;
using Src.Infrastructure.ErrorSafeHelpers;

namespace BookWorm.Web.Features.Shared.Cart
{
    public class LoadCartOnPageLoadEventHandler<T> : IAsyncEventHandler<T> where T : IEvent
    {
        private readonly ICartProvider provider;
        private readonly IRestClient restClient;
        private readonly ILogger logger;
        private readonly IOptions<ApiSettings> settings;

        public LoadCartOnPageLoadEventHandler(ICartProvider provider, 
            IRestClient restClient, 
            ILogger logger,
            IOptions<ApiSettings> settings)
        {
            this.provider = provider;
            this.restClient = restClient;
            this.logger = logger;
            this.settings = settings;
        }

        public async Task HandleAsync(T eEvent)
        {
            if (eEvent is IDontRequireCart) return;

            var result = await ErrorSafe.WithLogger(logger).ExecuteAsync(() => restClient
                .For($"{settings.Value.BaseUrl}/cart/{0}", "userid")
                .Timeout(1000)
                .GetAsync<IEnumerable<CartItemDto>>()); 

            provider.Set(new CartDto(result.Value?.Output));
        }
    }

    public interface IDontRequireCart
    {
    }
}
