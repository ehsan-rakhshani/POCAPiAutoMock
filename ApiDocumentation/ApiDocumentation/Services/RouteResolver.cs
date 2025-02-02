using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing.Template;
using System.Reflection;

namespace ApiDocumentation.Services;

public class RouteResolver
{
    private readonly IEnumerable<EndpointDataSource> _endpointSources;

    public RouteResolver(IEnumerable<EndpointDataSource> endpointSources)
    {
        _endpointSources = endpointSources;
    }

    // ورودی: مسیر به‌صورت رشته، خروجی: اطلاعات کنترلر، اکشن و در صورت وجود، مقدار asghr از attribute Ehsan.
    public (ControllerActionDescriptor ActionDescriptor, string EhsanParameter)? ResolveRoute(string route)
    {
        // نمونه یک HttpContext و RouteValueDictionary به‌صورت نمونه جهت تطبیق مسیر
        var httpContext = new DefaultHttpContext();
        // تبدیل مسیر ورودی به فرمت مناسب (بدون Query، تنها مسیر)
        httpContext.Request.Path = route;

        foreach (var dataSource in _endpointSources)
        {
            foreach (var endpoint in dataSource.Endpoints)
            {
                // بررسی کنید آیا endpoint یک RouteEndpoint است یا نه
                if (endpoint is RouteEndpoint routeEndpoint)
                {
                    // استخراج RoutePattern از endpoint.
                    var routePattern = routeEndpoint.RoutePattern;

                    // این شیء به ما در تطبیق مسیر کمک می‌کند.
                    var matcher = new TemplateMatcher(TemplateParser.Parse(routePattern.RawText), new RouteValueDictionary());

                    // ایجاد دیکشنری برای ذخیره مقادیر استخراج شده از مسیر
                    var routeValues = new RouteValueDictionary();
                    if (matcher.TryMatch(route, routeValues))
                    {
                        // بررسی وجود ControllerActionDescriptor در Metadata
                        var cad = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
                        if (cad != null)
                        {
                            // بررسی Attribute بر روی متد یا کلاس:
                            Type ehsanParam = null;

                            // ابتدا بررسی روی متد
                            var methodInfo = cad.MethodInfo;
                            var attr = methodInfo.GetCustomAttribute<InstanceClassAttribute>();
                            if (attr == null)
                            {
                                // در صورتی که روی متد نباشد، روی کنترلر هم می‌توانید جستجو کنید.
                                attr = cad.ControllerTypeInfo.GetCustomAttribute<InstanceClassAttribute>();
                            }

                            if (attr != null)
                            {
                                ehsanParam = attr.InstanceClassType;
                            }

                            // ترمیم خروجی
                            return (cad, null);
                        }
                    }
                }
            }
        }

        // در صورت عدم یافتن مسیر منطبق، مقدار null مرجوع می‌شود.
        return null;
    }
}