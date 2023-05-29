using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Organization.Client.ViewModels;
public class EmployeeViewModel : ViewModelBase
{
    private uint _id;
    public uint Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private uint _regNumber;
    [Required]
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
    private uint _workshopId;
    [Required]
    public uint WorkshopId
    {
        get => _workshopId;
        set => this.RaiseAndSetIfChanged(ref _workshopId, value);
    }
    private WorkshopViewModel? _workshop;
    public WorkshopViewModel? Workshop
    {
        get => _workshop;
        set => this.RaiseAndSetIfChanged(ref _workshop, value);
    }

    private string _homeAddress;
    [Required]
    public string HomeAddress
    {
        get => _homeAddress;
        set => this.RaiseAndSetIfChanged(ref _homeAddress, value);
    }
    private string _homeTelephone;
    [Required]
    public string HomeTelephone
    {
        get => _homeTelephone;
        set => this.RaiseAndSetIfChanged(ref _homeTelephone, value);
    }
    private string _workTelephone;
    [Required]
    public string WorkTelephone
    {
        get => _workTelephone;
        set => this.RaiseAndSetIfChanged(ref _workTelephone, value);
    }
    private string _familyStatus;
    [Required]
    public string FamilyStatus
    {
        get => _familyStatus;
        set => this.RaiseAndSetIfChanged(ref _familyStatus, value);
    }
    private uint _familyMembersCount;
    [Required]
    public uint FamilyMembersCount
    {
        get => _familyMembersCount;
        set => this.RaiseAndSetIfChanged(ref _familyMembersCount, value);
    }
    private uint _childrenCount;
    [Required]
    public uint ChildrenCount
    {
        get => _childrenCount;
        set => this.RaiseAndSetIfChanged(ref _childrenCount, value);
    }

    public ReactiveCommand<Unit, EmployeeViewModel> OnSubmitCommand { get; }

    public EmployeeViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
