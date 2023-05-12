using ReactiveUI;
using System.Reactive;

namespace TaxiDepo.Client.ViewModels;

public class DriverViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _driverSurname = string.Empty;

    public string DriverSurname
    {
        get => _driverSurname;
        set => this.RaiseAndSetIfChanged(ref _driverSurname, value);
    }

    private string _driverName = string.Empty;

    public string DriverName
    {
        get => _driverName;
        set => this.RaiseAndSetIfChanged(ref _driverName, value);
    }

    private string _driverPatronymic = string.Empty;

    public string DriverPatronymic
    {
        get => _driverPatronymic;
        set => this.RaiseAndSetIfChanged(ref _driverPatronymic, value);
    }

    private string _driverAddress = string.Empty;

    public string DriverAddress
    {
        get => _driverAddress;
        set => this.RaiseAndSetIfChanged(ref _driverAddress, value);
    }

    private string _driverPhoneNumber;

    public string DriverPhoneNumber
    {
        get => _driverPhoneNumber;
        set => this.RaiseAndSetIfChanged(ref _driverPhoneNumber, value);
    }

    private int _driverPassportId;

    public int DriverPassportId
    {
        get => _driverPassportId;
        set => this.RaiseAndSetIfChanged(ref _driverPassportId, value);
    }

    public ReactiveCommand<Unit, DriverViewModel> OnSubmitCommand { get; set; }

    public DriverViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}