using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;


namespace TransportManagment.Client.ViewModels;
public class TransportTimeViewModel : ViewModelBase
{
    private int _transportId;
    public int TransportId
    {
        get => _transportId;
        set => this.RaiseAndSetIfChanged(ref _transportId, value);
    }
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
    private double _time = 0;
    public double Time 
    {
        get => _time;
        set => this.RaiseAndSetIfChanged(ref _time, value);
    }
    public ReactiveCommand<Unit, TransportTimeViewModel> OnSubmitCommand { get; }
    public TransportTimeViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
