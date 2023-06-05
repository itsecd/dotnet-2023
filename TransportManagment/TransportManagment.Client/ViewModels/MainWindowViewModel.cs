using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace TransportManagment.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<DriverViewModel> Drivers { get; set; } = new();
    public ObservableCollection<TransportViewModel> Transports { get; set; } = new();
    public ObservableCollection<RouteViewModel> Routes { get; set; } = new();
    public ObservableCollection<DriverPropertiesRouteViewModel> RoutesOfDrivers { get; set; } = new();
    public ObservableCollection<TopDriversViewModel> TopDrivers { get; set; } = new();
    public ObservableCollection<TransportInfoViewModel> TransportsInfo { get; set; } = new();
    public ObservableCollection<TransportTimeViewModel> TransportsTime { get; set; } = new();
    public ObservableCollection<TransportViewModel> TransportsWithId { get; set; } = new();
    public ObservableCollection<DriverViewModel> DriversWithDate { get; set; } = new();
    
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;
    private DriverViewModel? _selectedDriver;
    public DriverViewModel? SelectedDriver
    {
        get => _selectedDriver;
        set => this.RaiseAndSetIfChanged(ref _selectedDriver, value);
    }
    private TransportViewModel? _selectedTransport;
    public TransportViewModel? SelectedTransport
    {
        get => _selectedTransport;
        set => this.RaiseAndSetIfChanged(ref _selectedTransport, value);
    }
    private RouteViewModel? _selectedRoute;
    public RouteViewModel? SelectedRoute
    {
        get => _selectedRoute;
        set => this.RaiseAndSetIfChanged(ref _selectedRoute, value);
    }
    private DriverPropertiesRouteViewModel? _selectedRouteOfDriver;
    public DriverPropertiesRouteViewModel? SelectedRouteOfDriver
    {
        get => _selectedRouteOfDriver;
        set => this.RaiseAndSetIfChanged(ref _selectedRouteOfDriver, value);
    }
    public ReactiveCommand<Unit, Unit> OnAddDriverCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeDriverCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteDriverCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddTransportCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeTransportCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteTransportCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddRouteCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeRouteCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteRouteCommand { get; set; }
    public Interaction<DriverViewModel, DriverViewModel?> ShowDriverDialog { get; }
    public Interaction<TransportViewModel, TransportViewModel?> ShowTransportDialog { get; }
    public Interaction<RouteViewModel, RouteViewModel?> ShowRouteDialog { get; }
    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();
        RxApp.MainThreadScheduler.Schedule(LoadAsync);
        ShowDriverDialog = new Interaction<DriverViewModel, DriverViewModel?>();
        ShowTransportDialog = new Interaction<TransportViewModel, TransportViewModel?>();
        ShowRouteDialog = new Interaction<RouteViewModel, RouteViewModel?>();
        OnAddDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(new DriverViewModel());
            if (driverViewModel != null)
            {
                var newDriver = await _apiClient.AddDriverAsync(_mapper.Map<DriverPostDto>(driverViewModel));
                Drivers.Add(_mapper.Map<DriverViewModel>(newDriver));
            }
        });
        OnChangeDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(SelectedDriver!);
            if (driverViewModel != null)
            {
                await _apiClient.UpdateDriverAsync(SelectedDriver!.DriverId, _mapper.Map<DriverPostDto>(driverViewModel));
                _mapper.Map(driverViewModel, SelectedDriver);
            }
        }, this.WhenAnyValue(vm => vm.SelectedDriver).Select(selectDriver => selectDriver != null));
        OnDeleteDriverCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDriverAsync(SelectedDriver!.DriverId);
            Drivers.Remove(SelectedDriver);
        }, this.WhenAnyValue(vm => vm.SelectedDriver).Select(selectDriver => selectDriver != null));
        OnAddTransportCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var transportViewModel = await ShowTransportDialog.Handle(new TransportViewModel());
            if (transportViewModel != null)
            {
                var newTransport = await _apiClient.AddTransportAsync(_mapper.Map<TransportPostDto>(transportViewModel));
                Transports.Add(_mapper.Map<TransportViewModel>(newTransport));
            }
        });
        OnChangeTransportCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var transportViewModel = await ShowTransportDialog.Handle(SelectedTransport!);
            if (transportViewModel != null)
            {
                await _apiClient.UpdateTransportAsync(SelectedTransport!.TransportId, _mapper.Map<TransportPostDto>(transportViewModel));
                _mapper.Map(transportViewModel, SelectedTransport);
            }
        }, this.WhenAnyValue(vm => vm.SelectedTransport).Select(selectTransport => selectTransport != null));
        OnDeleteTransportCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteTransportAsync(SelectedTransport!.TransportId);
            Transports.Remove(SelectedTransport);
        }, this.WhenAnyValue(vm => vm.SelectedTransport).Select(selectTransport => selectTransport != null));
        OnAddRouteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var routeViewModel = await ShowRouteDialog.Handle(new RouteViewModel());
            if (routeViewModel != null)
            {
                var newRoute = await _apiClient.AddRouteAsync(_mapper.Map<RoutePostDto>(routeViewModel));
                Routes.Add(_mapper.Map<RouteViewModel>(newRoute));
            }
        });
        OnChangeRouteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var routeViewModel = await ShowRouteDialog.Handle(SelectedRoute!);
            if (routeViewModel != null)
            {
                await _apiClient.UpdateRouteAsync(SelectedRoute!.RouteId, _mapper.Map<RoutePostDto>(routeViewModel));
                _mapper.Map(routeViewModel, SelectedRoute);
            }
        }, this.WhenAnyValue(vm => vm.SelectedRoute).Select(selectRoute => selectRoute != null));
        OnDeleteRouteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRouteAsync(SelectedRoute!.RouteId);
            Routes.Remove(SelectedRoute);
        }, this.WhenAnyValue(vm => vm.SelectedRoute).Select(selectRoute => selectRoute != null));
    }
    private async void LoadAsync()
    {
        var drivers = await _apiClient.GetDriversAsync();
        foreach (var driver in drivers)
        {
            Drivers.Add(_mapper.Map<DriverViewModel>(driver));
        }
        var transports = await _apiClient.GetTransportAsync();
        foreach (var transport in transports)
        {
            Transports.Add(_mapper.Map<TransportViewModel>(transport));
        }
        var routes = await _apiClient.GetRouteAsync();
        foreach (var route in routes)
        {
            Routes.Add(_mapper.Map<RouteViewModel>(route));
        }
        var routesOsDrivers = await _apiClient.GetDriverPropertiesAsync();
        foreach (var routesOsDriver in routesOsDrivers)
        {
            RoutesOfDrivers.Add(_mapper.Map<DriverPropertiesRouteViewModel>(routesOsDriver));
        }
        var topDrivers = await _apiClient.GetTopDriversAsync();
        foreach (var topDriver in topDrivers)
        {
            TopDrivers.Add(_mapper.Map<TopDriversViewModel>(topDriver));
        }
        var transportsInfo = await _apiClient.GetTransportsInfoAsync(new System.DateTime(1990, 11, 01, 01, 01, 01), System.DateTime.Now);
        foreach (var transportInfo in transportsInfo)
        {
            TransportsInfo.Add(_mapper.Map<TransportInfoViewModel>(transportInfo));
        }
        var transportsTime = await _apiClient.GetTransportsTimeModelAsync();
        foreach (var transportTime in transportsTime)
        {
            TransportsTime.Add(_mapper.Map<TransportTimeViewModel>(transportTime));
        }
        var transportsWithId = await _apiClient.GetTransportWithId(1);
        foreach (var transportWithId in transportsWithId)
        {
            TransportsWithId.Add(_mapper.Map<TransportViewModel>(transportWithId));
        }
        var driversWithDate = await _apiClient.GetDriversWithDate(new System.DateTime(2002, 11, 01, 01, 01, 01), System.DateTime.Now);
        foreach (var driverWithDate in driversWithDate)
        {
            DriversWithDate.Add(_mapper.Map<DriverViewModel>(driverWithDate));
        }
    }
}
   