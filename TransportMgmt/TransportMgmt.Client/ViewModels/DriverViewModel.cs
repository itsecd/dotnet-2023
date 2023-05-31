using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TransportMgmt.Client.ViewModels;

public class DriverViewModel : ViewModelBase
{
    private int _id;

    public int Id
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

    private string _lastName = string.Empty;
    [Required]
    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }

    private string _middleName = string.Empty;
    [Required]
    public string MiddleName
    {
        get => _middleName;
        set => this.RaiseAndSetIfChanged(ref _middleName, value);
    }

    private int _passport;
    [Required]
    public int Passport
    {
        get => _passport;
        set => this.RaiseAndSetIfChanged(ref _passport, value);
    }

    private int _driverLicense;
    [Required]
    public int DriverLicense
    {
        get => _driverLicense;
        set => this.RaiseAndSetIfChanged(ref _driverLicense, value);
    }

    private string _address = string.Empty;
    [Required]
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    private string _phoneNumber = string.Empty;
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => this.RaiseAndSetIfChanged(ref _phoneNumber, value);
    }

    public ReactiveCommand<Unit, DriverViewModel> DriverOnSubmitCommand { get; }

    public DriverViewModel()
    {
        DriverOnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
