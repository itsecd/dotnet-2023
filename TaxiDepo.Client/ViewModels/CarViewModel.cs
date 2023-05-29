using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TaxiDepo.Client.ViewModels;

public class CarViewModel : ViewModelBase
{    
    [Required] public int Id { get; set;}

    [Required] public string CarModel { get; set; } = string.Empty;

    [Required] public string CarNumber { get; set; } = string.Empty;

    [Required] public string CarColor { get; set; } = string.Empty;

    [Required] public int DriverId { get; set; }

    public ReactiveCommand<Unit, CarViewModel> OnSubmitCommand { get; set; }

    public CarViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}