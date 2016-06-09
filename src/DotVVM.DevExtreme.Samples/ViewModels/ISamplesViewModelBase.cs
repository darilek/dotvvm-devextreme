using DotVVM.Framework.ViewModel;

namespace DotVVM.DevExtreme.Samples.ViewModels
{
    public interface ISamplesViewModelBase : IDotvvmViewModel
    {
        string Title { get; }
    }
}