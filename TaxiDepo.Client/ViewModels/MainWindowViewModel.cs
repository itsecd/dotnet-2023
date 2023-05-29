using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace TaxiDepo.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    private CarViewModel? _selectedCar;

    private DriverViewModel? _selectedDriver;
    
    private RideViewModel? _selectedRide;
    
    private UserViewModel? _selectedUser;

    public CarViewModel? SelectedCar
    {
        get => _selectedCar;
        set => this.RaiseAndSetIfChanged(ref _selectedCar, value);
    }
    public DriverViewModel? SelectedDriver
    {
        get => _selectedDriver;
        set => this.RaiseAndSetIfChanged(ref _selectedDriver, value);
    }
    public RideViewModel? SelectedRide
    {
        get => _selectedRide;
        set => this.RaiseAndSetIfChanged(ref _selectedRide, value);
    }
    public UserViewModel? SelectedUser
    {
        get => _selectedUser;
        set => this.RaiseAndSetIfChanged(ref _selectedUser, value);
    }

    public ObservableCollection<CarViewModel> Cars { get; } = new();

    public ObservableCollection<DriverViewModel> Drivers { get; } = new();

    public ObservableCollection<RideViewModel> Rides { get; } = new();

    public ObservableCollection<UserViewModel> Users { get; } = new();

    public ReactiveCommand<Unit, Unit> OnAddCarCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeCarCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCarCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddDriverCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeDriverCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteDriverCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddRideCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeRideCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteRideCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddUserCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeUserCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteUserCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnUpdateAnalytics { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddDate { get; set; }

    public Interaction<CarViewModel, CarViewModel?> ShowCarDialog { get; set; }

    public Interaction<DriverViewModel, DriverViewModel?> ShowDriverDialog { get; set; }

    public Interaction<RideViewModel, RideViewModel?> ShowRideDialog { get; set; }

    public Interaction<UserViewModel, UserViewModel?> ShowUserDialog { get; set; }

    public ObservableCollection<CarAndDriverViewModel> CarAndDrivers { get; } = new();//1

    public ObservableCollection<CountUserRidesViewModel> UsersByDate { get; } = new();//2

    public ObservableCollection<CountUserRidesViewModel> CountUserRides { get; } = new();//3

    public ObservableCollection<DriverViewModel> TopDrivers { get; } = new();//4

    public ObservableCollection<DriverRidesViewModel> DriverRides { get; } = new();//5

    public ObservableCollection<CountUserRidesViewModel> MaxUserRides { get; } = new();//6

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();

        _mapper = Locator.Current.GetService<IMapper>();

        ShowCarDialog = new Interaction<CarViewModel, CarViewModel?>();

        ShowDriverDialog = new Interaction<DriverViewModel, DriverViewModel?>();

        ShowRideDialog = new Interaction<RideViewModel, RideViewModel?>();

        ShowUserDialog = new Interaction<UserViewModel, UserViewModel?>();

        OnUpdateAnalytics = ReactiveCommand.CreateFromTask(() =>
        {
            Cars.Clear();

            Drivers.Clear();

            Rides.Clear();

            Users.Clear();

            CarAndDrivers.Clear();

            UsersByDate.Clear();

            CountUserRides.Clear();

            TopDrivers.Clear();

            DriverRides.Clear();

            MaxUserRides.Clear();

            LoadClassesAsync();

            return Task.CompletedTask;
        });

        RxApp.MainThreadScheduler.Schedule(LoadClassesAsync);

        OnAddCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var carViewModel = await ShowCarDialog.Handle(new CarViewModel());

            if (carViewModel != null)
            {

                var newCar = await _apiClient.AddCar(_mapper.Map<CarDto>(carViewModel));

                Cars.Add(carViewModel);
            }
        });

        OnChangeCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var carViewModel = await ShowCarDialog.Handle(SelectedCar!);

            if (carViewModel != null)
            {
                await _apiClient.UpdateCar(SelectedCar!.Id,
                     _mapper.Map<CarDto>(carViewModel));
                
                _mapper.Map(carViewModel, SelectedCar);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedCar)
            .Select(selectCar => selectCar != null));

        OnDeleteCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCar(SelectedCar!.Id);
            Cars.Remove(SelectedCar!);

        }, this.WhenAnyValue(viewModel => viewModel.SelectedCar)
            .Select(selectCar => selectCar != null));

        OnAddDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(new DriverViewModel());

            if (driverViewModel != null)
            {
                 var newDriver = await _apiClient.AddDriver(_mapper.Map<DriverDto>(driverViewModel));
              
                Drivers.Add(driverViewModel); 
            }
        });

        OnChangeDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(SelectedDriver!);

            if (driverViewModel != null)
            {
                 await _apiClient.UpdateDriver(SelectedDriver!.Id,
                     _mapper.Map<DriverDto>(driverViewModel));
                 
                _mapper.Map(driverViewModel, SelectedDriver);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedDriver)
            .Select(selectDriver => selectDriver != null));

        OnDeleteDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDriver(SelectedDriver!.Id);
        
            Drivers.Remove(SelectedDriver!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedDriver)
            .Select(selectDriver => selectDriver != null));

        OnAddRideCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rideViewModel = await ShowRideDialog.Handle(new RideViewModel());

            if (rideViewModel != null)
            {
                 var newRide = await _apiClient.AddRide(_mapper.Map<RideDto>(rideViewModel));

                 Rides.Add(rideViewModel);
            }
        });

        OnChangeRideCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rideViewModel = await ShowRideDialog.Handle(SelectedRide!);

            if (rideViewModel != null)
            {
                 await _apiClient.UpdateRide(SelectedRide!.Id,
                     _mapper.Map<RideDto>(rideViewModel));

                 _mapper.Map(rideViewModel, SelectedRide);
                   
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedRide)
            .Select(selectRide => selectRide != null));

        OnDeleteRideCommand = ReactiveCommand.CreateFromTask(async () =>
        {
             await _apiClient.DeleteRide(SelectedRide!.Id);
             
            Rides.Remove(SelectedRide!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedRide)
            .Select(selectRide => selectRide != null));

        OnAddUserCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var userViewModel = await ShowUserDialog.Handle(new UserViewModel());

            if (userViewModel != null)
            {
                var newUser = await _apiClient.AddUser(_mapper.Map<UserDto>(userViewModel));
                
                Users.Add(userViewModel);
            }
        });

        OnChangeUserCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var userViewModel = await ShowUserDialog.Handle(SelectedUser!);

            if (userViewModel != null)
            {
                await _apiClient.UpdateUser(SelectedUser!.Id,
                   _mapper.Map<UserDto>(userViewModel));

                _mapper.Map(userViewModel, SelectedUser);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedUser)
            .Select(selectUser => selectUser != null));

        OnDeleteUserCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteUser(SelectedUser!.Id);
            
            Users.Remove(SelectedUser!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedUser)
            .Select(selectUser => selectUser != null));
    }

    private async void LoadClassesAsync()
    {
        var cars = await _apiClient.GetAllCars();
        foreach (var car in cars)
        {
            Cars.Add(_mapper.Map<CarViewModel>(car));
        }

        foreach (var driver in await _apiClient.GetAllDrivers())
        {
            Drivers.Add(_mapper.Map<DriverViewModel>(driver));
        }

        foreach (var ride in await _apiClient.GetAllRides())
        {
            Rides.Add(_mapper.Map<RideViewModel>(ride));
        }

        foreach (var user in await _apiClient.GetAllUsers())
        {
            Users.Add(_mapper.Map<UserViewModel>(user));
        }

        foreach (var car in cars)//1
        {
            var carAndDrivers = await _apiClient.GetCarAndDriverAsync(car.Id);
            foreach (var carDrivers in carAndDrivers)
            {
                CarAndDrivers.Add(_mapper.Map<CarAndDriverViewModel>(carDrivers));
            }
        }

        var users = await _apiClient.UserByDateAsync(new DateTime(2002, 11, 01, 01, 01, 01), new DateTime(2023, 02, 01, 01, 01, 01));
        foreach (var user in users)//2
        {
            UsersByDate.Add(_mapper.Map<CountUserRidesViewModel>(user));
        }

        var countUsersRides = await _apiClient.CountUserRidesAsync();//3
        foreach (var countUserRides in countUsersRides)
        {
            CountUserRides.Add(_mapper.Map<CountUserRidesViewModel>(countUserRides));
        }

        var topDrivers = await _apiClient.TopDriverAsync();//4
        foreach (var topDriver in topDrivers)
        {
            TopDrivers.Add(_mapper.Map<DriverViewModel>(topDriver));
        }

        var driverRides = await _apiClient.InfoAboutRidesAsync();//5
        foreach (var driverRide in driverRides)
        {
            DriverRides.Add(_mapper.Map<DriverRidesViewModel>(driverRide));
        }

        var usersMax = await _apiClient.MaxUserRidesAsync(new DateTime(2000, 01, 01, 01, 01, 01), DateTime.Now);
        foreach (var user in usersMax)//6
        {
            MaxUserRides.Add(_mapper.Map<CountUserRidesViewModel>(user));
        }
    }
}