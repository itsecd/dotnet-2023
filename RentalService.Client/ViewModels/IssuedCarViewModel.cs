using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace RentalService.Client.ViewModels;

public class IssuedCarViewModel : ViewModelBase
{
    public IssuedCarViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }

    [Required] [Reactive] public long Id { get; set; }

    [Required] [Reactive] public long VehicleId { get; set; }

    [Required] [Reactive] public long ClientId { get; set; }

    [Required] [Reactive] public long RentalInformationId { get; set; }

    [Reactive] public long? RefundInformationId { get; set; }
    public ReactiveCommand<Unit, IssuedCarViewModel> OkButtonOnClick { get; }
}