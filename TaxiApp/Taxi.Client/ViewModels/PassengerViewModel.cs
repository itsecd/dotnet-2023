using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Taxi.Client.ViewModels;

public class PassengerViewModel: ViewModelBase
{
    [Reactive] 
    public ulong Id { get; set; }
    
    [Required] 
    [Reactive] 
    public string FirstName { get; set; } = string.Empty;
    
    [Required] 
    [Reactive] 
    public string LastName { get; set; } = string.Empty;
    
    [Reactive] 
    public string? Patronymic { get; set; }
    
    [Required] 
    [Reactive] 
    public string PhoneNumber { get; set; } = string.Empty;
    
    
    public ReactiveCommand<Unit, PassengerViewModel> OnSubmitCommand { get; }

    public PassengerViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}