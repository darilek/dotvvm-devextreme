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

        public static void AddDevExtremeConfiguration(this DotvvmConfiguration config, Action<DotvvmDevExtremeOptions> optionsDelegate)
        {
            DotvvmDevExtremeOptions options = new DotvvmDevExtremeOptions();
            if (optionsDelegate != null)
            {
                optionsDelegate(options);
            }

            AddDevExtremeConfiguration(config, options);
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
            config.Resources.Register(ResourceNames.Styles.DxCommon, new StylesheetResource() { Location = options.DevExtremeCssCommonResourceLocation });
            config.Resources.Register(ResourceNames.Styles.DxTheme, new StylesheetResource() { Location = options.DevExtremeCssThemeResourceLocation, Dependencies = new[] { ResourceNames.Styles.DxCommon } });

            /*if (options.GlobalizeCompatibilityMode == GlobalizeCompatibilityMode.Default || options.GlobalizeCompatibilityMode == GlobalizeCompatibilityMode.Globalize_0_1)
            {
                ScriptResource globalizeResource = new ScriptResource()
                {
                    Location = options.GlobalizeJsResourceLocation,
                    Dependencies = new[] { ResourceNames.Scripts.Cldr }
                };

            } else
            {
                throw new NotImplementedException("Globalize 1.x support is not supoortd for now. Use compatibility mode instead");
            }*/

            ScriptResource cldrResource = new ScriptResource()
            {
                Location = options.CldrJsResourceLocation,
            };

            ScriptResource globalizeResource = new ScriptResource()
            {
                Location = options.GlobalizeJsResourceLocation,
                Dependencies = new[] { ResourceNames.Scripts.Cldr }
            };



            // scripts
            ScriptResource devExtremeResource = new ScriptResource()
            {
                Location = options.DevExtremeJsResourceLocation,
                Dependencies = new [] { ResourceConstants.JQueryResourceName, ResourceConstants.KnockoutJSResourceName, ResourceNames.Scripts.Globalize}
            };

            ScriptResource dotvvmDevExtremeResource = new ScriptResource()
            {
                Location = new EmbeddedResourceLocation(typeof(DevExtremeExtensions).Assembly, "DotVVM.DevExtreme.Resources.Scripts.DotVVM.DevExtreme.js"),
                Dependencies = new string[] { ResourceConstants.KnockoutJSResourceName, ResourceConstants.DotvvmResourceName, ResourceConstants.GlobalizeResourceName, String.Format(ResourceConstants.GlobalizeCultureResourceName, "cs-cz") }
            };

            config.Resources.Register(ResourceNames.Scripts.Cldr, cldrResource);
            config.Resources.Register(ResourceNames.Scripts.Globalize, globalizeResource);
            config.Resources.Register(ResourceNames.Scripts.DxWeb, devExtremeResource);
            config.Resources.Register(ResourceNames.Scripts.DotvvmDevExtreme, dotvvmDevExtremeResource);

        }

        internal static void RegisterDevExtremeDependencies(this IHtmlDevExtremeControl control, IDotvvmRequestContext context)
        {
            context.ResourceManager.AddRequiredResource(ResourceNames.Styles.DxTheme);
            context.ResourceManager.AddRequiredResource(ResourceNames.Scripts.DxWeb);

            context.ResourceManager.AddRequiredResource(ResourceNames.Scripts.Cldr);
            context.ResourceManager.AddRequiredResource(ResourceNames.Scripts.Globalize);
            context.ResourceManager.AddRequiredResource(ResourceNames.Scripts.DotvvmDevExtreme);

        }
    }
}
