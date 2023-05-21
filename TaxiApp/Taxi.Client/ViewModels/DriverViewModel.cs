using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Taxi.Client.ViewModels;

public class DriverViewModel : ViewModelBase
{
    public DriverViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }

    [Reactive] public ulong Id { get; set; }

    [Required] [Reactive] public string FirstName { get; set; } = string.Empty;

    [Required] [Reactive] public string LastName { get; set; } = string.Empty;

    [Reactive] public string? Patronymic { get; set; } = string.Empty;

    [Required] [Reactive] public string Passport { get; set; } = string.Empty;

    [Required] [Reactive] public string PhoneNumber { get; set; } = string.Empty;

    public ReactiveCommand<Unit, DriverViewModel> OnSubmitCommand { get; }
}