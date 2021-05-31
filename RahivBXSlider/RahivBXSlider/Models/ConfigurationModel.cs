using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace RahivBXSlider.Models
{
    public record ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Widgets.RahivBXSlider.UseSandbox")]
        public bool UseSandbox { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.RahivBXSlider.Message")]
        public string Message { get; set; }
    }
}
