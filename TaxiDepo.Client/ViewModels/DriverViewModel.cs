using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TaxiDepo.Client.ViewModels;

public class DriverViewModel : ViewModelBase
{
    [Required] public int Id { get; set; }

    [Required] public string DriverSurname { get; set; } = string.Empty;

    [Required] public string DriverName { get; set; } = string.Empty;

    [Required] public string DriverPatronymic { get; set; } = string.Empty;

    [Required] public string DriverAddress { get; set; } = string.Empty;

    [Required] public string DriverPhoneNumber { get; set; } = string.Empty;

    [Required] public int AmountRides { get; set; } = 0;

    [Required] public int DriverPassportId { get; set; } = 0;

    public ReactiveCommand<Unit, DriverViewModel> OnSubmitCommand { get; set; }

    public DriverViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}