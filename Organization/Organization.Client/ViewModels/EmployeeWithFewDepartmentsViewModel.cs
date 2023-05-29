using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Organization.Client.ViewModels;
public class EmployeeWithFewDepartmentsViewModel : ViewModelBase
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
    private string _patronymicName;
    [Required]
    public string PatronymicName
    {
        get => _patronymicName;
        set => this.RaiseAndSetIfChanged(ref _patronymicName, value);
    }
    private uint _countDepart;
    [Required]
    public uint CountDepart
    {
        get => _countDepart;
        set => this.RaiseAndSetIfChanged(ref _countDepart, value);
    }

    public EmployeeWithFewDepartmentsViewModel()
    {
    }
}