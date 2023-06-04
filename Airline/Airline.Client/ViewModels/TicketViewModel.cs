using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Airline.Client.ViewModels;
public class TicketViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _number;
    [Required]
    public int Number
    {
        get => _number;
        set => this.RaiseAndSetIfChanged(ref _number, value);
    }
    private string _seatNumber = string.Empty;                
    public string SeatNumber
    {
        get => _seatNumber;
        set => this.RaiseAndSetIfChanged(ref _seatNumber, value);
    }
    private double _baggageWeight;
    public double BaggageWeight
    {
        get => _baggageWeight;
        set => this.RaiseAndSetIfChanged(ref _baggageWeight, value);
    }

    public ReactiveCommand<Unit, TicketViewModel> OnSubmitTicketCommand { get; }
    public TicketViewModel()
    {
        OnSubmitTicketCommand = ReactiveCommand.Create(() => this);
    }

}

