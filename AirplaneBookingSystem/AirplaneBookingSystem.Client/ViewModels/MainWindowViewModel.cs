using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace AirplaneBookingSystem.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;
    public ObservableCollection<AirplaneViewModel> Airplanes { get; } = new();
    public ObservableCollection<FlightViewModel> Flights { get; } = new();

    private AirplaneViewModel? _selectedAirplane;
    public AirplaneViewModel? SelectedAirplane
    {
        get => _selectedAirplane;
        set => this.RaiseAndSetIfChanged(ref _selectedAirplane, value);
    }
    private FlightViewModel? _selectedFlight;
    public FlightViewModel? SelectedFlight
    {
        get => _selectedFlight;
        set => this.RaiseAndSetIfChanged(ref _selectedFlight, value);
    }

    public ReactiveCommand<Unit, Unit> OnAddCommandAirplane { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandAirplane { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandAirplane { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCommandFlight { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandFlight { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandFlight { get; set; }
    public Interaction<AirplaneViewModel, AirplaneViewModel?> ShowAirplaneDialog { get; set; }
    public Interaction<FlightViewModel, FlightViewModel?> ShowFlightDialog { get; set; }
    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowAirplaneDialog = new Interaction<AirplaneViewModel, AirplaneViewModel?>();
        ShowFlightDialog = new Interaction<FlightViewModel, FlightViewModel?>();

        OnAddCommandAirplane = ReactiveCommand.CreateFromTask(async () =>
        {
            var airplaneViewModel = await ShowAirplaneDialog.Handle(new AirplaneViewModel());
            if (airplaneViewModel != null)
            {
                await _apiClient.AddAirplaneAsync(_mapper.Map<AirplanePostDto>(airplaneViewModel));
                Airplanes.Add(_mapper.Map<AirplaneViewModel>(airplaneViewModel));
            }
        });

        OnChangeCommandAirplane = ReactiveCommand.CreateFromTask(async () =>
        {
            var airplaneViewModel = await ShowAirplaneDialog.Handle(SelectedAirplane!);
            if (airplaneViewModel != null)
            {
                await _apiClient.UpdateAirplaneAsync(SelectedAirplane!.Id, _mapper.Map<AirplanePostDto>(airplaneViewModel));
                _mapper.Map(airplaneViewModel, SelectedAirplane);
            }
        }, this.WhenAnyValue(vm => vm.SelectedAirplane).Select(selectedAirplane => selectedAirplane != null));

        OnDeleteCommandAirplane = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteAirplaneAsync(SelectedAirplane!.Id);
            Airplanes.Remove(SelectedAirplane);

        }, this.WhenAnyValue(vm => vm.SelectedAirplane).Select(selectedAirplane => selectedAirplane != null));


        OnAddCommandFlight = ReactiveCommand.CreateFromTask(async () =>
        {
            var flightViewModel = await ShowFlightDialog.Handle(new FlightViewModel());
            if (flightViewModel != null)
            {
                await _apiClient.AddFlightAsync(_mapper.Map<FlightPostDto>(flightViewModel));
                Flights.Add(_mapper.Map<FlightViewModel>(flightViewModel));
            }
        });

        OnChangeCommandFlight = ReactiveCommand.CreateFromTask(async () =>
        {
            var flightViewModel = await ShowFlightDialog.Handle(SelectedFlight!);
            if (flightViewModel != null)
            {
                await _apiClient.UpdateFlightAsync(SelectedFlight!.Id, _mapper.Map<FlightPostDto>(flightViewModel));
                _mapper.Map(flightViewModel, SelectedFlight);
            }
        }, this.WhenAnyValue(vm => vm.SelectedFlight).Select(selectedFlight => selectedFlight != null));

        OnDeleteCommandFlight = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteFlightAsync(SelectedFlight!.Id);
            Flights.Remove(SelectedFlight);

        }, this.WhenAnyValue(vm => vm.SelectedFlight).Select(selectedFlight => selectedFlight != null));

        RxApp.MainThreadScheduler.Schedule(LoadAirplanesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadFlightsAsync);
    }

    private async void LoadAirplanesAsync()
    {
        var airplanes = await _apiClient.GetAirplanesAsync();
        foreach (var airplane in airplanes)
        {
            Airplanes.Add(_mapper.Map<AirplaneViewModel>(airplane));
        }
    }
    private async void LoadFlightsAsync()
    {
        var flights = await _apiClient.GetFlightsAsync();
        foreach (var flight in flights)
        {
            Flights.Add(_mapper.Map<FlightViewModel>(flight));
        }
    }
}