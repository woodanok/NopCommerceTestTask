using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Plugin.SamplePlugin.Components;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.SamplePlugin
{
    public class SamplePlugin : BasePlugin, IWidgetPlugin
    {
        #region Fields
        private readonly IWebHelper _webHelper;
        #endregion

        #region Ctor
        public SamplePlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }
        #endregion

        #region Methods

        public Type GetWidgetViewComponent(string widgetZone)
        {
            return typeof(WidgetsSampleViewComponent);
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.ProductDetailsTop });
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/SamplePlugin/Configure";
        }
        #endregion

        public bool HideInWidgetList => true;

    }
}
