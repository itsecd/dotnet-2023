using Microsoft.Win32.SafeHandles;
using ReactiveUI;
using System;
using System.Reactive;

namespace TaxiDepo.Client.ViewModels;

public class RideViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _tripDeparturePlace = string.Empty;

    public string TripDeparturePlace
    {
        get => _tripDeparturePlace;
        set => this.RaiseAndSetIfChanged(ref _tripDeparturePlace, value);
    }

    private string _tripDestinationPlace = string.Empty;

    public string TripDestinationPlace
    {
        get => _tripDestinationPlace;
        set => this.RaiseAndSetIfChanged(ref _tripDestinationPlace, value);
    }

    private string _tripDate = string.Empty;

    public string TripDate
    {
        get => _tripDate;
        set => this.RaiseAndSetIfChanged(ref _tripDate, value);
    }

    private string _tripTime = string.Empty;

    public string TripTime
    {
        get => _tripTime;
        set => this.RaiseAndSetIfChanged(ref _tripTime, value);
    }

    private double _tripPrice;

    public double TripPrice
    {
        get => _tripPrice;
        set => this.RaiseAndSetIfChanged(ref _tripPrice, value);
    }

    private int _carId;

    public int CarId
    {
        get => _carId;
        set => this.RaiseAndSetIfChanged(ref _carId, value);
    }

    private int _userId;

    public int UserId
    {
        get => _userId;
        set => this.RaiseAndSetIfChanged(ref _userId, value);
    }

    public ReactiveCommand<Unit, RideViewModel> OnSubmitCommand { get; set; }

    public RideViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}