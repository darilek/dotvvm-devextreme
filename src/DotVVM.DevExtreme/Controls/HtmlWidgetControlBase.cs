using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace DotVVM.DevExtreme.Controls
{
    public abstract class HtmlWidgetControlBase : HtmlDevExtremeControlBase
    {
        public HtmlWidgetControlBase(string controlTagName, string widgetName) : base(controlTagName)
        {
            BasicValidations.AssertIsNotNullOrEmpty(widgetName, nameof(widgetName));

            this.WidgetName = widgetName;
        }

        protected string WidgetName
        {
            get; private set;
        }

        protected virtual void AddWidgetBindingProperties(KnockoutBindingGroup group)
        {

        }

        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            base.AddAttributesToRender(writer, context);
            KnockoutBindingGroup group = new KnockoutBindingGroup();
            AddWidgetBindingProperties(group);

            writer.AddKnockoutDataBind(this.WidgetName, group);
        }

    }
}
