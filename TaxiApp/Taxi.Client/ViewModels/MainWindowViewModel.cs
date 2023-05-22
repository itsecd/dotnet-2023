using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace Taxi.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>()!;
        _mapper = Locator.Current.GetService<IMapper>()!;

        ShowDriverDialog = new Interaction<DriverViewModel, DriverViewModel?>();
        ShowPassengerDialog = new Interaction<PassengerViewModel, PassengerViewModel?>();
        ShowVehicleDialog = new Interaction<VehicleViewModel, VehicleViewModel?>();
        ShowVehicleClassificationDialog =
            new Interaction<VehicleClassificationViewModel, VehicleClassificationViewModel?>();
        ShowRideDialog = new Interaction<RideViewModel, RideViewModel?>();


        OnUpdateAnalytics = ReactiveCommand.CreateFromTask(() =>
        {
            CountPassengersRides.Clear();
            TopDrivers.Clear();
            InfosAboutRides.Clear();

            LoadDataAsync();

            return Task.CompletedTask;
        });

        OnAddDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(new DriverViewModel());
            if (driverViewModel != null)
            {
                var newDriver = await _apiClient.AddDriverAsync(_mapper.Map<DriverSetDto>(driverViewModel));
                Drivers.Add(_mapper.Map<DriverViewModel>(newDriver));
            }
        });

        OnChangeDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(SelectedDriver!);
            if (driverViewModel != null)
            {
                await _apiClient.UpdateDriverAsync(SelectedDriver!.Id, _mapper.Map<DriverSetDto>(driverViewModel));
                _mapper.Map(driverViewModel, SelectedDriver);
            }
        }, this.WhenAnyValue(vm => vm.SelectedDriver)
            .Select(selectedDriver => selectedDriver != null));

        OnDeleteDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDriverAsync(SelectedDriver!.Id);
            Drivers.Remove(SelectedDriver);
        }, this.WhenAnyValue(vm => vm.SelectedDriver).Select(selectedDriver => selectedDriver != null));


        OnAddPassengerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var passengerViewModel = await ShowPassengerDialog.Handle(new PassengerViewModel());
            if (passengerViewModel != null)
            {
                var newPassenger =
                    await _apiClient.AddPassengerAsync(_mapper.Map<PassengerSetDto>(passengerViewModel));
                Passengers.Add(_mapper.Map<PassengerViewModel>(newPassenger));
            }
        });

        OnChangePassengerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var passengerViewModel = await ShowPassengerDialog.Handle(SelectedPassenger!);
            if (passengerViewModel != null)
            {
                await _apiClient.UpdatePassengerAsync(SelectedPassenger!.Id,
                    _mapper.Map<PassengerSetDto>(passengerViewModel));
                _mapper.Map(passengerViewModel, SelectedPassenger);
            }
        }, this.WhenAnyValue(vm => vm.SelectedPassenger)
            .Select(selectedPassenger => selectedPassenger != null));

        OnDeletePassengerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeletePassengerAsync(SelectedPassenger!.Id);
            Passengers.Remove(SelectedPassenger);
        }, this.WhenAnyValue(vm => vm.SelectedPassenger).Select(selectedPassenger => selectedPassenger != null));


        OnAddVehicleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vehicleViewModel = await ShowVehicleDialog.Handle(new VehicleViewModel());
            if (vehicleViewModel != null &&
                Drivers.Any(d => d.Id == vehicleViewModel.DriverId) &&
                VehicleClassifications.Any(vc => vc.Id == vehicleViewModel.VehicleClassificationId))
            {
                var newVehicle =
                    await _apiClient.AddVehicleAsync(_mapper.Map<VehicleSetDto>(vehicleViewModel));
                Vehicles.Add(_mapper.Map<VehicleViewModel>(newVehicle));
            }
        });

        OnChangeVehicleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vehicleViewModel = await ShowVehicleDialog.Handle(SelectedVehicle!);
            if (vehicleViewModel != null &&
                Drivers.Any(d => d.Id == vehicleViewModel.DriverId) &&
                VehicleClassifications.Any(vc => vc.Id == vehicleViewModel.VehicleClassificationId))
            {
                await _apiClient.UpdateVehicleAsync(SelectedVehicle!.Id, _mapper.Map<VehicleSetDto>(vehicleViewModel));
                _mapper.Map(vehicleViewModel, SelectedVehicle);
            }
        }, this.WhenAnyValue(vm => vm.SelectedVehicle)
            .Select(selectedVehicle => selectedVehicle != null));

        OnDeleteVehicleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteVehicleAsync(SelectedVehicle!.Id);
            Vehicles.Remove(SelectedVehicle);
        }, this.WhenAnyValue(vm => vm.SelectedVehicle).Select(selectedVehicle => selectedVehicle != null));


        OnAddVehicleClassificationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vehicleClassificationViewModel =
                await ShowVehicleClassificationDialog.Handle(new VehicleClassificationViewModel());
            if (vehicleClassificationViewModel != null)
            {
                var newVehicleClassification =
                    await _apiClient.AddVehicleClassificationAsync(
                        _mapper.Map<VehicleClassificationSetDto>(vehicleClassificationViewModel));
                VehicleClassifications.Add(_mapper.Map<VehicleClassificationViewModel>(newVehicleClassification));
            }
        });

        OnChangeVehicleClassificationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vehicleClassificationViewModel =
                await ShowVehicleClassificationDialog.Handle(SelectedVehicleClassification!);
            if (vehicleClassificationViewModel != null)
            {
                await _apiClient.UpdateVehicleClassificationAsync(SelectedVehicleClassification!.Id,
                    _mapper.Map<VehicleClassificationSetDto>(vehicleClassificationViewModel));
                _mapper.Map(vehicleClassificationViewModel, SelectedVehicleClassification);
            }
        }, this.WhenAnyValue(vm => vm.SelectedVehicleClassification)
            .Select(selectedVehicleClassification => selectedVehicleClassification != null));

        OnDeleteVehicleClassificationCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await _apiClient.DeleteVehicleClassificationAsync(SelectedVehicleClassification!.Id);
                VehicleClassifications.Remove(SelectedVehicleClassification);
            },
            this.WhenAnyValue(vm => vm.SelectedVehicleClassification)
                .Select(selectedVehicleClassification => selectedVehicleClassification != null));


        OnAddRideCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rideViewModel = await ShowRideDialog.Handle(new RideViewModel());

            if (rideViewModel != null &&
                Vehicles.Any(v => v.Id == rideViewModel.VehicleId) &&
                Passengers.Any(p => p.Id == rideViewModel.PassengerId))
            {
                var newRide = await _apiClient.AddRideAsync(_mapper.Map<RideSetDto>(rideViewModel));
                Rides.Add(_mapper.Map<RideViewModel>(newRide));
            }
        });

        OnChangeRideCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rideViewModel = await ShowRideDialog.Handle(SelectedRide!);
            if (rideViewModel != null &&
                Vehicles.Any(v => v.Id == rideViewModel.VehicleId) &&
                Passengers.Any(p => p.Id == rideViewModel.PassengerId))
            {
                await _apiClient.UpdateRideAsync(SelectedRide!.Id, _mapper.Map<RideSetDto>(rideViewModel));
                _mapper.Map(rideViewModel, SelectedRide);
            }
        }, this.WhenAnyValue(vm => vm.SelectedRide)
            .Select(selectedRide => selectedRide != null));

        OnDeleteRideCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRideAsync(SelectedRide!.Id);
            Rides.Remove(SelectedRide);
        }, this.WhenAnyValue(vm => vm.SelectedRide).Select(selectedRide => selectedRide != null));


        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }

    public ObservableCollection<DriverViewModel> Drivers { get; } = new();
    public ObservableCollection<PassengerViewModel> Passengers { get; } = new();
    public ObservableCollection<VehicleViewModel> Vehicles { get; } = new();
    public ObservableCollection<VehicleClassificationViewModel> VehicleClassifications { get; } = new();
    public ObservableCollection<RideViewModel> Rides { get; } = new();


    public ObservableCollection<CountPassengerRidesViewModel> CountPassengersRides { get; } = new();

    public ObservableCollection<DriverViewModel> TopDrivers { get; } = new();

    public ObservableCollection<InfoAboutRidesViewModel> InfosAboutRides { get; } = new();


    [Reactive] public DriverViewModel? SelectedDriver { get; set; }

    [Reactive] public PassengerViewModel? SelectedPassenger { get; set; }

    [Reactive] public VehicleViewModel? SelectedVehicle { get; set; }

    [Reactive] public VehicleClassificationViewModel? SelectedVehicleClassification { get; set; }

    [Reactive] public RideViewModel? SelectedRide { get; set; }


    public ReactiveCommand<Unit, Unit> OnUpdateAnalytics { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddDriverCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeDriverCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteDriverCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddPassengerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangePassengerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeletePassengerCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddVehicleCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeVehicleCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteVehicleCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddVehicleClassificationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeVehicleClassificationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteVehicleClassificationCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddRideCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeRideCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteRideCommand { get; set; }

    public Interaction<DriverViewModel, DriverViewModel?> ShowDriverDialog { get; }
    public Interaction<PassengerViewModel, PassengerViewModel?> ShowPassengerDialog { get; }
    public Interaction<VehicleViewModel, VehicleViewModel?> ShowVehicleDialog { get; }

    public Interaction<VehicleClassificationViewModel, VehicleClassificationViewModel?> ShowVehicleClassificationDialog
    {
        get;
    }

    public Interaction<RideViewModel, RideViewModel?> ShowRideDialog { get; }

    private async void LoadDataAsync()
    {
        var drivers = await _apiClient.GetDriversAsync();
        foreach (var driver in drivers)
        {
            Drivers.Add(_mapper.Map<DriverViewModel>(driver));
        }

        var passengers = await _apiClient.GetPassengersAsync();
        foreach (var passenger in passengers)
        {
            Passengers.Add(_mapper.Map<PassengerViewModel>(passenger));
        }

        var vehicles = await _apiClient.GetVehiclesAsync();
        foreach (var vehicle in vehicles)
        {
            Vehicles.Add(_mapper.Map<VehicleViewModel>(vehicle));
        }

        var vehicleClassifications = await _apiClient.GetVehicleClassificationsAsync();
        foreach (var vehicleClassification in vehicleClassifications)
        {
            VehicleClassifications.Add(_mapper.Map<VehicleClassificationViewModel>(vehicleClassification));
        }

        var rides = await _apiClient.GetRidesAsync();
        foreach (var ride in rides)
        {
            Rides.Add(_mapper.Map<RideViewModel>(ride));
        }

        var countPassengersRides = await _apiClient.CountPassengerRidesAsync();
        foreach (var countPassengerRides in countPassengersRides)
        {
            CountPassengersRides.Add(_mapper.Map<CountPassengerRidesViewModel>(countPassengerRides));
        }

        var topDrivers = await _apiClient.TopDriverAsync();
        foreach (var topDriver in topDrivers)
        {
            TopDrivers.Add(_mapper.Map<DriverViewModel>(topDriver));
        }

        var infosAboutRides = await _apiClient.InfosAboutRidesAsync();
        foreach (var infoAboutRides in infosAboutRides)
        {
            InfosAboutRides.Add(_mapper.Map<InfoAboutRidesViewModel>(infoAboutRides));
        }
    }
}