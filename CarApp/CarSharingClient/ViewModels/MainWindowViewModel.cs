using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Xml.Linq;

namespace CarSharingClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;

    public ObservableCollection<CarViewModel> Cars { get; } = new();
    public ObservableCollection<RentalPointViewModel> RentalPoints { get; } = new();
    public ObservableCollection<ClientViewModel> Clients { get; } = new();
    public ObservableCollection<RentedCarViewModel> RentedCars { get; } = new();

    private CarViewModel? _selectedCar;
    public CarViewModel? SelectedCar
    {
        get => _selectedCar;
        set => this.RaiseAndSetIfChanged(ref _selectedCar, value);
    }
    private RentalPointViewModel? _selectedRentalPoint;
    public RentalPointViewModel? SelectedRentalPoint
    {
        get => _selectedRentalPoint;
        set => this.RaiseAndSetIfChanged(ref _selectedRentalPoint, value);
    }

    private ClientViewModel? _selectedClient;
    public ClientViewModel? SelectedClient
    {
        get => _selectedClient;
        set => this.RaiseAndSetIfChanged(ref _selectedClient, value);
    }
    private RentedCarViewModel? _selectedRentedCar;
    public RentedCarViewModel? SelectedRentedCar
    {
        get => _selectedRentedCar;
        set => this.RaiseAndSetIfChanged(ref _selectedRentedCar, value);
    }
    public ReactiveCommand<Unit, Unit> OnAddCarCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCarCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCarCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddRentalPointCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeRentalPointCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteRentalPointCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddClientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeClientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteClientCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddRentedCarCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeRentedCarCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteRentedCarCommand { get; set; }

    public Interaction<CarViewModel, CarViewModel?> ShowCarDialog { get; }
    public Interaction<RentalPointViewModel, RentalPointViewModel?> ShowRentalPointDialog { get; }
    public Interaction<ClientViewModel, ClientViewModel?> ShowClientDialog { get; }
    public Interaction<RentedCarViewModel, RentedCarViewModel?> ShowRentedCarDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowCarDialog = new Interaction<CarViewModel, CarViewModel?>();
        ShowRentalPointDialog = new Interaction<RentalPointViewModel, RentalPointViewModel?>();
        ShowClientDialog = new Interaction<ClientViewModel, ClientViewModel?>();
        ShowRentedCarDialog = new Interaction<RentedCarViewModel, RentedCarViewModel?>();

        OnAddCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var carViewModel = await ShowCarDialog.Handle(new CarViewModel());
            if (carViewModel != null)
            {
                var newCar = _mapper.Map<CarPostDto>(carViewModel);
                await _apiClient.AddCarsAsync(newCar);
                Cars.Add(carViewModel);
                Cars.Clear();
                RentalPoints.Clear();
                Clients.Clear();
                RentedCars.Clear();
                LoadAsync();
            }
        });
        OnChangeCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var carViewModel = await ShowCarDialog.Handle(SelectedCar!);
            if (carViewModel != null)
            {
                await _apiClient.UpdateCarsAsync(SelectedCar!.Id, _mapper.Map<CarPostDto>(carViewModel));
                _mapper.Map(carViewModel, SelectedCar);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCar).Select(selectCar => selectCar != null));
        OnDeleteCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCarsAsync(SelectedCar!.Id);
            Cars.Remove(SelectedCar);
        }, this.WhenAnyValue(vm => vm.SelectedCar).Select(selectCar => selectCar != null));


       OnAddRentalPointCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rentalPointViewModel = await ShowRentalPointDialog.Handle(new RentalPointViewModel());
            if (rentalPointViewModel != null)
            {
                var newRentalPoint = _mapper.Map<RentalPointPostDto>(rentalPointViewModel);
                await _apiClient.AddRentalPointsAsync(newRentalPoint);
                RentalPoints.Add(rentalPointViewModel);
                Cars.Clear();
                RentalPoints.Clear();
                Clients.Clear();
                RentedCars.Clear();
                LoadAsync();
            }
        });
        OnChangeRentalPointCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rentalPointViewModel = await ShowRentalPointDialog.Handle(SelectedRentalPoint!);
            if (rentalPointViewModel != null)
            {
                await _apiClient.UpdateRentalPointsAsync(SelectedRentalPoint!.Id, _mapper.Map<RentalPointPostDto>(rentalPointViewModel));
                _mapper.Map(rentalPointViewModel, SelectedRentalPoint);
            }
        }, this.WhenAnyValue(vm => vm.SelectedRentalPoint).Select(selectRentalPoint => selectRentalPoint != null));
        OnDeleteRentalPointCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRentalPointsAsync(SelectedRentalPoint!.Id);
            RentalPoints.Remove(SelectedRentalPoint);
        }, this.WhenAnyValue(vm => vm.SelectedRentalPoint).Select(selectRentalPoint => selectRentalPoint != null));

        OnAddClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var clientViewModel = await ShowClientDialog.Handle(new ClientViewModel());
            if (clientViewModel != null)
            {
                var newClient = _mapper.Map<ClientPostDto>(clientViewModel);
                await _apiClient.AddClientAsync(newClient);
                Clients.Add(clientViewModel);
                Cars.Clear();
                RentalPoints.Clear();
                Clients.Clear();
                RentedCars.Clear();
                LoadAsync();
            }
        });
        OnChangeClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var clientViewModel = await ShowClientDialog.Handle(SelectedClient!);
            if (clientViewModel != null)
            {
                await _apiClient.UpdateClientsAsync(SelectedClient!.ClientId, _mapper.Map<ClientPostDto>(clientViewModel));
                _mapper.Map(clientViewModel, SelectedClient);
            }
        }, this.WhenAnyValue(vm => vm.SelectedClient).Select(selectClient => selectClient != null));
        OnDeleteClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteClientsAsync(SelectedClient!.ClientId);
            Clients.Remove(SelectedClient);
        }, this.WhenAnyValue(vm => vm.SelectedClient).Select(selectClient => selectClient != null));

        OnAddRentedCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rentedCarViewModel = await ShowRentedCarDialog.Handle(new RentedCarViewModel());
            if (rentedCarViewModel != null)
            {
                var newRentedCar = _mapper.Map<RentedCarPostDto>(rentedCarViewModel);
                await _apiClient.AddRentedCarsAsync(newRentedCar);
                RentedCars.Add(rentedCarViewModel);
                Cars.Clear();
                RentalPoints.Clear();
                Clients.Clear();
                RentedCars.Clear();
                LoadAsync();
            }
        });
        OnChangeRentedCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rentedCarViewModel = await ShowRentedCarDialog.Handle(SelectedRentedCar!);
            if (rentedCarViewModel != null)
            {
                await _apiClient.UpdateRentedCarsAsync(SelectedRentedCar!.Id, _mapper.Map<RentedCarPostDto>(rentedCarViewModel));
                _mapper.Map(rentedCarViewModel, SelectedRentedCar);
            }
        }, this.WhenAnyValue(vm => vm.SelectedRentedCar).Select(selectRentedCar => selectRentedCar != null));
        OnDeleteRentedCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRentedCarsAsync(SelectedRentedCar!.Id);
            RentedCars.Remove(SelectedRentedCar);
        }, this.WhenAnyValue(vm => vm.SelectedRentedCar).Select(selectRentedCar => selectRentedCar != null));
        RxApp.MainThreadScheduler.Schedule(LoadAsync);
    }

    private async void LoadAsync()
    {
        var cars = await _apiClient.GetCarsAsync();
        foreach (var car in cars)
        {
            Cars.Add(_mapper.Map<CarViewModel>(car));
        }

        var rentalPoints = await _apiClient.GetRentalPointsAsync();
        foreach (var rentalPoint in rentalPoints)
        {
            RentalPoints.Add(_mapper.Map<RentalPointViewModel>(rentalPoint));
        }

        var clients = await _apiClient.GetClientsAsync();
        foreach (var client in clients)
        {
            Clients.Add(_mapper.Map<ClientViewModel>(client));
        }

        var rentedCars = await _apiClient.GetRentedCarsAsync();
        foreach (var rentedCar in rentedCars)
        {
            RentedCars.Add(_mapper.Map<RentedCarViewModel>(rentedCar));
        }
    }
}