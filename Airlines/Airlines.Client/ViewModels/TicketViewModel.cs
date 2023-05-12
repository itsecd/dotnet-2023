using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reactive;

namespace Airlines.Client.ViewModels;
public class TicketViewModel : ViewModelBase
{
    [Required]
    private int _id;
    public int Id { 
        get=>_id; 
        set=>this.RaiseAndSetIfChanged(ref _id,value); 
    }
    private int _passengerId;
    [Required]
    public int PassengerId
    {
        get => _passengerId;
        set => this.RaiseAndSetIfChanged(ref _passengerId, value);
    }
    private int _flightId;
    [Required]
    public int FlightId
    {
        get => _flightId;
        set => this.RaiseAndSetIfChanged(ref _flightId, value);
    }
    private int _ticketNumber;
    [Required]
    public int TicketNumber
    {
        get => _ticketNumber;
        set => this.RaiseAndSetIfChanged(ref _ticketNumber, value);
    }
    private string _seatNumber=string.Empty;
    [Required]
    public string? SeatNumber
    {
        get => _seatNumber;
        set => this.RaiseAndSetIfChanged(ref _seatNumber, value);
    }
    private int _baggageWeight;
    [Required]
    public int BaggageWeight
    {
        get => _baggageWeight;
        set => this.RaiseAndSetIfChanged(ref _baggageWeight, value);
    }
    public ReactiveCommand<Unit, TicketViewModel> OnSubmitCommand { get; }

    public TicketViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
