using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace DotVVM.DevExtreme.Controls
{
    public abstract class HtmlDevExtremeControlBase : HtmlGenericControl, IHtmlDevExtremeControl
    {
        public HtmlDevExtremeControlBase(string controlTagName) : base(controlTagName)
        {
        }


        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            this.RegisterDevExtremeDependencies(context);
            base.OnPreRender(context);
        }

    }
}
