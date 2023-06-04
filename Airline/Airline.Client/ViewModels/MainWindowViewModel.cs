using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Airline.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<AirplaneViewModel> Airplanes { get; } = new();
    public ObservableCollection<PassengerViewModel> Passengers { get; } = new();
    public ObservableCollection<TicketViewModel> Tickets { get; } = new();


    private AirplaneViewModel? _selectedAirplane;
    public AirplaneViewModel? SelectedAirplane
    {
        get => _selectedAirplane;
        set => this.RaiseAndSetIfChanged(ref _selectedAirplane, value);
    }


    private PassengerViewModel? _selectedPassenger;
    public PassengerViewModel? SelectedPassenger
    {
        get => _selectedPassenger;
        set => this.RaiseAndSetIfChanged(ref _selectedPassenger, value);
    }

    private TicketViewModel? _selectedTicket;
    public TicketViewModel? SelectedTicket
    {
        get => _selectedTicket;
        set => this.RaiseAndSetIfChanged(ref _selectedTicket, value);
    }

    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddAirplaneCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeAirplaneCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteAirplaneCommand { get; set; }
    public Interaction<AirplaneViewModel, AirplaneViewModel?> ShowAirplaneDialog { get; }


    public ReactiveCommand<Unit, Unit> OnAddFlightCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeFlightCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteFlightCommand { get; set; }


    public ReactiveCommand<Unit, Unit> OnAddPassengerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangePassengerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeletePassengerCommand { get; set; }
    public Interaction<PassengerViewModel, PassengerViewModel?> ShowPassengerDialog { get; }


    public ReactiveCommand<Unit, Unit> OnAddTicketCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeTicketCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteTicketCommand { get; set; }
    public Interaction<TicketViewModel, TicketViewModel?> ShowTicketDialog { get; }


    public MainWindowViewModel() 
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowAirplaneDialog = new Interaction<AirplaneViewModel, AirplaneViewModel?>();
        ShowPassengerDialog = new Interaction<PassengerViewModel, PassengerViewModel?>();  
        ShowTicketDialog = new Interaction<TicketViewModel, TicketViewModel?>();

        OnAddAirplaneCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var airplaneViewModel = await ShowAirplaneDialog.Handle(new AirplaneViewModel());

            if(airplaneViewModel != null)
            {
                var newAirplane = _mapper.Map<AirplanePostDto>(airplaneViewModel);
                await _apiClient.AddAirplanesAsync(newAirplane);
                Airplanes.Add(airplaneViewModel);
            }
        });


        OnChangeAirplaneCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var airplaneViewModel = await ShowAirplaneDialog.Handle(SelectedAirplane!);

            if (airplaneViewModel != null)
            {
                var newAirplane = _mapper.Map<AirplanePostDto>(airplaneViewModel);
                await _apiClient.UpdateAirplaneAsync(SelectedAirplane!.Id, newAirplane);
                _mapper.Map(airplaneViewModel, SelectedAirplane);
            }
        }, this.WhenAnyValue(vm => vm.SelectedAirplane).Select(selectAirplane => selectAirplane != null));

        OnDeleteAirplaneCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteAirplaneAsync(SelectedAirplane!.Id);
            Airplanes.Remove(SelectedAirplane);
        }, this.WhenAnyValue(vm => vm.SelectedAirplane).Select(selectAirplane => selectAirplane != null));


        OnAddPassengerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var passengerViewModel = await ShowPassengerDialog!.Handle(new PassengerViewModel());
            if (passengerViewModel != null)
            {
                var newPassenger = _mapper.Map<PassengerPostDto>(passengerViewModel);
                await _apiClient.AddPassengerAsync(newPassenger);
                Passengers.Add(passengerViewModel);
            }
        });
        OnChangePassengerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var passengerViewModel = await ShowPassengerDialog.Handle(SelectedPassenger!);
            if (passengerViewModel != null)
            {
                await _apiClient.UpdatePassengerAsync(SelectedPassenger!.Id, _mapper.Map<PassengerPostDto>(passengerViewModel));
                _mapper.Map(passengerViewModel, SelectedPassenger);
            }
        }, this.WhenAnyValue(vm => vm.SelectedPassenger).Select(selectPassenger => selectPassenger != null));
        OnDeletePassengerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeletePassengerAsync(SelectedPassenger!.Id);
            Passengers.Remove(SelectedPassenger);

        }, this.WhenAnyValue(vm => vm.SelectedPassenger).Select(selectPassenger => selectPassenger != null));


        OnAddTicketCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var ticketViewModel = await ShowTicketDialog!.Handle(new TicketViewModel());
            if (ticketViewModel != null)
            {
                var newTicket = _mapper.Map<TicketPostDto>(ticketViewModel);
                await _apiClient.AddTicketAsync(newTicket);
                Tickets.Add(ticketViewModel);
            }
        });
        OnChangeTicketCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var ticketViewModel = await ShowTicketDialog.Handle(SelectedTicket!);
            if (ticketViewModel != null)
            {
                await _apiClient.UpdateTicketAsync(SelectedTicket!.Id, _mapper.Map<TicketPostDto>(ticketViewModel));
                _mapper.Map(ticketViewModel, SelectedTicket);
            }
        }, this.WhenAnyValue(vm => vm.SelectedTicket).Select(selectTicket => selectTicket != null));
        OnDeleteTicketCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteTicketAsync(SelectedTicket!.Id);
            Tickets.Remove(SelectedTicket);

        }, this.WhenAnyValue(vm => vm.SelectedTicket).Select(selectTicket => selectTicket != null));

        RxApp.MainThreadScheduler.Schedule(LoadAllAsync);
    }

    private async void LoadAllAsync()
    {
        var airplanes = await _apiClient.GetAirplanesAsync();
        foreach (var airplane in airplanes)
        {
            Airplanes.Add(_mapper.Map<AirplaneViewModel>(airplane));
        }

        var passengers = await _apiClient.GetPassengersAsync();
        foreach (var passenger in passengers)
        {
            Passengers.Add(_mapper.Map<PassengerViewModel>(passenger));
        }

        var tickets = await _apiClient.GetTicketsAsync();
        foreach (var ticket in tickets)
        {
            Tickets.Add(_mapper.Map<TicketViewModel>(ticket));
        }
    }
}
