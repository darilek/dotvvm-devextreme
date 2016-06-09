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
            //config.AllowBindingDebugging = true;

            config.DefaultCulture = "cs-CZ";
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));

            config.Resources.Register("common", new ScriptResource() { Url = "~/Scripts/common.js", Dependencies = new[] { ResourceConstants.GlobalizeResourceName } });

            config.Resources.Register(ResourceConstants.GlobalizeCultureResourceName, new ScriptResource() {Url = "~/Scripts/jquery.globalize/cultures/globalize.culture.cs-CZ.js" });

            config.AddDevExtremeConfiguration();

        }
    }
}
