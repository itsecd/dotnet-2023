using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;

namespace RecruitmentAgency.Client.ViewModels;
public class CompanyApplicationViewModel : ViewModelBase
{
    private DateTime _date = DateTime.Now;
    public DateTime Date {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }
    private int _workExperience = 0;
    public int WorkExperience {
        get => _workExperience;
        set => this.RaiseAndSetIfChanged(ref _workExperience, value);
    }
    private int _salary = 0;
    public int Salary { 
        get => _salary;
        set => this.RaiseAndSetIfChanged(ref _salary, value);
    }
    private string _education = "None";
    public string Education {
        get => _education;
        set => this.RaiseAndSetIfChanged(ref _education, value);
    }
    private int _id;
    public int Id {
        get => _id;
        set =>this.RaiseAndSetIfChanged(ref _id, value);
    }
    private int _companyId;
    public int CompanyId {
        get => _companyId;
        set => this.RaiseAndSetIfChanged(ref _companyId, value);
    }
    private int _titleId;
    public int TitleId {
        get => _titleId;
        set => this.RaiseAndSetIfChanged(ref _titleId, value);
    }
    public ReactiveCommand<Unit, CompanyApplicationViewModel> OnSubmitCommand { get; }
    public CompanyApplicationViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
