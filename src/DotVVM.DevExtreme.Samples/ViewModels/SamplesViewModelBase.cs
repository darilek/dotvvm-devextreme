using System.Threading;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotVVM.DevExtreme.Samples.ViewModels
{
    public abstract class SamplesViewModelBase : DotvvmViewModelBase, ISamplesViewModelBase
    {
        public abstract string Title { get; }
        protected void WaitPlease()
        {
            Thread.Sleep(1000);
        }

        public override Task Init()
        {
            return base.Init();
        }
    }
}