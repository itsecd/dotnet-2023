using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Airline.Client.ViewModels;
public class AirplaneViewModel : ViewModelBase
{
    private int _id;
    public int Id 
    { 
        get => _id; 
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _model = string.Empty;
    [Required]
    public string Model
    { 
        get => _model;
        set => this.RaiseAndSetIfChanged(ref _model, value);
    }
    private int _loadCapacity;
    public int LoadCapacity
    {
        get => _loadCapacity;
        set => this.RaiseAndSetIfChanged(ref _loadCapacity, value);
    }
    private int _perfomance;

    public int Perfomance
    {
        get => _perfomance;
        set => this.RaiseAndSetIfChanged(ref _perfomance, value);
    }
    private int _passengerCapacity;
    public int PassengerCapacity
    {
        get => _passengerCapacity;
        set => this.RaiseAndSetIfChanged(ref _passengerCapacity, value);
    }

    public ReactiveCommand<Unit, AirplaneViewModel> OnSubmitAirplaneCommand { get; }
    public AirplaneViewModel()
    {
        OnSubmitAirplaneCommand = ReactiveCommand.Create(() => this);
    }
}
