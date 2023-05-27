using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace OrganizationClient.ViewModels;
public class MessageViewModel : ViewModelBase
{
    public string Title { get; } = "Сообщение";

    public string Message { get; }
    public ReactiveCommand<Unit, Unit> OkCommand { get; }

    public MessageViewModel(string message)
    {
        Message = message;
        OkCommand = ReactiveCommand.CreateFromTask(Ok);
    }

    private async Task Ok()
    {
        await CloseWindowInteraction.Handle(null);
    }
}
