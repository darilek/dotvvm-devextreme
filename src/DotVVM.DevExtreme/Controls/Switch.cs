using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace DotVVM.DevExtreme.Controls
{
    public class Switch : HtmlEditWidgetControlBase
    {
        public Switch() : base("dx-switch", "dxSwitch")
        {

        }

        public string OffText
        {
            get { return (string)GetValue(OffTextProperty); }
            set { SetValue(OffTextProperty, value); }
        }
        public static readonly DotvvmProperty OffTextProperty
            = DotvvmProperty.Register<string, Switch>(c => c.OffText, "Off");


        public string OnText
        {
            get { return (string)GetValue(OnTextProperty); }
            set { SetValue(OnTextProperty, value); }
        }
        public static readonly DotvvmProperty OnTextProperty
            = DotvvmProperty.Register<string, Switch>(c => c.OnText, "On");


        public bool Value
        {
            get { return (bool)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DotvvmProperty ValueProperty
            = DotvvmProperty.Register<bool, Switch>(c => c.Value, false);


        protected override void AddWidgetBindingProperties(KnockoutBindingGroup @group)
        {
            base.AddWidgetBindingProperties(@group);
            group.AddSimpleBinding("value", this, ValueProperty);
            group.AddSimpleBinding("onText", this, OnTextProperty);
            group.AddSimpleBinding("offText", this, OffTextProperty);
        }
    }
}
