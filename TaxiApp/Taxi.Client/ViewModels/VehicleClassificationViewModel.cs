using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Taxi.Client.ViewModels;

public class VehicleClassificationViewModel : ViewModelBase
{
    public VehicleClassificationViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }

    [Reactive] public ulong Id { get; set; }

    [Required] [Reactive] public string Brand { get; set; } = string.Empty;

    [Required] [Reactive] public string Model { get; set; } = string.Empty;

    [Required] [Reactive] public string Class { get; set; } = string.Empty;

    public ReactiveCommand<Unit, VehicleClassificationViewModel> OnSubmitCommand { get; }
}