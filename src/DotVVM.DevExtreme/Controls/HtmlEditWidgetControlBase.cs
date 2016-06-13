using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace DotVVM.DevExtreme.Controls
{
    public abstract class HtmlEditWidgetControlBase : HtmlWidgetControlBase
    {
        public HtmlEditWidgetControlBase(string controlTagName, string widgetName) : base(controlTagName, widgetName)
        {
            
        }

        public bool ReadOnly
        {
            get { return (bool)GetValue(ReadOnlyProperty); }
            set { SetValue(ReadOnlyProperty, value); }
        }
        public static readonly DotvvmProperty ReadOnlyProperty
            = DotvvmProperty.Register<bool, HtmlEditWidgetControlBase>(c => c.ReadOnly, false);

        protected override void AddWidgetBindingProperties(KnockoutBindingGroup @group)
        {
            base.AddWidgetBindingProperties(@group);
            group.AddSimpleBinding("readOnly", this, ReadOnlyProperty);
        }
    }
}
