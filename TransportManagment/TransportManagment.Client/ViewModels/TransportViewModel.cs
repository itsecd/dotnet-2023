using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TransportManagment.Client.ViewModels;
public class TransportViewModel : ViewModelBase
{
    private int _transportId;
    [Required]
    public int TransportId
    {
        get => _transportId;
        set => this.RaiseAndSetIfChanged(ref _transportId, value);
    }
    private string _type = string.Empty;
    [Required]
    public string Type
    {
        get => _type;
        set => this.RaiseAndSetIfChanged(ref _type, value);
    }
    private string _model = string.Empty;
    [Required]
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
    public ReactiveCommand<Unit, TransportViewModel> OnSubmitCommand { get; }
    public TransportViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
