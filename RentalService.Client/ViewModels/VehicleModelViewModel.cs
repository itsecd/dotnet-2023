using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace RentalService.Client.ViewModels;

public class VehicleModelViewModel: ViewModelBase
{
    [Required] [Reactive] public long Id { get; set; }
    
    [Required] [Reactive] public string Model { get; set; } = string.Empty;

    [Required] [Reactive] public string Brand { get; set; } = string.Empty;
    
    public ReactiveCommand<Unit, VehicleModelViewModel> OkButtonOnClick { get; }

    public VehicleModelViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
}