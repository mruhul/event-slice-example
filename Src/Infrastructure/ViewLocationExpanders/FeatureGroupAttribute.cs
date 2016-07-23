using Microsoft.AspNetCore.Mvc.Filters;

namespace Src.Infrastructure.ViewLocationExpanders
{
    public class FeatureGroupAttribute : ActionFilterAttribute
    {
        private readonly string featureGroup;

        public FeatureGroupAttribute(string featureGroup)
        {
            this.featureGroup = featureGroup;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items.Add("FeatureGroup", featureGroup);
        }
    }
}