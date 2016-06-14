using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace DotVVM.DevExtreme.Controls
{
    public class TextBox : HtmlEditWidgetControlBase
    {
        public TextBox() : base("dx-text-box", "dxTextBox")
        {

        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }
        public static readonly DotvvmProperty PlaceholderProperty
            = DotvvmProperty.Register<string, TextBox>(c => c.Placeholder, null);

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DotvvmProperty ValueProperty
            = DotvvmProperty.Register<string, TextBox>(c => c.Value, null);

        [MarkupOptions(AllowBinding = false)]
        public TextBoxMode Mode
        {
            get { return (TextBoxMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }
        public static readonly DotvvmProperty ModeProperty
            = DotvvmProperty.Register<TextBoxMode, TextBox>(c => c.Mode, TextBoxMode.Text);

        protected override void AddWidgetBindingProperties(KnockoutBindingGroup group)
        {
            base.AddWidgetBindingProperties(group);
            group.AddSimpleBinding("placeholder", this, PlaceholderProperty);
            group.AddSimpleBinding("value", this, ValueProperty);
            //group.AddSimpleBinding("mode", this, ModeProperty);
            group.Add("mode", this.GetValue(ModeProperty).ToString().ToLower(), true);
        }
    }
}
