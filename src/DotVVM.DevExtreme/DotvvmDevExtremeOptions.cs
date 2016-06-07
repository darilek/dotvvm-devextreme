using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM.DevExtreme
{
    public class DotvvmDevExtremeOptions
    {
        public string DevExtremeJsUrl { get; set; } = "~/Scripts/dx.webappjs.js";
        public string DevExtremeCssCommonUrl { get; set; } = "~/Content/dx.common.css";
        public string DevExtremeCssThemeUrl { get; set; } = "~/Content/dx.light.css";
    }
}
