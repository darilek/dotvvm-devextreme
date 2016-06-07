using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.DevExtreme.Controls;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ResourceManagement;

namespace DotVVM.DevExtreme
{
    public static class DevExtremeExtensions
    {
        public static void AddDevExtremeConfiguration(this DotvvmConfiguration config)
        {
            AddDevExtremeConfiguration(config, new DotvvmDevExtremeOptions());
        }

        public static void AddDevExtremeConfiguration(this DotvvmConfiguration config, DotvvmDevExtremeOptions options)
        {
            BasicValidations.AssertIsNotNull(options, nameof(options));

            RegisterControls(config);
            RegisterResources(config, options);
        }

        private static void RegisterControls(DotvvmConfiguration config)
        {
            config.Markup.Controls.Add(new DotvvmControlConfiguration()
            {
                TagPrefix = "dx",
                Assembly = typeof(IDevExtremeControl).Assembly.GetName().Name,
                Namespace = typeof(IDevExtremeControl).Namespace
            });

        }

        private static void RegisterResources(DotvvmConfiguration config, DotvvmDevExtremeOptions options)
        {
            // CSS
            config.Resources.Register(ResourceNames.Styles.DxCommon, new StylesheetResource() { Url = options.DevExtremeCssCommonUrl });
            config.Resources.Register(ResourceNames.Styles.DxTheme, new StylesheetResource() { Url = options.DevExtremeCssThemeUrl, Dependencies = new[] { ResourceNames.Styles.DxCommon } });

            // scripts
            ScriptResource devExtremeResource = new ScriptResource()
            {
                Url = options.DevExtremeJsUrl,
                Dependencies = new [] { ResourceConstants.JQueryResourceName, ResourceConstants.KnockoutJSResourceName, ResourceConstants.GlobalizeResourceName}
            };

            ScriptResource dotvvmDevExtremeResource = new ScriptResource()
            {
                Url = "DotVVM.DevExtreme.Resources.Scripts.DotVVM.DevExtreme.js",
                EmbeddedResourceAssembly = typeof(DevExtremeExtensions).Assembly.GetName().Name,
                GlobalObjectName = "devextreme",
                Dependencies = new string[] { ResourceConstants.KnockoutJSResourceName, ResourceConstants.DotvvmResourceName }
            };

            config.Resources.Register(ResourceNames.Scripts.DxWebApps, devExtremeResource);
            config.Resources.Register(ResourceNames.Scripts.DotvvmDevExtreme, dotvvmDevExtremeResource);

        }

        internal static void RegisterDevExtremeDependencies(this IHtmlDevExtremeControl control, IDotvvmRequestContext context)
        {
            context.ResourceManager.AddRequiredResource(ResourceNames.Styles.DxTheme);
            context.ResourceManager.AddRequiredResource(ResourceNames.Scripts.DxWebApps);

            context.ResourceManager.AddRequiredResource(ResourceNames.Scripts.DotvvmDevExtreme);

        }
    }
}
