using ReactiveUI;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Organization.Client.ViewModels;
public class ViewModelBase : ReactiveObject
{
    public Interaction<object?, Unit> CloseWindowInteraction { get; } = new();
    public Interaction<MessageViewModel, Unit> ShowMessageInteraction { get; } = new();

    protected void ShowMessage(MessageViewModel messageViewModel)
    {
        RxApp.MainThreadScheduler.Schedule(async () =>
        {
            try
            {
                await ShowMessageInteraction.Handle(messageViewModel);
            }
            catch
            {
            }
        });
    }
}
