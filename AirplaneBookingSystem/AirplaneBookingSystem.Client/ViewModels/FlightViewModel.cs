using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
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
    [Required]
    public int NumberOfFlight
    {
        get => _numberOfFlight;
        set => this.RaiseAndSetIfChanged(ref _numberOfFlight, value);
    }
    private string _departureCity = string.Empty;
    [Required]
    public string DepartureCity
    {
        get => _departureCity;
        set => this.RaiseAndSetIfChanged(ref _departureCity, value);
    }
    private string _arrivalCity = string.Empty;
    [Required]
    public string ArrivalCity
    {
        get => _arrivalCity;
        set => this.RaiseAndSetIfChanged(ref _arrivalCity, value);
    }
    private DateTimeOffset _departureDate = DateTime.Today;
    [Required]
    public DateTimeOffset DepartureDate
    {
        get => _departureDate;
        set => this.RaiseAndSetIfChanged(ref _departureDate, value);
    }
    private DateTimeOffset _arrivalDate = DateTime.Today;
    [Required]
    public DateTimeOffset ArrivalDate
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