using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotVVM.DevExtreme.Samples.ViewModels.ControlSamples.DateBox
{
	public class DateBoxViewModel : SamplesViewModelBase
	{
        public override string Title { get; } = "DateBox example";

        public DateTime SelectedDate
        {
            get; set;
        }

        public void Submit()
        {
           WaitPlease();

        }

        public override Task Load()
        {
            if (!this.Context.IsPostBack)
            {
                this.SelectedDate = DateTime.Now;
            }
            return base.Load();
        }

    }
}

