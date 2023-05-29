using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Organization.Client.ViewModels;
public class MessageViewModel : ViewModelBase
{
    public string Title { get; } = "Сообщение";

    public string Message { get; }
    public ReactiveCommand<Unit, Unit> OkCommand { get; }

    public MessageViewModel(string message, string title="Warning")
    {
        Message = message;
        Title = title;
        OkCommand = ReactiveCommand.CreateFromTask(Ok);
    }

    private async Task Ok()
    {
        await CloseWindowInteraction.Handle(null);
    }
}
