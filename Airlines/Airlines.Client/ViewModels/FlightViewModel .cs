using Avalonia.Controls;
using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reactive;

namespace Airlines.Client.ViewModels;
public class FlightViewModel : ViewModelBase
{
    private int _id;
    [Required]
    public int Id { 
        get=>_id; 
        set=>this.RaiseAndSetIfChanged(ref _id,value); 
    }

    private int _airplaneId;
    [Required]
    public int AirplaneId
    {
        get => _airplaneId;
        set => this.RaiseAndSetIfChanged(ref _airplaneId, value);
    }

    private string _flightCode = string.Empty;
    [Required]
    public string? FlightCode
    {
        get => _flightCode;
        set => this.RaiseAndSetIfChanged(ref _flightCode, value);
    }

    private string _source = string.Empty;
    [Required]
    public string? Source
    {
        get => _source;
        set => this.RaiseAndSetIfChanged(ref _source, value);
    }
    private string _destination = string.Empty;
    [Required]
    public string? Destination
    {
        get => _destination;
        set =>this.RaiseAndSetIfChanged(ref _destination, value);
    }
    private DateTime _departureDate;
    [Required]
    public DateTime DepartureDate
    {
        get => _departureDate;
        set {
            var convDate = new DateTimeOffset(_departureDate);
            this.RaiseAndSetIfChanged(ref convDate, value); 
        }
    }
    private DateTime _arrivalDate;
    [Required]
    public DateTime ArrivalDate
    {
        get => _arrivalDate;
        set => this.RaiseAndSetIfChanged(ref _arrivalDate, value);
    }
    private double _flightDuration;
    [Required]
    public double FlightDuration
    {
        get => _flightDuration;
        set => this.RaiseAndSetIfChanged(ref _flightDuration, value);
    }
    private string _airplaneType = string.Empty;
    [Required]
    public string? AirplaneType
    {
        get => _airplaneType;
        set => this.RaiseAndSetIfChanged(ref _airplaneType, value);
    }
    public ReactiveCommand<Unit, FlightViewModel> OnSubmitCommand { get; }

    public FlightViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }

}
