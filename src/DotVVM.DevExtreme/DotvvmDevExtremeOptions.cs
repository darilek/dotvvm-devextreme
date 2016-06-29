using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM.DevExtreme
{
    public class DotvvmDevExtremeOptions
    {
        public string GlobalizeJsUrl { get; set; } = "~/Scripts/globalize.js";
        public string CldrJsUrl { get; set; } = "~/Scripts/cldr.js";
        public string DevExtremeJsUrl { get; set; } = "~/Scripts/dx.web.js";
        public string DevExtremeCssCommonUrl { get; set; } = "~/Content/dx.common.css";
        public string DevExtremeCssThemeUrl { get; set; } = "~/Content/dx.light.css";
    }
}
