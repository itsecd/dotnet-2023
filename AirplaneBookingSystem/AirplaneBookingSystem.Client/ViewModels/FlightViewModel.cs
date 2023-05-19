using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reactive;

namespace AirplaneBookingSystem.Client.ViewModels;
public class FlightViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private int _numberOfFlight;
    
    public int NumberOfFlight
    {
        get => _numberOfFlight;
        set => this.RaiseAndSetIfChanged(ref _numberOfFlight, value);
    }
    private string _departureCity = string.Empty;
    
    public string DepartureCity
    {
        get => _departureCity;
        set => this.RaiseAndSetIfChanged(ref _departureCity, value);
    }
    private string _arrivalCity = string.Empty;
    
    public string ArrivalCity
    {
        get => _arrivalCity;
        set => this.RaiseAndSetIfChanged(ref _arrivalCity, value);
    }
    private DateTime _departureDate;
    
    public DateTime DepartureDate
    {
        get => _departureDate;
        set => this.RaiseAndSetIfChanged(ref _departureDate, value);
    }
    private DateTime _arrivalDate;
    
    public DateTime ArrivalDate
    {
        get => _arrivalDate;
        set => this.RaiseAndSetIfChanged(ref _arrivalDate, value);
    }
    private int _airplaneId;
    [Required]
    public int AirplaneId
    {
        get => _airplaneId;
        set => this.RaiseAndSetIfChanged(ref _airplaneId, value);
    }
    public ReactiveCommand<Unit, FlightViewModel> OnSubmitCommand { get; }
    public FlightViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}