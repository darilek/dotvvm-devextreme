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
    public class DateBox : HtmlWidgetControlBase
    {
        public DateBox() : base("dx-date-box", "dxDateBox")
        {
            
        }

        [MarkupOptions(AllowHardCodedValue = false)]
        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }
        public static readonly DotvvmProperty SelectedDateProperty
            = DotvvmProperty.Register<DateTime?, DateBox>(c => c.SelectedDate, null);

        public Command Changed
        {
            get { return (Command)GetValue(ChangedProperty); }
            set { SetValue(ChangedProperty, value); }
        }
        public static readonly DotvvmProperty ChangedProperty
            = DotvvmProperty.Register<Command, DateBox>(c => c.Changed, null);


        protected override void AddWidgetBindingProperties(KnockoutBindingGroup @group)
        {
            base.AddWidgetBindingProperties(@group);
            group.AddSimpleBinding("value", this, SelectedDateProperty);

            ICommandBinding commandBinding = base.GetCommandBinding(ChangedProperty, true);
            if (commandBinding != null)
            {
                string commandCall = KnockoutHelper.GenerateClientPostBackScript("Changed", commandBinding, this, false, false, false);
                group.Add("onChange", $"function(e) {{ (function() {{ {commandCall} }}).apply(e.element[0]); return false; }}");
            }
        }


        protected override void AddWidgetBindingToRender(IHtmlWriter writer, IDotvvmRequestContext context, KnockoutBindingGroup @group)
        {
            writer.AddAttribute("params", group.ToString());
        }
    }
}
