using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Library.Client.ViewModels;
public class ReaderViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private string _fullName = string.Empty;
    [Required]
    public string FullName
    {
        set => this.RaiseAndSetIfChanged(ref _fullName, value);
        get => _fullName;
    }

    private string _address = string.Empty;
    [Required]
    public string Address
    {
        set => this.RaiseAndSetIfChanged(ref _address, value);
        get => _address;
    }

    private string _phone = string.Empty;
    [Required]
    public string Phone
    {
        set => this.RaiseAndSetIfChanged(ref _phone, value);
        get => _phone;
    }

    private string? _registrationDate;
    [Required]
    public string? RegistrationDate
    {
        set => this.RaiseAndSetIfChanged(ref _registrationDate, value);
        get => _registrationDate;
    }

    public ReactiveCommand<Unit, ReaderViewModel> OnSubmitCommand { get; set; }

    public ReaderViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
