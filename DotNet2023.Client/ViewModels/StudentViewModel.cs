using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace DotNet2023.Client.ViewModels;
public class StudentViewModel : ViewModelBase
{
    public StudentViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
    public ReactiveCommand<Unit, StudentViewModel> OkButtonOnClick { get; }
    private string _id;
    public string Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _name = "Defaul Name";
    public string? Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    private string _surname = "Default Surname";
    public string? Surname
    {
        get => _surname;
        set => this.RaiseAndSetIfChanged(ref _surname, value);
    }

    private string _patronymic = "Default Patronymic";
    public string? Patronymic
    {
        get => _patronymic;
        set => this.RaiseAndSetIfChanged(ref _patronymic, value);
    }

    private DateTime? _birthDay;
    public DateTime? BirthDay
    {
        get => _birthDay;
        set => this.RaiseAndSetIfChanged(ref _birthDay, value);
    }

    private string _phone = "0123456789";
    [RegularExpression(@"[0-9]{10}")]
    public string? Phone
    {
        get => _phone;
        set => this.RaiseAndSetIfChanged(ref _phone, value);
    }

    private string _email = "email@mail.com";
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    public string? Email
    {
        get => _email;
        set => this.RaiseAndSetIfChanged(ref _email, value);
    }

    private string? _idGroup;
    public string? IdGroup
    {
        get => _idGroup;
        set => this.RaiseAndSetIfChanged(ref _idGroup, value);
    }

    private string? _idSpeciality;
    public string? IdSpeciality
    {
        get => _idSpeciality;
        set => this.RaiseAndSetIfChanged(ref _idSpeciality, value);
    }
}
