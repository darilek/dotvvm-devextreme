using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotVVM.DevExtreme.Samples.ViewModels.ControlSamples.Button
{
	public class ButtonViewModel : SamplesViewModelBase
	{
        public int NumberOfClicks { get; set; }

        public void Submit()
        {
            NumberOfClicks++;
        }
	}
}

