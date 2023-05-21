using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Linq;
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
    public ObservableCollection<TicketViewModel> Tickets { get; } = new();
    public ObservableCollection<ClientViewModel> Clients { get; } = new();
    public ObservableCollection<FlightViewModel> FlightWithMaxAmountOfClients { get; set; } = new();

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
    private TicketViewModel? _selectedTicket;
    public TicketViewModel? SelectedTicket
    {
        get => _selectedTicket;
        set => this.RaiseAndSetIfChanged(ref _selectedTicket, value);
    }
    private ClientViewModel? _selectedClient;
    public ClientViewModel? SelectedClient
    {
        get => _selectedClient;
        set => this.RaiseAndSetIfChanged(ref _selectedClient, value);
    }
    public ReactiveCommand<Unit, Unit> OnAddCommandAirplane { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandAirplane { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandAirplane { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCommandFlight { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandFlight { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandFlight { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCommandTicket { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandTicket { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandTicket { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCommandClient { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandClient { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandClient { get; set; }

    public ReactiveCommand<Unit, Unit> ShowFlightWithMaxAmountOfClients { get; set; }
    public Interaction<AirplaneViewModel, AirplaneViewModel?> ShowAirplaneDialog { get; set; }
    public Interaction<FlightViewModel, FlightViewModel?> ShowFlightDialog { get; set; }
    public Interaction<TicketViewModel, TicketViewModel?> ShowTicketDialog { get; set; }
    public Interaction<ClientViewModel, ClientViewModel?> ShowClientDialog { get; set; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowAirplaneDialog = new Interaction<AirplaneViewModel, AirplaneViewModel?>();
        ShowFlightDialog = new Interaction<FlightViewModel, FlightViewModel?>();
        ShowTicketDialog = new Interaction<TicketViewModel, TicketViewModel?>();
        ShowClientDialog = new Interaction<ClientViewModel, ClientViewModel?>();

        OnAddCommandAirplane = ReactiveCommand.CreateFromTask(async () =>
        {
            var airplaneViewModel = await ShowAirplaneDialog.Handle(new AirplaneViewModel());
            if (airplaneViewModel != null)
            {
                var newAirplane = _mapper.Map<AirplanePostDto>(airplaneViewModel);
                await _apiClient.AddAirplaneAsync(newAirplane);
                Airplanes.Add(airplaneViewModel);
                Airplanes.Clear();
                Clients.Clear();
                Tickets.Clear();
                Flights.Clear();
                FlightWithMaxAmountOfClients.Clear();
                LoadAllAsync();
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
            if (flightViewModel != null && Airplanes.Any(a => a.Id == flightViewModel.AirplaneId))
            {
                var newFlight = _mapper.Map<FlightPostDto>(flightViewModel);
                await _apiClient.AddFlightAsync(newFlight);
                Flights.Add(flightViewModel);
                Airplanes.Clear();
                Clients.Clear();
                Tickets.Clear();
                Flights.Clear();
                FlightWithMaxAmountOfClients.Clear();
                LoadAllAsync();
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

        OnAddCommandTicket = ReactiveCommand.CreateFromTask(async () =>
        {
            var ticketViewModel = await ShowTicketDialog.Handle(new TicketViewModel());
            if (ticketViewModel != null && Flights.Any(f => f.Id == ticketViewModel.FlightId) && Clients.Any(c => c.Id == ticketViewModel.ClientId))
            {
                var newTicket = _mapper.Map<TicketPostDto>(ticketViewModel);
                await _apiClient.AddTicketAsync(newTicket);
                Tickets.Add(ticketViewModel);
                Airplanes.Clear();
                Clients.Clear();
                Tickets.Clear();
                Flights.Clear();
                FlightWithMaxAmountOfClients.Clear();
                LoadAllAsync();
            }
        });

        OnChangeCommandTicket = ReactiveCommand.CreateFromTask(async () =>
        {
            var ticketViewModel = await ShowTicketDialog.Handle(SelectedTicket!);
            if (ticketViewModel != null)
            {
                await _apiClient.UpdateTicketAsync(SelectedTicket!.Id, _mapper.Map<TicketPostDto>(ticketViewModel));
                _mapper.Map(ticketViewModel, SelectedTicket);
            }
        }, this.WhenAnyValue(vm => vm.SelectedTicket).Select(selectedTicket => selectedTicket != null));

        OnDeleteCommandTicket = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteTicketAsync(SelectedTicket!.Id);
            Tickets.Remove(SelectedTicket);

        }, this.WhenAnyValue(vm => vm.SelectedTicket).Select(selectedTicket => selectedTicket != null));

        OnAddCommandClient = ReactiveCommand.CreateFromTask(async () =>
        {
            var clientViewModel = await ShowClientDialog.Handle(new ClientViewModel());
            if (clientViewModel != null)
            {
                var newClient = _mapper.Map<ClientPostDto>(clientViewModel);
                await _apiClient.AddClientAsync(newClient);
                Clients.Add(clientViewModel);
                Airplanes.Clear();
                Clients.Clear();
                Tickets.Clear();
                Flights.Clear();
                FlightWithMaxAmountOfClients.Clear();
                LoadAllAsync();
            }
        });

        OnChangeCommandClient = ReactiveCommand.CreateFromTask(async () =>
        {
            var clientViewModel = await ShowClientDialog.Handle(SelectedClient!);
            if (clientViewModel != null)
            {
                await _apiClient.UpdateClientAsync(SelectedClient!.Id, _mapper.Map<ClientPostDto>(clientViewModel));
                _mapper.Map(clientViewModel, SelectedClient);
            }
        }, this.WhenAnyValue(vm => vm.SelectedClient).Select(selectedClient => selectedClient != null));

        OnDeleteCommandClient = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteClientAsync(SelectedClient!.Id);
            Clients.Remove(SelectedClient);

        }, this.WhenAnyValue(vm => vm.SelectedClient).Select(selectedClient => selectedClient != null));

        RxApp.MainThreadScheduler.Schedule(LoadAllAsync);
    }

    private async void LoadAllAsync()
    {
        var flights = await _apiClient.GetFlightsAsync();
        foreach (var flight in flights)
        {
            Flights.Add(_mapper.Map<FlightViewModel>(flight));
        }
        var tickets = await _apiClient.GetTicketsAsync();
        foreach (var ticket in tickets)
        {
            Tickets.Add(_mapper.Map<TicketViewModel>(ticket));
        }
        var airplanes = await _apiClient.GetAirplanesAsync();
        foreach (var airplane in airplanes)
        {
            Airplanes.Add(_mapper.Map<AirplaneViewModel>(airplane));
        }
        var clients = await _apiClient.GetClientsAsync();
        foreach (var client in clients)
        {
            Clients.Add(_mapper.Map<ClientViewModel>(client));
        }
        var analiticsFlights = await _apiClient.FlightWithMaxAmountOfClients();
        foreach (var analiticsFlight in analiticsFlights)
        {
            FlightWithMaxAmountOfClients.Add(_mapper.Map<FlightViewModel>(analiticsFlight));
        }
    }
}