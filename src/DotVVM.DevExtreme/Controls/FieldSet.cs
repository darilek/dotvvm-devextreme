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
    [ControlMarkupOptions(AllowContent = false)]
    public class FieldSet : HtmlGenericControl
    {
        public FieldSet() : base("div")
        {
            
        }

        [MarkupOptions(MappingMode = MappingMode.InnerElement)]
        public ITemplate HeaderTemplate
        {
            get { return (ITemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }
        public static readonly DotvvmProperty HeaderTemplateProperty
            = DotvvmProperty.Register<ITemplate, FieldSet>(c => c.HeaderTemplate, null);


        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            base.AddAttributesToRender(writer, context);
            writer.AddAttribute("class", "dx-fieldset");
        }

        protected override void RenderContents(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            base.RenderContents(writer, context);
            if (this.HeaderTemplate != null)
            {
                
            }
        }
    }
}
