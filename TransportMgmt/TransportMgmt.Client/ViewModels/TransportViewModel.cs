using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TransportMgmt.Client.ViewModels;

public class TransportViewModel : ViewModelBase
{

    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _stateNumber = string.Empty;
    [Required]
    public string StateNumber
    {
        get => _stateNumber;
        set => this.RaiseAndSetIfChanged(ref _stateNumber, value);
    }

    private int _typeId;
    [Required]
    public int TypeId
    {
        get => _typeId;
        set => this.RaiseAndSetIfChanged(ref _typeId, value);
    }

    private int _modelId;
    [Required]
    public int ModelId
    {
        get => _modelId;
        set => this.RaiseAndSetIfChanged(ref _modelId, value);
    }

    private DateTimeOffset _dateMake;
    [Required]
    public DateTimeOffset DateMake
    {
        get => _dateMake;
        set => this.RaiseAndSetIfChanged(ref _dateMake, value);
    }

    public ReactiveCommand<Unit, TransportViewModel> TransportOnSubmitCommand { get; }

    public TransportViewModel()
    {
        TransportOnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
