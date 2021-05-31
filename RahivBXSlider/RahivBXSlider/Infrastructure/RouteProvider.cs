using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;

namespace RahivBXSlider.Infrastructure
{
    class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapControllerRoute("RahivBXSliderRoute", "Plugins/RahivBXSlide/Index",
                new { controller = "RahivBXSlider", action = "Index" });
        }

        public int Priority => 0;
    }
}
