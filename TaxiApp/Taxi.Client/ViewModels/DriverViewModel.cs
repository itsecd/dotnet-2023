using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;

namespace Taxi.Client.ViewModels;

public class DriverViewModel: ViewModelBase
{
    private ulong _id;
    
    public ulong Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _firstName = string.Empty;

    [Required]
    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }
    
    // public string LastName { get; set; } 
    //
    // public string? Patronymic { get; set; }
    //
    // public string Passport { get; set; }
    //
    // public string PhoneNumber { get; set; }
    
    public ReactiveCommand<Unit, DriverViewModel> OnSubmitCommand { get; }

    public DriverViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}