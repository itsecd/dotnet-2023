using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace DotNet2023.Client.ViewModels;
public class EducationWorkerViewModel : ViewModelBase
{

    public EducationWorkerViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
    public ReactiveCommand<Unit, EducationWorkerViewModel> OkButtonOnClick { get; }

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

    private string _scienceDegree = "Default ScienceDegree";
    public string? ScienceDegree
    {
        get => _scienceDegree;
        set => this.RaiseAndSetIfChanged(ref _scienceDegree, value);
    }

    private string _rank = "Default Rank";
    public string? Rank
    {
        get => _rank;
        set => this.RaiseAndSetIfChanged(ref _rank, value);
    }

    private string? _idOrganization;
    public string? IdOrganization
    {
        get => _idOrganization;
        set => this.RaiseAndSetIfChanged(ref _idOrganization, value);
    }

    private string _jobTitle = "Default Job Title";
    public string? JobTitle
    {
        get => _jobTitle;
        set => this.RaiseAndSetIfChanged(ref _jobTitle, value);
    }

    private double? _salary = 100500;
    public double? Salary
    {
        get => _salary;
        set => this.RaiseAndSetIfChanged(ref _salary, value);
    }

}
