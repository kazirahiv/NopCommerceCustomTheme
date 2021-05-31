
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;
using RahivBXSlider.Models;

namespace RahivBXSlider.Components
{
    [ViewComponent(Name = "WidgetsRahivBXSlider")]
    class WidgetsRahivBXSliderViewComponent : NopViewComponent
    {
        public static string ViewComponentName => "WidgetsRahivBXSlider";
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;



        public WidgetsRahivBXSliderViewComponent(IStoreContext storeContext, ISettingService settingService)
        {
            this._storeContext = storeContext;
            this._settingService = settingService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var rahivBxSliderSettings = await _settingService.LoadSettingAsync<BXSliderSettings>((await _storeContext.GetCurrentStoreAsync()).Id);

            var model = new PublicInfoModel
            {
                Message = rahivBxSliderSettings.Message,
                UseSandbox = rahivBxSliderSettings.UseSandbox
            };

            if (!model.UseSandbox && string.IsNullOrEmpty(model.Message))
                //no Use Sandbox
                return Content("");

            return View("~/Plugins/Widgets.RahivBXSlider/Views/PublicInfo.cshtml", model);
        }


    }
}
