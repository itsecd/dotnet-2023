using ReactiveUI;
using System;
using System.Reactive;

namespace CarSharingClient.ViewModels;
public class RentedCarViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private int _carId;
    public int CarId
    {
        set => this.RaiseAndSetIfChanged(ref _carId, value);
        get => _carId;
    }

    private int _clientId;
    public int ClientId
    {
        set => this.RaiseAndSetIfChanged(ref _clientId, value);
        get => _clientId;
    }

    private int _rentalPointId;
    public int RentalPointId
    {
        set => this.RaiseAndSetIfChanged(ref _rentalPointId, value);
        get => _rentalPointId;
    }

    private int _rentPeriod;
    public int RentPeriod
    {
        set => this.RaiseAndSetIfChanged(ref _rentPeriod, value);
        get => _rentPeriod;
    }

    private DateTimeOffset _timeOfRent = DateTime.Now;
    public DateTimeOffset TimeOfRent
    {
        set => this.RaiseAndSetIfChanged(ref _timeOfRent, value);
        get => _timeOfRent;
    }

    private DateTimeOffset _timeOfReturn = DateTime.Now;
    public DateTimeOffset TimeOfReturn
    {
        set => this.RaiseAndSetIfChanged(ref _timeOfReturn, value);
        get => _timeOfReturn;
    }
    public ReactiveCommand<Unit, RentedCarViewModel> OnSubmitCommand { get; }

    public RentedCarViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}