using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Routing;

namespace DotVVM.DevExtreme.Samples.ViewModels
{
    public class DefaultViewModel : SamplesViewModelBase
    {
        public override string Title { get; } = "DotVVM DevExtreme wrappers examples";


        public List<RouteBase> Routes { get; set; }


        public DefaultViewModel()
        {
            //if (HttpContext.Current.GetOwinContext().GetDotvvmContext() == null)
            //{
            //    throw new Exception("DotVVM context was not found!");
            //}

        }

        public override Task Init()
        {
            var list = new List<RouteBase>(Context.Configuration.RouteTable);
            Routes = list.GetRange(1, list.Count - 1);
            return base.Init();
        }
    }
}
