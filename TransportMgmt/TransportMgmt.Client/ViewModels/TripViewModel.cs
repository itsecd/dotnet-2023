using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TransportMgmt.Client.ViewModels;
public class TripViewModel : ViewModelBase
{

    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private DateTimeOffset _date;
    [Required]
    public DateTimeOffset Date
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }

    private DateTimeOffset _timeOn;
    [Required]
    public DateTimeOffset TimeOn
    {
        get => _timeOn;
        set => this.RaiseAndSetIfChanged(ref _timeOn, value);
    }

    private DateTimeOffset _timeOff;
    [Required]
    public DateTimeOffset TimeOff
    {
        get => _timeOff;
        set => this.RaiseAndSetIfChanged(ref _timeOff, value);
    }

    private int _routeId;
    [Required]
    public int RouteId
    {
        get => _routeId;
        set => this.RaiseAndSetIfChanged(ref _routeId, value);
    }

    private int _transportId;
    [Required]
    public int TransportId
    {
        get => _transportId;
        set => this.RaiseAndSetIfChanged(ref _transportId, value);
    }

    private int _driverId;
    [Required]
    public int DriverId
    {
        get => _driverId;
        set => this.RaiseAndSetIfChanged(ref _driverId, value);
    }

    public ReactiveCommand<Unit, TripViewModel> TripOnSubmitCommand { get; }

    public TripViewModel()
    {
        TripOnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
