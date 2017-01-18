using DotVVM.Framework.ResourceManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM.DevExtreme
{
    public class DotvvmDevExtremeOptions
    {
        public const string GlobalizeJsUrl = "~/Scripts/globalize.js";
        public const string CldrJsUrl = "~/Scripts/cldr.js";
        public const string DevExtremeJsUrl = "~/Scripts/dx.web.js";

        public const string DevExtremeGlobalizeBridgeJsUrl = "~/Scripts/dx.globalize.js";

        public const string DevExtremeCssCommonUrl = "~/Content/dx.common.css";
        public const string DevExtremeCssThemeUrl  = "~/Content/dx.light.css";

        public GlobalizeCompatibilityMode GlobalizeCompatibilityMode { get; set; } = GlobalizeCompatibilityMode.Default;

        public LocalFileResourceLocation GlobalizeJsResourceLocation { get; set; } = new LocalFileResourceLocation(GlobalizeJsUrl);
        public LocalFileResourceLocation CldrJsResourceLocation { get; set; } = new LocalFileResourceLocation(CldrJsUrl);
        public LocalFileResourceLocation DevExtremeJsResourceLocation { get; set; } = new LocalFileResourceLocation(DevExtremeJsUrl);
        public LocalFileResourceLocation DevExtremeCssCommonResourceLocation { get; set; } = new LocalFileResourceLocation(DevExtremeCssCommonUrl);
        public LocalFileResourceLocation DevExtremeCssThemeResourceLocation { get; set; } = new LocalFileResourceLocation(DevExtremeCssThemeUrl);
    }

    public enum GlobalizeCompatibilityMode
    {
        Default = 0,

        Globalize_0_1 = 1,

        Globalize_1_x = 2
    }
}
