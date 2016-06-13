using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Binding;
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

        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }
        public static readonly DotvvmProperty HintProperty
            = DotvvmProperty.Register<string, HtmlWidgetControlBase>(c => c.Hint, String.Empty);


        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        public static readonly DotvvmProperty EnabledProperty
            = DotvvmProperty.Register<bool, HtmlWidgetControlBase>(c => c.Enabled, true);

        protected virtual void AddWidgetBindingProperties(KnockoutBindingGroup group)
        {
            group.AddSimpleBinding("hint", this, HintProperty);
            group.AddNegation("disabled", this, EnabledProperty, () => this.Enabled);

        }

        protected virtual void AddWidgetBindingToRender(IHtmlWriter writer, IDotvvmRequestContext context, KnockoutBindingGroup group)
        {
            writer.AddKnockoutDataBind(this.WidgetName, group);
        }

        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            base.AddAttributesToRender(writer, context);
            KnockoutBindingGroup group = new KnockoutBindingGroup();
            AddWidgetBindingProperties(group);

            AddWidgetBindingToRender(writer, context, group);

        }

    }
}
