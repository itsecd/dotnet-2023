using ReactiveUI;
using System;
using System.Reactive;

namespace RealtorClient.ViewModels;
public class ApplicationViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _type;
    public string Type
    {
        get => _type;
        set => this.RaiseAndSetIfChanged(ref _type, value);
    }

    private uint _cost;
    public uint Cost
    {
        get => _cost;
        set => this.RaiseAndSetIfChanged(ref _cost, value);
    }

    private DateTimeOffset _data;
    public DateTimeOffset Data
    {
        get => _data;
        set => this.RaiseAndSetIfChanged(ref _data, value);
    }

    private int _clientId;
    public int ClientId
    {
        get => _clientId;
        set => this.RaiseAndSetIfChanged(ref _clientId, value);
    }
    public ReactiveCommand<Unit, ApplicationViewModel> OnSubmitCommand { get; }

    public ApplicationViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
