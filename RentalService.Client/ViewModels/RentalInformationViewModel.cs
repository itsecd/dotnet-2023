using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace RentalService.Client.ViewModels;

public class RentalInformationViewModel: ViewModelBase
{
    [Required] [Reactive] public long Id { get; set; }
    
    [Required] [Reactive] public long RentalPointId { get; set; }
    
    [Required] [Reactive] public DateTimeOffset RentalDate { get; set; } = DateTime.Today;
    
    [Required] [Reactive] public long RentalPeriod { get; set; }
    
    [Required] [Reactive] public long IssuedCarId { get; set; }
    
    public ReactiveCommand<Unit, RentalInformationViewModel> OkButtonOnClick { get; }

    public RentalInformationViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
}