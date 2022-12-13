using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.SamplePlugin.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.SamplePlugin.Controllers
{
    public class SamplePluginController : BasePluginController
    {
        #region Fields
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;
        private readonly INotificationService _notificationService;
        private readonly ILocalizationService _localizationService;
        #endregion

        #region Ctor
        public SamplePluginController(IStoreContext storeContext, ISettingService settingService, INotificationService notificationService, ILocalizationService localizationService)
        {
            _storeContext = storeContext;
            _settingService = settingService;
            _notificationService = notificationService;
            _localizationService = localizationService;
        }

        #endregion

        #region Methos
        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public async Task<IActionResult> Configure()
        {
            var model = new SamplePluginModel();
            //load settings for active store scope
            var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var sendinblueSettings = await _settingService.LoadSettingAsync<SampleSettings>(storeId);
            model.Text = sendinblueSettings.Text;

            return View("~/Plugins/SamplePlugin/Views/Configure.cshtml", model);
        }

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        [HttpPost, ActionName("Configure")]
        [FormValueRequired("save")]
        public async Task<IActionResult> Configure(SamplePluginModel model)
        {
            if (!ModelState.IsValid)
                return await Configure();

            var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var sendinblueSettings = await _settingService.LoadSettingAsync<SampleSettings>(storeId);

            //set API key
            sendinblueSettings.Text = model.Text;
            await _settingService.SaveSettingAsync(sendinblueSettings, settings => settings.Text, clearCache: false);
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }
        #endregion
    }
}
