using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;

using Avalonia.ReactiveUI;
using ReactiveUI;
using Organization.Client.ViewModels;

namespace Organization.Client.Views;

public class BaseWindow<TViewModel> : ReactiveWindow<TViewModel>
    where TViewModel : ViewModelBase
{
    public BaseWindow()
    {
        this.WhenActivated(disposableObject =>
        {
            var viewModel = ViewModel;
            if (viewModel is null)
                return;

            OnActivated(viewModel, disposableObject);
        });
    }

    protected virtual void OnActivated(TViewModel viewModel, CompositeDisposable disposableObject)
    {
        disposableObject.Add(viewModel.CloseWindowInteraction.RegisterHandler(CloseWindow));
        disposableObject.Add(viewModel.ShowMessageInteraction.RegisterHandler(ShowMessage));
    }

    private void CloseWindow(InteractionContext<object?, Unit> context)
    {
        Close(context.Input);
        context.SetOutput(Unit.Default);
    }

    private async Task ShowMessage(InteractionContext<MessageViewModel, Unit> context)
    {
        var window = new MessageWindow
        {
            ViewModel = context.Input
        };

        await window.ShowDialog(this);

        context.SetOutput(Unit.Default);
    }
}