﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Configuration;

namespace Nop.Plugin.SamplePlugin
{
    public class SampleSettings : ISettings
    {
        public string Text { get; set; }
    }
}
