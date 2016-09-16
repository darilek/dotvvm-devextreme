using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotVVM.DevExtreme.Samples.ViewModels.ControlSamples.Switch
{
	public class SwitchViewModel : SamplesViewModelBase
    {
        public bool? Checked { get; set; }
        public bool? Unchecked { get; set; }
        public override string Title => "Switch sample";

        public override Task Load()
        {
            if (!this.Context.IsPostBack)
            {
                this.Checked = true;
                this.Unchecked = false;
            }
            return base.Load();
        }

    }
}

