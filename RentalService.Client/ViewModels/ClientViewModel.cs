using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace RentalService.Client.ViewModels;

public class ClientViewModel : ViewModelBase
{
    [Required] [Reactive] public long Id { get; set; }
    
    [Required] [Reactive] public string LastName { get; set; } = String.Empty;
    
    [Required] [Reactive] public string FirstName { get; set; } = String.Empty;
    
    [Required] [Reactive] public string Patronymic { get; set; } = String.Empty;

    [Reactive] public DateTimeOffset? BirthDate { get; set; } = DateTime.Today;

    [Required] [Reactive] public string Passport { get; set; } = String.Empty;

    public ReactiveCommand<Unit, ClientViewModel> OkButtonOnClick { get; }

    public ClientViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
    
}