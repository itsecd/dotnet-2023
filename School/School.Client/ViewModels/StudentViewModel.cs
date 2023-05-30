using ReactiveUI;
using System;
using System.Reactive;

namespace School.Client.ViewModels;

public class StudentViewModel : ViewModelBase
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

    private string _passport = string.Empty;

    public string Passport
    {
        get => _passport;
        set => this.RaiseAndSetIfChanged(ref _passport, value);
    }

    private int _classId;

    public int ClassId
    {
        get => _classId;
        set => this.RaiseAndSetIfChanged(ref _classId, value);
    }

    private DateTimeOffset _birthDate;

    public DateTimeOffset BirthDate
    {
        get => _birthDate;
        set => this.RaiseAndSetIfChanged(ref _birthDate, value);
    }

    public ReactiveCommand<Unit, StudentViewModel> OnSubmitCommand { get; set; }

    public StudentViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}