using Umbraco.Core;
using Umbraco.Web.Routing;

namespace DotSee
{
    public class OmitSegmentsEventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //Register provider
            UrlProviderResolver.Current.InsertTypeBefore<DefaultUrlProvider, OmitSegmentsUrlProvider>();
            ContentFinderResolver.Current.InsertTypeBefore<ContentFinderByNotFoundHandlers, OmitSegmentsContentFinder>();

            base.ApplicationStarting(umbracoApplication, applicationContext);
        }
    }
}