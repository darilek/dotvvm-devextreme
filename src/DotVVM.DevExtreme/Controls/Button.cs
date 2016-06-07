using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace DotVVM.DevExtreme.Controls
{
    public class Button : HtmlWidgetControlBase
    {
        public Button() : base("dx-button", "dxButton")
        {
           
        }

        public string Text
        {
            get { return Convert.ToString(GetValue(TextProperty)); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DotvvmProperty TextProperty =
            DotvvmProperty.Register<string, Button>(t => t.Text, String.Empty);

        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }
        public static readonly DotvvmProperty HintProperty
            = DotvvmProperty.Register<string, Button>(c => c.Hint, String.Empty);


        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        public static readonly DotvvmProperty EnabledProperty
            = DotvvmProperty.Register<bool, Button>(c => c.Enabled, true);

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DotvvmProperty IconProperty
            = DotvvmProperty.Register<string, Button>(c => c.Icon, null);

        [MarkupOptions(AllowBinding = false)]
        public ButtonType Type
        {
            get { return (ButtonType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }
        public static readonly DotvvmProperty TypeProperty
            = DotvvmProperty.Register<ButtonType, Button>(c => c.Type, ButtonType.Normal);




        public Command Click
        {
            get { return (Command)GetValue(ClickProperty); }
            set { SetValue(ClickProperty, value); }
        }

        public static readonly DotvvmProperty ClickProperty
            = DotvvmProperty.Register<Command, Button>(c => c.Click, null);


        protected override void AddWidgetBindingProperties(KnockoutBindingGroup group)
        {
            base.AddWidgetBindingProperties(group);
            //group.Add("text", this, TextProperty, () => group.Add("text", $"'{this.Text}'"));
            group.AddSimpleBinding("text", this, TextProperty);
            group.Add("icon", this, IconProperty, () => group.Add("icon", $"'{this.Icon}'"));
            group.Add("type", $"'{this.Type}'".ToLower());
            group.AddSimpleBinding("hint", this, HintProperty);
            group.AddNegation("disabled", this, EnabledProperty, () => this.Enabled);

            ICommandBinding commandBinding = base.GetCommandBinding(ClickProperty, true);
            if (commandBinding != null)
            {
                string commandCall = KnockoutHelper.GenerateClientPostBackScript("Click", commandBinding, this, false, false, false);
                group.Add("onClick", $"function(e) {{ (function() {{ {commandCall} }}).apply(e.element[0]); return false; }}");
            }
        }
    }
}
