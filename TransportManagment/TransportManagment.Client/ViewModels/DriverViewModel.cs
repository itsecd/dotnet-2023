using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TransportManagment.Client.ViewModels;
public class DriverViewModel : ViewModelBase
{
    private int _driverId;
    [Required]
    public int DriverId 
    { 
        get => _driverId;
        set => this.RaiseAndSetIfChanged(ref _driverId, value);
    }
    private string _firstName = string.Empty;
    [Required]
    public string FirstName 
    { 
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }
    private string _lastName = string.Empty;
    [Required]
    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }
    private string _patronymic = string.Empty;
    [Required]
    public string Patronymic 
    { 
        get => _patronymic; 
        set=> this.RaiseAndSetIfChanged(ref _patronymic, value); 
    }
    private int _passport;
    [Required]
    public int Passport 
    {
        get => _passport;
        set => this.RaiseAndSetIfChanged(ref _passport, value);
    }
    private int _driverCard;
    [Required]
    public int DriverCard 
    { 
        get => _driverCard;
        set => this.RaiseAndSetIfChanged(ref _driverCard, value);
    }
    private int _number;
    [Required]
    public int Number 
    {
        get => _number;
        set=> this.RaiseAndSetIfChanged(ref _number, value);
    }
    public ReactiveCommand<Unit, DriverViewModel> OnSubmitCommand { get; }
    public DriverViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
