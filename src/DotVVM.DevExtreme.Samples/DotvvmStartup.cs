using System.Web.Hosting;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using DotVVM.Framework;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;

namespace DotVVM.DevExtreme.Samples
{
    public class DotvvmStartup : IDotvvmStartup
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));


            config.AddDevExtremeConfiguration();

            config.Resources.Register(ResourceNames.Styles.DxCommon, new StylesheetResource() { Url = "http://cdn3.devexpress.com/jslib/15.2.9/css/dx.common.css" });
            config.Resources.Register(ResourceNames.Styles.DxLight, new StylesheetResource() { Url = "http://cdn3.devexpress.com/jslib/15.2.9/css/dx.light.css", Dependencies = new [] {ResourceNames.Styles.DxCommon}});

            config.Resources.Register(ResourceNames.Scripts.DxWebApps, new ScriptResource() { CdnUrl = "http://cdn3.devexpress.com/jslib/15.2.9/js/dx.webappjs.js", Dependencies = new[] { ResourceConstants.JQueryResourceName, ResourceConstants.KnockoutJSResourceName, ResourceConstants.GlobalizeResourceName } });

        }
    }
}
