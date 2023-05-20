using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace AirplaneBookingSystem.Client.ViewModels;
public class TicketViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private int _ticketNumber;
    [Required]
    public int TicketNumber
    {
        get => _ticketNumber;
        set => this.RaiseAndSetIfChanged(ref _ticketNumber, value);
    }
    private int _clientId;
    [Required]
    public int ClientId
    {
        get => _clientId;
        set => this.RaiseAndSetIfChanged(ref _clientId, value);
    }
    private int _flightId;
    [Required]
    public int FlightId
    {
        get => _flightId;
        set => this.RaiseAndSetIfChanged(ref _flightId, value);
    }
    public ReactiveCommand<Unit, TicketViewModel> OnSubmitCommand { get; }
    public TicketViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}