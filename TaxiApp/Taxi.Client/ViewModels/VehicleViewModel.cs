using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Taxi.Client.ViewModels;

public class VehicleViewModel: ViewModelBase
{
    [Reactive] 
    public ulong Id { get; set; }
    
    [Required] 
    [Reactive] 
    public string RegistrationCarPlate { get; set; } = string.Empty;
    
    [Required] 
    [Reactive] 
    public string Colour { get; set; } = string.Empty;
    
    [Required] 
    [Reactive] 
    public ulong VehicleClassificationId { get; set; }
    
    [Required] 
    [Reactive] 
    public ulong DriverId { get; set; }
    
    
    public ReactiveCommand<Unit, VehicleViewModel> OnSubmitCommand { get; }

    public VehicleViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}