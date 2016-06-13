using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Src.Infrastructure.ViewLocationExpanders
{
    public class FeatureBasedViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {

        }
        
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            yield return "/Features/{1}/Views/{0}.cshtml";
            yield return "/Features/{1}/{0}.cshtml";
            yield return "/Features/Shared/Views/{0}.cshtml";
            yield return "/Features/Shared/{0}.cshtml";

            foreach (var viewLocation in viewLocations)
            {
                yield return viewLocation;
            }
        }
    }
}
