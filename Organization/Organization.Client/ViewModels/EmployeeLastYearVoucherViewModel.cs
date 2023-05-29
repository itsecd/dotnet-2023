using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Organization.Client.ViewModels;
public class EmployeeLastYearVoucherViewModel : ViewModelBase
{
    private uint _regNumber;
    public uint RegNumber
    {
        get => _regNumber;
        set => this.RaiseAndSetIfChanged(ref _regNumber, value);
    }
    private string _firstName;
    [Required]
    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }
    private string _lastName;
    [Required]
    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }

    private string _voucherTypeName;
    [Required]
    public string VoucherTypeName
    {
        get => _voucherTypeName;
        set => this.RaiseAndSetIfChanged(ref _voucherTypeName, value);
    }


    public EmployeeLastYearVoucherViewModel()
    {
    }
}