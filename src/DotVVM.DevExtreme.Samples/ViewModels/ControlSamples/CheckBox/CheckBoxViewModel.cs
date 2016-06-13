using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotVVM.DevExtreme.Samples.ViewModels.ControlSamples.CheckBox
{
	public class CheckBoxViewModel : SamplesViewModelBase
	{
        public bool? Checked { get; set; }
        public bool? Unchecked { get; set; }
        public bool? Intermediate { get; set; }
        public override string Title => "CheckBox sample";

	    public override Task Load()
	    {
            if (!this.Context.IsPostBack)
            {
                this.Checked = true;
                this.Unchecked = false;
                this.Intermediate = null;
            }
            return base.Load();
            return base.Load();
	    }
	}
}

