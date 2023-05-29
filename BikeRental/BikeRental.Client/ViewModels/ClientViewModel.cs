using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace BikeRental.Client.ViewModels;
public class ClientViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _fullName = string.Empty;
    [Required]
    public string FullName
    {
        get => _fullName;
        set => this.RaiseAndSetIfChanged(ref this._fullName, value);
    }

    private int _birthYear;
    [Required]
    public int BirthYear
    {
        get => _birthYear;
        set => this.RaiseAndSetIfChanged(ref _birthYear, value);
    }

    private string _phoneNumber = string.Empty;
    [Required]
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => this.RaiseAndSetIfChanged(ref _phoneNumber, value);
    }

    public ReactiveCommand<Unit, ClientViewModel> OnSubmitCommand { get; }

    public ClientViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
