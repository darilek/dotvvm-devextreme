using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotVVM.DevExtreme.Samples.ViewModels.ControlSamples.Button
{
	public class ButtonViewModel : SamplesViewModelBase
	{
        public override string Title { get; } = "Buttons example";
	    public int NumberOfClicks { get; set; }

        public void Submit()
        {
            WaitPlease();


            NumberOfClicks++;
        }
	}
}

