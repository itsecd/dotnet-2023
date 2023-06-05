using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TransportManagment.Client.ViewModels;
public class RouteViewModel : ViewModelBase
{
    private int _routeId;
    public int RouteId 
    {
        get => _routeId;
        set => this.RaiseAndSetIfChanged(ref _routeId, value);
    }
    private DateTimeOffset _date = DateTimeOffset.MinValue;
    public DateTimeOffset Date 
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }
    private double _timeTo = 0;

    public double TimeTo
    { 
        get => _timeTo;
        set => this.RaiseAndSetIfChanged(ref _timeTo, value);
    }
    private double _timeFrom = 0;
    public double TimeFrom 
    {
        get => _timeFrom;
        set => this.RaiseAndSetIfChanged(ref _timeFrom, value);
    }
    private int _transportId = 0;
    public int TransportId 
    {
        get => _transportId;
        set => this.RaiseAndSetIfChanged(ref _transportId, value);
    }
    private int _driverId = 0;
    public int DriverId 
    {
        get => _driverId;
        set => this.RaiseAndSetIfChanged(ref _driverId, value);
    }
    public ReactiveCommand<Unit, RouteViewModel> OnSubmitCommand { get; }
    public RouteViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
