using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace TransportMgmt.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ObservableCollection<DriverViewModel> Drivers { get; } = new();
    public ObservableCollection<ModelViewModel> Models { get; } = new();
    public ObservableCollection<RoutesViewModel> Routes { get; } = new();
    public ObservableCollection<TransportViewModel> Transports { get; } = new();
    public ObservableCollection<TransportTypesViewModel> TransportTypes { get; } = new();
    public ObservableCollection<TripViewModel> Trips { get; } = new();

    public Interaction<TripViewModel, TripViewModel?> ShowTripDialog { get; }
    public Interaction<DriverViewModel, DriverViewModel?> ShowDriverDialog { get; }
    public Interaction<ModelViewModel, ModelViewModel?> ShowModelDialog { get; }
    public Interaction<TransportViewModel, TransportViewModel?> ShowTransportDialog { get; }

    private TripViewModel? _selectedTrip;
    public TripViewModel? SelectedTrip
    {
        get => _selectedTrip;
        set => this.RaiseAndSetIfChanged(ref _selectedTrip, value);
    }
    public ReactiveCommand<Unit, Unit> OnAddTripCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeTripCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteTripCommand { get; set; }
    

    private DriverViewModel? _selectedDriver;
    public DriverViewModel? SelectedDriver
    {
        get => _selectedDriver;
        set => this.RaiseAndSetIfChanged(ref _selectedDriver, value);
    }
    public ReactiveCommand<Unit, Unit> OnAddDriverCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeDriverCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteDriverCommand { get; set; }


    private ModelViewModel? _selectedModel;
    public ModelViewModel? SelectedModel
    {
        get => _selectedModel;
        set => this.RaiseAndSetIfChanged(ref _selectedModel, value);
    }
    public ReactiveCommand<Unit, Unit> OnAddModelCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeModelCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteModelCommand { get; set; }


    private TransportViewModel? _selectedTransport;
    public TransportViewModel? SelectedTransport
    {
        get => _selectedTransport;
        set => this.RaiseAndSetIfChanged(ref _selectedTransport, value);
    }
    public ReactiveCommand<Unit, Unit> OnAddTransportCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeTransportCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteTransportCommand { get; set; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowDriverDialog = new Interaction<DriverViewModel, DriverViewModel?>();
        ShowTripDialog = new Interaction<TripViewModel, TripViewModel?>();
        ShowModelDialog = new Interaction<ModelViewModel, ModelViewModel?>();
        ShowTransportDialog = new Interaction<TransportViewModel, TransportViewModel?>();

        OnAddDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(new DriverViewModel());
            if (driverViewModel != null)
            {
                var newDriver = await _apiClient.AddDriversAsync(_mapper.Map<DriverPostDto>(driverViewModel));
                Drivers.Add(_mapper.Map<DriverViewModel>(newDriver));
            }
        });

        OnChangeDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(SelectedDriver!);
            if (driverViewModel != null)
            {
                await _apiClient.UpdateDriversAsync(SelectedDriver!.Id, _mapper.Map<DriverPostDto>(driverViewModel));
                _mapper.Map(driverViewModel, SelectedDriver);
            }
        }, this.WhenAnyValue(vm => vm.SelectedDriver).Select(selectDriver => selectDriver != null));

        OnDeleteDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDriversAsync(SelectedDriver!.Id);
            Drivers.Remove(SelectedDriver);
        }, this.WhenAnyValue(vm => vm.SelectedDriver).Select(selectDriver => selectDriver != null));

        OnAddTripCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var tripViewModel = await ShowTripDialog.Handle(new TripViewModel());
            if (tripViewModel != null)
            {
                var newTrip = await _apiClient.AddTripsAsync(_mapper.Map<TripPostDto>(tripViewModel));
                Trips.Add(_mapper.Map<TripViewModel>(newTrip));
            }
        });

        OnChangeTripCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var tripViewModel = await ShowTripDialog.Handle(new TripViewModel());
            if (tripViewModel != null)
            {
                await _apiClient.UpdateTripsAsync(SelectedTrip!.Id, _mapper.Map<TripPostDto>(tripViewModel));
                _mapper.Map(tripViewModel, SelectedTrip);
            }
        }, this.WhenAnyValue(vm => vm.SelectedTrip).Select(selectTrip => selectTrip != null));

        OnDeleteTripCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteTripsAsync(SelectedTrip!.Id);
            Trips.Remove(SelectedTrip);   
        }, this.WhenAnyValue(vm => vm.SelectedTrip).Select(selectTrip => selectTrip != null));

        OnAddModelCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var modelViewModel = await ShowModelDialog.Handle(new ModelViewModel());
            if (modelViewModel != null)
            {
                var newModel = await _apiClient.AddModeslAsync(_mapper.Map<ModelPostDto>(modelViewModel));
                Models.Add(_mapper.Map<ModelViewModel>(newModel));
            }
        });

        OnChangeModelCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var modelViewModel = await ShowModelDialog.Handle(SelectedModel!);
            if (modelViewModel != null)
            {
                await _apiClient.UpdateModeslAsync(SelectedModel!.Id, _mapper.Map<ModelPostDto>(modelViewModel));
                _mapper.Map(modelViewModel, SelectedModel);
            }
        }, this.WhenAnyValue(vm => vm.SelectedModel).Select(selectModel => selectModel != null));

        OnDeleteModelCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteModeslAsync(SelectedModel!.Id);
            Models.Remove(SelectedModel);
        }, this.WhenAnyValue(vm => vm.SelectedModel).Select(selectModel => selectModel != null));

        OnAddTransportCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var transportViewModel = await ShowTransportDialog.Handle(new TransportViewModel());
            if (transportViewModel != null)
            {
                var newTransport = await _apiClient.AddTransportsAsync(_mapper.Map<TransportPostDto>(transportViewModel));
                Transports.Add(_mapper.Map<TransportViewModel>(newTransport));
            }
        });

        OnChangeTransportCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var transportViewModel = await ShowTransportDialog.Handle(SelectedTransport!);
            if (transportViewModel != null)
            {
                await _apiClient.UpdateTransportsAsync(SelectedTransport!.Id, _mapper.Map<TransportPostDto>(transportViewModel));
                _mapper.Map(transportViewModel, SelectedTransport);
            }
        }, this.WhenAnyValue(vm => vm.SelectedTransport).Select(selectTransport => selectTransport != null));

        OnDeleteTransportCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteTransportsAsync(SelectedTransport!.Id);
            Transports.Remove(SelectedTransport);
        }, this.WhenAnyValue(vm => vm.SelectedTransport).Select(selectTransport => selectTransport != null));

        RxApp.MainThreadScheduler.Schedule(LoadDriversAsync); //Выполнение после прогрузки окна
    }

    private async void LoadDriversAsync()
    {
        var drivers = await _apiClient.GetDriversAsync();
        foreach (var driver in drivers)
        {
            Drivers.Add(_mapper.Map<DriverViewModel>(driver));
        }

        var trips = await _apiClient.GetTripsAsync();
        foreach (var trip in trips)
        {
            Trips.Add(_mapper.Map<TripViewModel>(trip));
        }

        var models = await _apiClient.GetModelsAsync();
        foreach (var model in models)
        {
            Models.Add(_mapper.Map<ModelViewModel>(model));
        }

        var transports = await _apiClient.GetTransportsAsync();
        foreach (var transport in transports)
        {
            Transports.Add(_mapper.Map<TransportViewModel>(transport));
        }

        var transportTypes = await _apiClient.GetTransportTypesAsync();
        foreach (var transportType in transportTypes)
        {
            TransportTypes.Add(_mapper.Map<TransportTypesViewModel>(transportType));
        }

        var routes = await _apiClient.GetRoutesAsync();
        foreach (var route in routes)
        {
            Routes.Add(_mapper.Map<RoutesViewModel>(route));
        }

    }
}
