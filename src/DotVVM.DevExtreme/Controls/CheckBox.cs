using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace DotVVM.DevExtreme.Controls
{
    public class CheckBox : HtmlEditWidgetControlBase
    {
        public CheckBox() : base("dx-check-box", "dxCheckBox")
        {
            
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DotvvmProperty TextProperty
            = DotvvmProperty.Register<string, CheckBox>(c => c.Text, null);

        public bool? Value
        {
            get { return (bool?)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DotvvmProperty ValueProperty
            = DotvvmProperty.Register<bool?, CheckBox>(c => c.Value, false);



        protected override void AddWidgetBindingProperties(KnockoutBindingGroup @group)
        {
            base.AddWidgetBindingProperties(@group);
            group.AddSimpleBinding("text", this, TextProperty);
            group.AddSimpleBinding("value", this, ValueProperty);
        }
    }
}
