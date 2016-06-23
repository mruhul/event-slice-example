using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bolt.Common.Extensions;
using Bolt.RequestBus;
using Bolt.RequestBus.Events;
using BookWorm.Web.Features.Details;
using BookWorm.Web.Features.Shared.BreadCrumb;
using BookWorm.Web.Features.Shared.CategoryMenu;
using Src.Features.Shared.CategoryMenu;
using Src.Infrastructure.Attributes;

namespace Src.Features.Details
{
    public class LoadBreadCrumbOnBookDetailsLoadedEventHandler : IAsyncEventHandler<RequestCompleted<DetailsQuery, DetailsViewModel>>
    {
        private readonly IBreadCrumbProvider provider;

        public LoadBreadCrumbOnBookDetailsLoadedEventHandler(IBreadCrumbProvider provider, ICategoryMenuProvider categoryMenuProvider, ICurrentCategoryProvider currentCategoryProvider)
        {
            this.provider = provider;
        }

        public Task HandleAsync(RequestCompleted<DetailsQuery, DetailsViewModel> eEvent)
        {
            provider.Push(new BreadCrumbLink
            {
                Text = eEvent.Result?.Value?.Category,
                Url = $"/books/{eEvent.Result?.Value?.Category.ToSlug()}"
            });

            provider.Push(new BreadCrumbLink
            {
                Text = eEvent.Result?.Value?.Title,
                Url = $"/books/details/{eEvent.Result?.Value?.Id}/{eEvent?.Result?.Value?.Title.ToSlug()}"
            });

            return Task.FromResult(0);
        }
    }
}
