using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm.Web.Features.Shared.BreadCrumb
{
    public class BreadCrumbViewModel
    {
        public ICollection<BreadCrumbLink> Links { get; set; } 
    }

    public class BreadCrumbLink
    {
        public string Text { get; set; }
        public string Url { get; set; }
    }
}
