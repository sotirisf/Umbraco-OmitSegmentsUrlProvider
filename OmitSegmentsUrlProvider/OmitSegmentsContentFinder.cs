using DotSee;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Routing;

/// <summary>
/// ContentFinder for OmitUrlSegmentsUrlProvider
/// </summary>
public class OmitSegmentsContentFinder : IContentFinder
{
    public bool TryFindContent(PublishedContentRequest contentRequest)
    {
        string path = contentRequest.Uri.AbsolutePath;
        var rootNodes = contentRequest.RoutingContext.UmbracoContext.ContentCache.GetAtRoot();
        IPublishedContent item = null;
        foreach (OmitSegmentsRule rule in OmitSegmentsRuleManager.Instance.Rules)
        {
            item = rootNodes.DescendantsOrSelf(rule.DocTypeAlias).Where(x => x.Url == (path + "/") || x.Url == path).FirstOrDefault();
            if (item != null) break;
        }

        if (item != null)
        {
            contentRequest.PublishedContent = item;
            return true;
        }

        return false;
    }
}

