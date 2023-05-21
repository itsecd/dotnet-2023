using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Factory.Client.ViewModels;
public class EnterpriseViewModel : ViewModelBase
{
    private int _id;
    public int EnterpriseID
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _registration = string.Empty;
    public string RegistrationNumber
    {
        get => _registration;
        set => this.RaiseAndSetIfChanged(ref _registration, value);
    }

    private int _typeid;
    public int TypeID
    {
        get => _typeid;
        set => this.RaiseAndSetIfChanged(ref _typeid, value);
    }

    private string _name = string.Empty;
    [Required]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private string _address = string.Empty;
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    private string _telephoneNumber = string.Empty;
    public string TelephoneNumber
    {
        get => _telephoneNumber;
        set => this.RaiseAndSetIfChanged(ref _telephoneNumber, value);
    }

    private int _ownershipFormID;
    public int OwnershipFormID
    {
        get => _ownershipFormID;
        set => this.RaiseAndSetIfChanged(ref _ownershipFormID, value);
    }

    private int _employeesCount;
    public int EmployeesCount
    {
        get => _employeesCount;
        set => this.RaiseAndSetIfChanged(ref _employeesCount, value);
    }

    private double _totalArea;
    public double TotalArea
    {
        get => _totalArea;
        set => this.RaiseAndSetIfChanged(ref _totalArea, value);
    }

    public ReactiveCommand<Unit, EnterpriseViewModel> OnSubmitCommand { get; }
    public EnterpriseViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
