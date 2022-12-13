using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.SamplePlugin.Models
{
    public record SamplePluginModel : BaseNopModel
    {
        public string Text { get; set; }
    }
}
