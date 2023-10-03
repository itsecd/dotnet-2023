using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Company.Client.ViewModels;

public class WorkerViewModel : ViewModelBase
{
    private int _id;
    private int _registrationNumber = 1000;
    private string _lastName = string.Empty;
    private string _firstName = string.Empty;
    private string _patronymic = string.Empty;
    private DateTimeOffset _birthDate = DateTimeOffset.Now;
    private string _sex = string.Empty;
    private int _workshopId = 1;
    private string _homeAddress = string.Empty;
    private string _homeTelephone = string.Empty;
    private string _workTelephone = string.Empty;
    private string _maritalStatus = string.Empty;
    private int _peopleInFamily = 1;
    private int _childrenInFamily = 0;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    [Required]
    public int RegistrationNumber
    {
        get => _registrationNumber;
        set => this.RaiseAndSetIfChanged(ref _registrationNumber, value);
    }

    [Required]
    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }

    [Required]
    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }

    [Required]
    public string Patronymic
    {
        get => _patronymic;
        set => this.RaiseAndSetIfChanged(ref _patronymic, value);
    }

    [Required]
    public DateTimeOffset BirthDate
    {
        get => _birthDate;
        set => this.RaiseAndSetIfChanged(ref _birthDate, value);
    }

    [Required]
    public string Sex
    {
        get => _sex;
        set => this.RaiseAndSetIfChanged(ref _sex, value);
    }

    [Required]
    public int WorkshopId
    {
        get => _workshopId;
        set => this.RaiseAndSetIfChanged(ref _workshopId, value);
    }

    [Required]
    public string HomeAddress
    {
        get => _homeAddress;
        set => this.RaiseAndSetIfChanged(ref _homeAddress, value);
    }

    [Required]
    public string HomeTelephone
    {
        get => _homeTelephone;
        set => this.RaiseAndSetIfChanged(ref _homeTelephone, value);
    }

    [Required]
    public string WorkTelephone
    {
        get => _workTelephone;
        set => this.RaiseAndSetIfChanged(ref _workTelephone, value);
    }

    [Required]
    public string MaritalStatus
    {
        get => _maritalStatus;
        set => this.RaiseAndSetIfChanged(ref _maritalStatus, value);
    }

    [Required]
    public int PeopleInFamily
    {
        get => _peopleInFamily;
        set => this.RaiseAndSetIfChanged(ref _peopleInFamily, value);
    }

    [Required]
    public int ChildrenInFamily
    {
        get => _childrenInFamily;
        set => this.RaiseAndSetIfChanged(ref _childrenInFamily, value);
    }

    public ReactiveCommand<Unit, WorkerViewModel> OnSubmitCommand { get; }

    public WorkerViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}


