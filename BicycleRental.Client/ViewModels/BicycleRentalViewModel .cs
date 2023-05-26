using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ReactiveUI;
using System.Reactive;

namespace BicycleRental.Client.ViewModels;
public class BicycleRentalViewModel : ViewModelBase
{
    private int _rentalId;
    [Required]
    public int RentalId { 
        get => _rentalId; 
        set => this.RaiseAndSetIfChanged(ref _rentalId, value); 
    }

    private int _serialNumber;
    [Required]
    public int SerialNumber { 
        get => _serialNumber; 
        set => this.RaiseAndSetIfChanged(ref _serialNumber, value);
    }

    private int _customerId;
    [Required]
    public int CustomerId { 
        get => _customerId; 
        set => this.RaiseAndSetIfChanged(ref _customerId, value); 
    }

    private int _rentalTime;
    [Required]
    public int RentalTime { 
        get => _rentalTime; 
        set => this.RaiseAndSetIfChanged(ref _rentalTime, value); 
    }

    public ReactiveCommand<Unit, BicycleRentalViewModel> OnSubmitCommand { get; }

    public BicycleRentalViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
