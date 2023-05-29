using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using TaxiDepo.Client.ViewModels;

namespace TaxiDepo.Client.ViewModels;

public class UserViewModel : ViewModelBase
{
    [Required] public int Id { get; set; }

    [Required] public string UserSurname { get; set; } = string.Empty;

    [Required] public string UserName { get; set; } = string.Empty;

    [Required] public string UserPatronymic { get; set; } = string.Empty;

    [Required] public string UserPhoneNumber { get; set; } = string.Empty;

    [Required] public DateTime UserDate { get; set; }

    public ReactiveCommand<Unit, UserViewModel> OnSubmitCommand { get; set; }

    public UserViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
