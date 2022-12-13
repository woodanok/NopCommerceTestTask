using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Customers;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.SamplePlugin.Components
{
    /// <summary>
    /// Represents view component to embed tracking script on pages
    /// </summary>
    public class WidgetsSampleViewComponent : NopViewComponent
    {
        #region Fields
        private readonly SampleSettings _sampleSettings;
        #endregion

        #region Ctor
        public WidgetsSampleViewComponent(SampleSettings sampleSettings)
        {
            _sampleSettings = sampleSettings;
        }
        #endregion

        #region Methods
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var information = _sampleSettings.Text;

            return View("~/Plugins/SamplePlugin/Views/PublicInfo.cshtml", information);
        }

        #endregion
    }
}
