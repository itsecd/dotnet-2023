using System;
using ReactiveUI;
using System.Reactive;
using System.ComponentModel.DataAnnotations;

namespace TransportManagment.Client.ViewModels;
public class TransportInfoViewModel : ViewModelBase
{
    private string _type = string.Empty;
    public string Type
    {
        get => _type;
        set => this.RaiseAndSetIfChanged(ref _type, value);
    }
    private string _model = string.Empty;
    public string Model
    {
        get => _model;
        set => this.RaiseAndSetIfChanged(ref _model, value);
    }
    private DateTimeOffset _dateMake = DateTimeOffset.MinValue;
    public DateTimeOffset DateMake
    { 
        get => _dateMake; 
        set => this.RaiseAndSetIfChanged(ref _dateMake, value);
    }
    private int _count = 0;
    public int Count 
    {
        get => _count;
        set => this.RaiseAndSetIfChanged(ref _count, value);
    }
    public ReactiveCommand<Unit, TransportInfoViewModel> OnSubmitCommand { get; }
    public TransportInfoViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
