using System;
using System.Reactive;
using ReactiveUI;

namespace SelectionCommittee.Client.ViewModels;

public class EnrolleeViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _firstName = string.Empty;

    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }

    private string _lastName = string.Empty;

    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }

    private string _patronymic = string.Empty;

    public string Patronymic
    {
        get => _patronymic;
        set => this.RaiseAndSetIfChanged(ref _patronymic, value);
    }

    private int _age;

    public int Age
    {
        get => _age;
        set => this.RaiseAndSetIfChanged(ref _age, value);
    }

    private DateTime _birthDate;

    public DateTime BirthDate
    {
        get => _birthDate;
        set => this.RaiseAndSetIfChanged(ref _birthDate, value);
    }

    private string _country = string.Empty;

    public string Country
    {
        get => _country;
        set => this.RaiseAndSetIfChanged(ref _country, value);
    }

    private string _city = string.Empty;

    public string City
    {
        get => _city;
        set => this.RaiseAndSetIfChanged(ref _city, value);
    }

    private int _specializationId;

    public int SpecializationId
    {
        get => _specializationId;
        set => this.RaiseAndSetIfChanged(ref _specializationId, value);
    }

    public ReactiveCommand<Unit, EnrolleeViewModel> OnSubmitCommand { get; set; }

    public EnrolleeViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
