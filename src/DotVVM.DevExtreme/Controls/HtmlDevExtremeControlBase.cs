using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace DotVVM.DevExtreme.Controls
{
    public abstract class HtmlDevExtremeControlBase : HtmlGenericControl
    {
        public HtmlDevExtremeControlBase(string controlTagName, string widgetName) : base(controlTagName)
        {
            BasicValidations.AssertIsNotNullOrEmpty(widgetName, nameof(widgetName));

            this.WidgetName = widgetName;
        }

        protected string WidgetName
        {
            get; private set;
        }

        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            context.ResourceManager.AddRequiredResource(ResourceNames.Scripts.DxWebApps);
            context.ResourceManager.AddRequiredResource(ResourceNames.Styles.DxLight);
            base.OnPreRender(context);
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
