using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using AutoMapper;
using ReactiveUI;
using Splat;

namespace RentalService.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper? _apiClient;
    private readonly IMapper? _mapper;

    private ClientViewModel? _selectedClient;

    private IssuedCarViewModel? _selectedIssuedCar;

    private RefundInformationViewModel? _selectedRefundInformation;

    private RentalInformationViewModel? _selectedRentalInformation;

    private RentalPointViewModel? _selectedRentalPoint;

    private VehicleViewModel? _selectedVehicle;

    private VehicleModelViewModel? _selectedVehicleModel;


    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowClientDialog = new Interaction<ClientViewModel, ClientViewModel?>();

        OnAddClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            ClientViewModel? clientViewModel = await ShowClientDialog.Handle(new ClientViewModel());
            if (clientViewModel != null)
            {
                ClientGetDto newClient = await _apiClient.AddClientsAsync(_mapper.Map<ClientPostDto>(clientViewModel));
                Clients.Add(_mapper.Map<ClientViewModel>(newClient));
            }
        });

        OnEditClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            ClientViewModel? clientViewModel = await ShowClientDialog.Handle(SelectedClient!);
            if (clientViewModel != null)
            {
                await _apiClient.UpdateClientsAsync(SelectedClient!.Id, _mapper.Map<ClientPostDto>(clientViewModel));
                _mapper.Map(clientViewModel, SelectedClient);
            }
        }, this.WhenAnyValue(vm => vm.SelectedClient)
            .Select(selectClient => selectClient != null));

        OnDeleteClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteClientsAsync(SelectedClient!.Id);
            Clients.Remove(SelectedClient);
        }, this.WhenAnyValue(vm => vm.SelectedClient)
            .Select(selectClient => selectClient != null));

        ShowIssuedCarDialog = new Interaction<IssuedCarViewModel, IssuedCarViewModel?>();

        OnAddIssuedCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            IssuedCarViewModel? issuedCarViewModel = await ShowIssuedCarDialog.Handle(new IssuedCarViewModel());
            if (issuedCarViewModel != null)
            {
                IssuedCar newIssuedCar =
                    await _apiClient.AddIssuedCarAsync(_mapper.Map<IssuedCarPostDto>(issuedCarViewModel));
                IssuedCars.Add(_mapper.Map<IssuedCarViewModel>(newIssuedCar));
            }
        });

        OnEditIssuedCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            IssuedCarViewModel? issuedCarViewModel = await ShowIssuedCarDialog.Handle(SelectedIssuedCar!);
            if (issuedCarViewModel != null)
            {
                await _apiClient.UpdateIssuedCarAsync(SelectedIssuedCar!.Id,
                    _mapper.Map<IssuedCarPostDto>(issuedCarViewModel));
                _mapper.Map(issuedCarViewModel, SelectedIssuedCar);
            }
        }, this.WhenAnyValue(vm => vm.SelectedIssuedCar)
            .Select(selectIssuedCar => selectIssuedCar != null));

        OnDeleteIssuedCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteIssuedCarAsync(SelectedIssuedCar!.Id);
            IssuedCars.Remove(SelectedIssuedCar);
        }, this.WhenAnyValue(vm => vm.SelectedIssuedCar)
            .Select(selectIssuedCar => selectIssuedCar != null));

        ShowRefundInformationDialog = new Interaction<RefundInformationViewModel, RefundInformationViewModel?>();

        OnAddRefundInformationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            RefundInformationViewModel? refundInformationViewModel =
                await ShowRefundInformationDialog.Handle(new RefundInformationViewModel());
            if (refundInformationViewModel != null)
            {
                RefundInformation newRefundInformation = await _apiClient.AddRefundInformationAsync(_mapper
                    .Map<RefundInformationPostDto>(refundInformationViewModel));
                RefundInformations.Add(_mapper.Map<RefundInformationViewModel>(newRefundInformation));
            }
        });

        OnEditRefundInformationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            RefundInformationViewModel? refundInformationViewModel =
                await ShowRefundInformationDialog.Handle(SelectedRefundInformation!);
            if (refundInformationViewModel != null)
            {
                await _apiClient.UpdateRefundInformationAsync(SelectedRefundInformation!.Id,
                    _mapper.Map<RefundInformationPostDto>(refundInformationViewModel));
                _mapper.Map(refundInformationViewModel, SelectedRefundInformation);
            }
        }, this.WhenAnyValue(vm => vm.SelectedRefundInformation)
            .Select(selectRefundInformation => selectRefundInformation != null));

        OnDeleteRefundInformationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRefundInformationAsync(SelectedRefundInformation!.Id);
            RefundInformations.Remove(SelectedRefundInformation);
        }, this.WhenAnyValue(vm => vm.SelectedRefundInformation)
            .Select(selectRefundInformation => selectRefundInformation != null));

        ShowRentalInformationDialog = new Interaction<RentalInformationViewModel, RentalInformationViewModel?>();

        OnAddRentalInformationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            RentalInformationViewModel? rentalInformationViewModel =
                await ShowRentalInformationDialog.Handle(new RentalInformationViewModel());
            if (rentalInformationViewModel != null)
            {
                RentalInformation newRentalInformation = await _apiClient.AddRentalInformationAsync(_mapper
                    .Map<RentalInformationPostDto>(rentalInformationViewModel));
                RentalInformations.Add(_mapper.Map<RentalInformationViewModel>(newRentalInformation));
            }
        });

        OnEditRentalInformationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            RentalInformationViewModel? rentalInformationViewModel =
                await ShowRentalInformationDialog.Handle(SelectedRentalInformation!);
            if (rentalInformationViewModel != null)
            {
                await _apiClient.UpdateRentalInformationAsync(SelectedRentalInformation!.Id,
                    _mapper.Map<RentalInformationPostDto>(rentalInformationViewModel));
                _mapper.Map(rentalInformationViewModel, SelectedRentalInformation);
            }
        }, this.WhenAnyValue(vm => vm.SelectedRentalInformation)
            .Select(selectRentalInformation => selectRentalInformation != null));

        OnDeleteRentalInformationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRentalInformationAsync(SelectedRentalInformation!.Id);
            RentalInformations.Remove(SelectedRentalInformation);
        }, this.WhenAnyValue(vm => vm.SelectedRentalInformation)
            .Select(selectRentalInformation => selectRentalInformation != null));

        ShowRentalPointDialog = new Interaction<RentalPointViewModel, RentalPointViewModel?>();

        OnAddRentalPointCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            RentalPointViewModel? rentalPointViewModel = await ShowRentalPointDialog.Handle(new RentalPointViewModel());
            if (rentalPointViewModel != null)
            {
                RentalPointGetDto newRentalPoint = await _apiClient.AddRentalPointAsync(_mapper
                    .Map<RentalPointPostDto>(rentalPointViewModel));
                RentalPoints.Add(_mapper.Map<RentalPointViewModel>(newRentalPoint));
            }
        });

        OnEditRentalPointCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            RentalPointViewModel? rentalPointViewModel = await ShowRentalPointDialog.Handle(SelectedRentalPoint!);
            if (rentalPointViewModel != null)
            {
                await _apiClient.UpdateRentalPointAsync(SelectedRentalPoint!.Id,
                    _mapper.Map<RentalPointPostDto>(rentalPointViewModel));
                _mapper.Map(rentalPointViewModel, SelectedRentalPoint);
            }
        }, this.WhenAnyValue(vm => vm.SelectedRentalPoint)
            .Select(selectRentalPoint => selectRentalPoint != null));

        OnDeleteRentalPointCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRentalPointAsync(SelectedRentalPoint!.Id);
            RentalPoints.Remove(SelectedRentalPoint);
        }, this.WhenAnyValue(vm => vm.SelectedRentalPoint)
            .Select(selectRentalPoint => selectRentalPoint != null));

        ShowVehicleModelDialog = new Interaction<VehicleModelViewModel, VehicleModelViewModel?>();

        OnAddVehicleModelCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            VehicleModelViewModel? vehicleModelViewModel =
                await ShowVehicleModelDialog.Handle(new VehicleModelViewModel());
            if (vehicleModelViewModel != null)
            {
                VehicleModelGetDto newVehicleModel = await _apiClient.AddVehicleModelAsync(_mapper
                    .Map<VehicleModelPostDto>(vehicleModelViewModel));
                VehicleModels.Add(_mapper.Map<VehicleModelViewModel>(newVehicleModel));
            }
        });

        OnEditVehicleModelCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            VehicleModelViewModel? vehicleModelViewModel = await ShowVehicleModelDialog.Handle(SelectedVehicleModel!);
            if (vehicleModelViewModel != null)
            {
                await _apiClient.UpdateVehicleModelAsync(SelectedVehicleModel!.Id,
                    _mapper.Map<VehicleModelPostDto>(vehicleModelViewModel));
                _mapper.Map(vehicleModelViewModel, SelectedVehicleModel);
            }
        }, this.WhenAnyValue(vm => vm.SelectedVehicleModel)
            .Select(selectVehicleModel => selectVehicleModel != null));

        OnDeleteVehicleModelCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteVehicleModelAsync(SelectedVehicleModel!.Id);
            VehicleModels.Remove(SelectedVehicleModel);
        }, this.WhenAnyValue(vm => vm.SelectedVehicleModel)
            .Select(selectVehicleModel => selectVehicleModel != null));

        ShowVehicleDialog = new Interaction<VehicleViewModel, VehicleViewModel?>();

        OnAddVehicleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            VehicleViewModel? vehicleViewModel = await ShowVehicleDialog.Handle(new VehicleViewModel());
            if (vehicleViewModel != null)
            {
                VehicleGetDto newVehicle = await _apiClient.AddVehicleAsync(_mapper
                    .Map<VehiclePostDto>(vehicleViewModel));
                Vehicles.Add(_mapper.Map<VehicleViewModel>(newVehicle));
            }
        });

        OnEditVehicleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            VehicleViewModel? vehicleViewModel = await ShowVehicleDialog.Handle(SelectedVehicle!);
            if (vehicleViewModel != null)
            {
                await _apiClient.UpdateVehicleAsync(SelectedVehicle!.Id,
                    _mapper.Map<VehiclePostDto>(vehicleViewModel));
                _mapper.Map(vehicleViewModel, SelectedVehicle);
            }
        }, this.WhenAnyValue(vm => vm.SelectedVehicle)
            .Select(selectVehicle => selectVehicle != null));

        OnDeleteVehicleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteVehicleAsync(SelectedVehicle!.Id);
            Vehicles.Remove(SelectedVehicle);
        }, this.WhenAnyValue(vm => vm.SelectedVehicle)
            .Select(selectVehicle => selectVehicle != null));

        RxApp.MainThreadScheduler.Schedule(LoadClientAsync);
        RxApp.MainThreadScheduler.Schedule(LoadIssuedCarAsync);
        RxApp.MainThreadScheduler.Schedule(LoadRefundInformationAsync);
        RxApp.MainThreadScheduler.Schedule(LoadRentalInformationAsync);
        RxApp.MainThreadScheduler.Schedule(LoadRentalPointAsync);
        RxApp.MainThreadScheduler.Schedule(LoadVehicleModelAsync);
        RxApp.MainThreadScheduler.Schedule(LoadVehicleAsync);
        RxApp.MainThreadScheduler.Schedule(LoadRentedVehiclesAsync);
    }

    public ObservableCollection<ClientViewModel> Clients { get; } = new();
    public ObservableCollection<IssuedCarViewModel> IssuedCars { get; } = new();
    public ObservableCollection<RefundInformationViewModel> RefundInformations { get; } = new();
    public ObservableCollection<RentalInformationViewModel> RentalInformations { get; } = new();
    public ObservableCollection<RentalPointViewModel> RentalPoints { get; } = new();
    public ObservableCollection<VehicleModelViewModel> VehicleModels { get; } = new();
    public ObservableCollection<VehicleViewModel> Vehicles { get; } = new();
    public ObservableCollection<VehicleViewModel> RentedVehicles { get; } = new();

    public ClientViewModel? SelectedClient
    {
        get => _selectedClient;
        set => this.RaiseAndSetIfChanged(ref _selectedClient, value);
    }

    public IssuedCarViewModel? SelectedIssuedCar
    {
        get => _selectedIssuedCar;
        set => this.RaiseAndSetIfChanged(ref _selectedIssuedCar, value);
    }

    public RefundInformationViewModel? SelectedRefundInformation
    {
        get => _selectedRefundInformation;
        set => this.RaiseAndSetIfChanged(ref _selectedRefundInformation, value);
    }

    public RentalInformationViewModel? SelectedRentalInformation
    {
        get => _selectedRentalInformation;
        set => this.RaiseAndSetIfChanged(ref _selectedRentalInformation, value);
    }

    public RentalPointViewModel? SelectedRentalPoint
    {
        get => _selectedRentalPoint;
        set => this.RaiseAndSetIfChanged(ref _selectedRentalPoint, value);
    }

    public VehicleModelViewModel? SelectedVehicleModel
    {
        get => _selectedVehicleModel;
        set => this.RaiseAndSetIfChanged(ref _selectedVehicleModel, value);
    }

    public VehicleViewModel? SelectedVehicle
    {
        get => _selectedVehicle;
        set => this.RaiseAndSetIfChanged(ref _selectedVehicle, value);
    }

    public ReactiveCommand<Unit, Unit> OnAddClientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditClientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteClientCommand { get; set; }
    public Interaction<ClientViewModel, ClientViewModel?> ShowClientDialog { get; }

    public ReactiveCommand<Unit, Unit> OnAddIssuedCarCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditIssuedCarCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteIssuedCarCommand { get; set; }
    public Interaction<IssuedCarViewModel, IssuedCarViewModel?> ShowIssuedCarDialog { get; }

    public ReactiveCommand<Unit, Unit> OnAddRefundInformationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditRefundInformationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteRefundInformationCommand { get; set; }
    public Interaction<RefundInformationViewModel, RefundInformationViewModel?> ShowRefundInformationDialog { get; }

    public ReactiveCommand<Unit, Unit> OnAddRentalInformationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditRentalInformationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteRentalInformationCommand { get; set; }
    public Interaction<RentalInformationViewModel, RentalInformationViewModel?> ShowRentalInformationDialog { get; }

    public ReactiveCommand<Unit, Unit> OnAddRentalPointCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditRentalPointCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteRentalPointCommand { get; set; }
    public Interaction<RentalPointViewModel, RentalPointViewModel?> ShowRentalPointDialog { get; }

    public ReactiveCommand<Unit, Unit> OnAddVehicleModelCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditVehicleModelCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteVehicleModelCommand { get; set; }
    public Interaction<VehicleModelViewModel, VehicleModelViewModel?> ShowVehicleModelDialog { get; }

    public ReactiveCommand<Unit, Unit> OnAddVehicleCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditVehicleCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteVehicleCommand { get; set; }
    public Interaction<VehicleViewModel, VehicleViewModel?> ShowVehicleDialog { get; }

    private async void LoadRentedVehiclesAsync()
    {
        RentedVehicles.Clear();
        ICollection<VehicleGetDto> vehicles = await _apiClient.RentedVehicleAsync();
        foreach (VehicleGetDto vehicle in vehicles)
        {
            RentedVehicles.Add(_mapper.Map<VehicleViewModel>(vehicle));
        }
    }

    private async void LoadClientAsync()
    {
        Clients.Clear();
        ICollection<ClientGetDto> clients = await _apiClient.GetClientsAsync();
        foreach (ClientGetDto client in clients)
        {
            Clients.Add(_mapper.Map<ClientViewModel>(client));
        }
    }

    private async void LoadIssuedCarAsync()
    {
        IssuedCars.Clear();
        ICollection<IssuedCar> issuedCars = await _apiClient.GetIssuedCarsAsync();
        foreach (IssuedCar issuedCar in issuedCars)
        {
            IssuedCars.Add(_mapper.Map<IssuedCarViewModel>(issuedCar));
        }
    }

    private async void LoadRefundInformationAsync()
    {
        RefundInformations.Clear();
        ICollection<RefundInformation> refundInformations = await _apiClient.GetRefundInformationsAsync();
        foreach (RefundInformation refundInformation in refundInformations)
        {
            RefundInformations.Add(_mapper.Map<RefundInformationViewModel>(refundInformation));
        }
    }

    private async void LoadRentalInformationAsync()
    {
        RentalInformations.Clear();
        ICollection<RentalInformation> rentalInformations = await _apiClient.GetRentalInformationsAsync();
        foreach (RentalInformation rentalInformation in rentalInformations)
        {
            RentalInformations.Add(_mapper.Map<RentalInformationViewModel>(rentalInformation));
        }
    }

    private async void LoadRentalPointAsync()
    {
        RentalPoints.Clear();
        ICollection<RentalPointGetDto> rentalPoints = await _apiClient.GetRentalPointsAsync();
        foreach (RentalPointGetDto rentalPoint in rentalPoints)
        {
            RentalPoints.Add(_mapper.Map<RentalPointViewModel>(rentalPoint));
        }
    }

    private async void LoadVehicleModelAsync()
    {
        VehicleModels.Clear();
        ICollection<VehicleModelGetDto> vehicleModels = await _apiClient.GetVehicleModelsAsync();
        foreach (VehicleModelGetDto vehicleModel in vehicleModels)
        {
            VehicleModels.Add(_mapper.Map<VehicleModelViewModel>(vehicleModel));
        }
    }

    private async void LoadVehicleAsync()
    {
        Vehicles.Clear();
        ICollection<VehicleGetDto> vehicles = await _apiClient.GetVehiclesAsync();
        foreach (VehicleGetDto vehicle in vehicles)
        {
            Vehicles.Add(_mapper.Map<VehicleViewModel>(vehicle));
        }
    }
}