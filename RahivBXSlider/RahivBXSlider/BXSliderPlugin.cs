using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using RahivBXSlider.Components;

namespace RahivBXSlider
{
    public class BXSliderPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;

        public bool HideInWidgetList => false;

        public BXSliderPlugin(ISettingService settingService, IWebHelper webHelper, ILocalizationService localizationService)
        {
            this._webHelper = webHelper;
            this._settingService = settingService;
            this._localizationService = localizationService;
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return WidgetsRahivBXSliderViewComponent.ViewComponentName;
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop });
        }


        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsRahivBXSlider/Configure";
        }


        public override async Task InstallAsync()
        {
            var settings = new BXSliderSettings()
            {
                UseSandbox = true,
                Message = "Hello World"
            };
            await _settingService.SaveSettingAsync(settings);

            await _localizationService.AddLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.RahivBXSlider.UseSandbox"] = "UseSandbox",
                ["Plugins.Widgets.RahivBXSlider.Message"] = "Message",
            });

            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            await _settingService.DeleteSettingAsync<BXSliderSettings>();
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.RahivBXSlider");

            await base.UninstallAsync();
        }



    }
}
