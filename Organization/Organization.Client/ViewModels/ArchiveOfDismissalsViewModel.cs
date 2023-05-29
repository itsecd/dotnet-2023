using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Organization.Client.ViewModels;
public class ArchiveOfDismissalsViewModel : ViewModelBase
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
    public DateTimeOffset? _birthDate;
    [Required]
    public DateTimeOffset? BirthDate
    {
        get => _birthDate;
        set => this.RaiseAndSetIfChanged(ref _birthDate, value);
    }
    private string _workshopName;
    [Required]
    public string WorkshopName
    {
        get => _workshopName;
        set => this.RaiseAndSetIfChanged(ref _workshopName, value);
    }

    private string _departmentName;
    [Required]
    public string DepartmentName
    {
        get => _departmentName;
        set => this.RaiseAndSetIfChanged(ref _departmentName, value);
    }

    private string _occupationName;
    [Required]
    public string OccupationName
    {
        get => _occupationName;
        set => this.RaiseAndSetIfChanged(ref _occupationName, value);
    }


    public ArchiveOfDismissalsViewModel()
    {
    }
}