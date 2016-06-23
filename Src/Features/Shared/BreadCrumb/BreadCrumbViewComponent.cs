using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.Stores;

namespace BookWorm.Web.Features.Shared.BreadCrumb
{
    public class BreadCrumbViewComponent : ViewComponent
    {
        private readonly IBreadCrumbProvider provider;

        public BreadCrumbViewComponent(IBreadCrumbProvider provider)
        {
            this.provider = provider;
        }

        public IViewComponentResult Invoke()
        {
            return View("~/Features/Shared/BreadCrumb/Views/BreadCrumb.cshtml", provider.Get());
        }
    }

    public interface IBreadCrumbProvider
    {
        BreadCrumbViewModel Get();
        void Push(BreadCrumbLink link);
    }

    [AutoBind]
    public class BreadCrumbProvider : IBreadCrumbProvider
    {
        private const string Key = "BreadCrumbProvider:Links";
        private readonly IContextStore store;

        public BreadCrumbProvider(IContextStore store)
        {
            this.store = store;
        }

        public BreadCrumbViewModel Get()
        {
            return store.Get<BreadCrumbViewModel>(Key) ?? new BreadCrumbViewModel
            {
                Links = new List<BreadCrumbLink>()
            };
        }

        public void Push(BreadCrumbLink link)
        {
            var existing = Get();

            existing.Links.Add(link);

            store.Set(Key, existing);
        }
    }
}
