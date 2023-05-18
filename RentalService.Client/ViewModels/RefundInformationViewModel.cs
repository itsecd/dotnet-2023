using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace RentalService.Client.ViewModels;

public class RefundInformationViewModel: ViewModelBase
{
    [Required] [Reactive] public long Id { get; set; }
    
    [Required] [Reactive] public long RentalPointId { get; set; }
    
    [Required] [Reactive] public DateTimeOffset RefundDate { get; set; } = DateTime.Today;
    
    [Required] [Reactive] public long IssuedCarId { get; set; }
    
    public ReactiveCommand<Unit, RefundInformationViewModel> OkButtonOnClick { get; }

    public RefundInformationViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
}