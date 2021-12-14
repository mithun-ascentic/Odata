//using Microsoft.AspNetCore.OData.Routing.Conventions;
//using Microsoft.OData.UriParser;
//using System.Linq;
//using System.Net.Http;
//using System.Web.Http.Controllers;

//namespace Odata_1.Helper.Odata
//{
//    public class CustomConvention : EntitySetRoutingConvention
//    {
//        public override string SelectAction(ODataPath odataPath, HttpControllerContext context, ILookup<string, HttpActionDescriptor> actionMap)
//        {
//            if (context.Request.Method == HttpMethod.Get && odataPath.PathTemplate == "~/entityset/key/navigation/key")
//            {
//                NavigationPathSegment navigationSegment = odataPath.Segments[2] as NavigationPathSegment;
//                var navigationProperty = navigationSegment.NavigationProperty;

//                //Create Action name
//                string actionName = "Get" + navigationProperty.Name;
//                if (actionMap.Contains(actionName))
//                {
//                    // Add keys to route data, so they will bind to action parameters.
//                    KeyValuePathSegment keyValueSegment = odataPath.Segments[1] as KeyValuePathSegment;
//                    context.RouteData.Values[ODataRouteConstants.Key] = keyValueSegment.Value;

//                    KeyValuePathSegment relatedKeySegment = odataPath.Segments[3] as KeyValuePathSegment;
//                    context.RouteData.Values[ODataRouteConstants.RelatedKey] = relatedKeySegment.Value;

//                    return actionName;
//                }
//            }
//            // Not a match.
//            return null;
//        }
//    }
//}
