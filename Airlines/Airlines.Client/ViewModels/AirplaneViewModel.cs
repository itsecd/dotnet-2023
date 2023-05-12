using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reactive;

namespace Airlines.Client.ViewModels;
public class AirplaneViewModel : ViewModelBase
{

    private int _id;
    [Required]
    public int Id { 
        get=>_id; 
        set=>this.RaiseAndSetIfChanged(ref _id,value); 
    }

    private string _model = string.Empty;
    [Required]
    public string? Model
    {
        get => _model;
        set => this.RaiseAndSetIfChanged(ref _model, value);
    }

    private int _carryingCapacity;
    [Required]
    public int CarryingCapacity
    {
        get => _carryingCapacity;
        set => this.RaiseAndSetIfChanged(ref _carryingCapacity, value);
    }
    private int _capability;
    [Required]
    public int Capability
    {
        get => _capability;
        set => this.RaiseAndSetIfChanged(ref _capability, value);
    }
    private int _seatingCapacity;
    [Required]
    public int SeatingCapacity
    {
        get => _capability;
        set => this.RaiseAndSetIfChanged(ref _seatingCapacity, value);
    }
    public ReactiveCommand<Unit, AirplaneViewModel> OnSubmitCommand { get; }

    public AirplaneViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }

}
