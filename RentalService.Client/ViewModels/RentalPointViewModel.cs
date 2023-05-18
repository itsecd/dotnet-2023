using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace RentalService.Client.ViewModels;

public class RentalPointViewModel: ViewModelBase
{
    [Required] [Reactive] public long Id { get; set; }
    
    [Required] [Reactive] public string Title { get; set; } = string.Empty;
    
    [Required] [Reactive] public string Address { get; set; } = string.Empty;
    
    public ReactiveCommand<Unit, RentalPointViewModel> OkButtonOnClick { get; }

    public RentalPointViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
}