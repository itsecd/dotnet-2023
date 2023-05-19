using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace RentalService.Client.ViewModels;

public class VehicleViewModel : ViewModelBase
{
    public VehicleViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }

    [Required] [Reactive] public long Id { get; set; }

    [Required] [Reactive] public string Number { get; set; } = string.Empty;

    [Required] [Reactive] public ulong VehicleModelId { get; set; }

    [Required] [Reactive] public string Colour { get; set; } = string.Empty;

    public ReactiveCommand<Unit, VehicleViewModel> OkButtonOnClick { get; }
}