using System;
using ReactiveUI;
using System.Reactive;

namespace TransportManagment.Client.ViewModels;
public class DriverPropertiesRouteViewModel : ViewModelBase
{
    private int _driverId = 0;
    public int DriverId
    {
        get => _driverId;
        set => this.RaiseAndSetIfChanged(ref _driverId, value);
    }
    private double _avgTime = 0;
    public double AvgTime
    {
        get => _avgTime;
        set => this.RaiseAndSetIfChanged(ref _avgTime, value);
    }
    private double _sumTime = 0;
    public double SumTime
    {
        get => _sumTime;
        set => this.RaiseAndSetIfChanged(ref _sumTime, value);
    }
    private double _maxTime = 0;
    public double MaxTime 
    {
        get => _maxTime;
        set => this.RaiseAndSetIfChanged(ref _maxTime, value);
    }
    public ReactiveCommand<Unit, DriverPropertiesRouteViewModel> OnSubmitCommand { get; }
    public DriverPropertiesRouteViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
