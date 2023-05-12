using AutoMapper;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

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

    public Interaction<CarViewModel, CarViewModel?> ShowCarDialog { get; set; }

    public Interaction<DriverViewModel, DriverViewModel?> ShowDriverDialog { get; set; }

    public Interaction<RideViewModel, RideViewModel?> ShowRideDialog { get; set; }

    public Interaction<UserViewModel, UserViewModel?> ShowUserDialog { get; set; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowCarDialog = new Interaction<CarViewModel, CarViewModel?>();
        ShowDriverDialog = new Interaction<DriverViewModel, DriverViewModel?>();
        ShowRideDialog = new Interaction<RideViewModel, RideViewModel?>();
        ShowUserDialog = new Interaction<UserViewModel, UserViewModel?>();

        RxApp.MainThreadScheduler.Schedule(LoadCarsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadDriversAsync);
        RxApp.MainThreadScheduler.Schedule(LoadRidesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadUsersAsync);

        OnAddCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var carViewModel = await ShowCarDialog.Handle(new CarViewModel());

            if (carViewModel != null)
            {
                try
                {
                    var newCar = await _apiClient.AddCarAsync(_mapper.Map<CarDto>(carViewModel));
                    Cars.Add(carViewModel);
                    /*
                    if (Roles.FirstOrDefault(role => role.Name == "Админ") == null)
                    {
                        Roles.Add(new RoleViewModel
                        {
                            Id = await _apiClient.CreateRole(new RoleDtoPostOrPut
                            {
                                Name = "Админ"
                            }),
                            Name = "Админ"
                        });
                    }
                    
                    LoadGroupsWithMaxNotesCount();
                    ClearExceptionsValues();*/
                }
                catch (Exception ex)
                {
                    //GroupExceptionValue = ex.Message;
                }
            }
        });

        OnChangeCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var carViewModel = await ShowCarDialog.Handle(SelectedCar!);

            if (carViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateCarAsync(SelectedCar!.Id,
                        _mapper.Map<CarDto>(carViewModel));
                    _mapper.Map(carViewModel, SelectedCar);
                    //LoadGroupsWithMaxNotesCount();
                    //ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    //GroupExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedCar)
            .Select(selectCar => selectCar != null));

        OnDeleteCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteCarAsync(SelectedCar!.Id);
                Cars.Remove(SelectedCar!);
                //LoadGroupsWithMaxNotesCount();
                //ClearExceptionsValues();
            }
            catch (Exception ex)
            {
                //GroupExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedCar)
            .Select(selectCar => selectCar != null));



        OnAddDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(new DriverViewModel());

            if (driverViewModel != null)
            {
                try
                {
                    var newDriver = await _apiClient.AddDriverAsync(_mapper.Map<DriverDto>(driverViewModel));
                    Drivers.Add(driverViewModel);
                    /*
                    if (Roles.FirstOrDefault(role => role.Name == "Админ") == null)
                    {
                        Roles.Add(new RoleViewModel
                        {
                            Id = await _apiClient.CreateRole(new RoleDtoPostOrPut
                            {
                                Name = "Админ"
                            }),
                            Name = "Админ"
                        });
                    }
                    
                    LoadGroupsWithMaxNotesCount();
                    ClearExceptionsValues();*/
                }
                catch (Exception ex)
                {
                    //GroupExceptionValue = ex.Message;
                }
            }
        });

        OnChangeDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(SelectedDriver!);

            if (driverViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateDriverAsync(SelectedDriver!.Id,
                        _mapper.Map<DriverDto>(driverViewModel));
                    _mapper.Map(driverViewModel, SelectedDriver);
                    //LoadGroupsWithMaxNotesCount();
                    //ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    //GroupExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedDriver)
            .Select(selectDriver => selectDriver != null));

        OnDeleteDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteDriverAsync(SelectedDriver!.Id);
                Drivers.Remove(SelectedDriver!);
                //LoadGroupsWithMaxNotesCount();
                //ClearExceptionsValues();
            }
            catch (Exception ex)
            {
                //GroupExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedDriver)
            .Select(selectDriver => selectDriver != null));


        OnAddRideCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rideViewModel = await ShowRideDialog.Handle(new RideViewModel());

            if (rideViewModel != null)
            {
                try
                {
                    var newRide = await _apiClient.AddRideAsync(_mapper.Map<RideDto>(rideViewModel));
                    Rides.Add(SelectedRide!);
                    /*
                    if (Roles.FirstOrDefault(role => role.Name == "Админ") == null)
                    {
                        Roles.Add(new RoleViewModel
                        {
                            Id = await _apiClient.CreateRole(new RoleDtoPostOrPut
                            {
                                Name = "Админ"
                            }),
                            Name = "Админ"
                        });
                    }
                    
                    LoadGroupsWithMaxNotesCount();
                    ClearExceptionsValues();*/
                }
                catch (Exception ex)
                {
                    //GroupExceptionValue = ex.Message;
                }
            }
        });

        OnChangeRideCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rideViewModel = await ShowRideDialog.Handle(SelectedRide!);

            if (rideViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateRideAsync(SelectedRide!.Id,
                        _mapper.Map<RideDto>(rideViewModel));
                    _mapper.Map(rideViewModel, SelectedRide);
                    //LoadGroupsWithMaxNotesCount();
                    //ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    //GroupExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedRide)
            .Select(selectRide => selectRide != null));

        OnDeleteRideCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteRideAsync(SelectedRide!.Id);
                Rides.Remove(SelectedRide!);
                //LoadGroupsWithMaxNotesCount();
                //ClearExceptionsValues();
            }
            catch (Exception ex)
            {
                //GroupExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedRide)
            .Select(selectRide => selectRide != null));


        OnAddUserCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var userViewModel = await ShowUserDialog.Handle(new UserViewModel());

            if (userViewModel != null)
            {
                try
                {
                    var newUser = await _apiClient.AddUserAsync(_mapper.Map<UserDto>(userViewModel));
                    Users.Add(userViewModel);
                    /*
                    if (Roles.FirstOrDefault(role => role.Name == "Админ") == null)
                    {
                        Roles.Add(new RoleViewModel
                        {
                            Id = await _apiClient.CreateRole(new RoleDtoPostOrPut
                            {
                                Name = "Админ"
                            }),
                            Name = "Админ"
                        });
                    }
                    
                    LoadGroupsWithMaxNotesCount();
                    ClearExceptionsValues();*/
                }
                catch (Exception ex)
                {
                    //GroupExceptionValue = ex.Message;
                }
            }
        });

        OnChangeUserCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var userViewModel = await ShowUserDialog.Handle(SelectedUser!);

            if (userViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateUserAsync(SelectedUser!.Id,
                        _mapper.Map<UserDto>(userViewModel));
                    _mapper.Map(userViewModel, SelectedUser);
                    //LoadGroupsWithMaxNotesCount();
                    //ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    //GroupExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedUser)
            .Select(selectUser => selectUser != null));

        OnDeleteUserCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteUserAsync(SelectedUser!.Id);
                Users.Remove(SelectedUser!);
                //LoadGroupsWithMaxNotesCount();
                //ClearExceptionsValues();
            }
            catch (Exception ex)
            {
                //GroupExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedUser)
            .Select(selectUser => selectUser != null));
    }

        private async void LoadCarsAsync()
    {
        foreach (var car in await _apiClient.GetAllCarsAsync())
        {
            Cars.Add(_mapper.Map<CarViewModel>(car));
        }
    }

    private async void LoadDriversAsync()
    {
        foreach (var driver in await _apiClient.GetAllDriversAsync())
        {
            Drivers.Add(_mapper.Map<DriverViewModel>(driver));
        }
    }

    private async void LoadRidesAsync()
    {
        foreach (var ride in await _apiClient.GetAllRidesAsync())
        {
            Rides.Add(_mapper.Map<RideViewModel>(ride));
        }
    }

    private async void LoadUsersAsync()
    {
        foreach (var user in await _apiClient.GetAllUsersAsync())
        {
            Users.Add(_mapper.Map<UserViewModel>(user));
        }
    }
}