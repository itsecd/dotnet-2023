using ReactiveUI;
using System;
using System.Reactive;

namespace RecruitmentAgency.Client.ViewModels;
public class JobApplicationViewModel : ViewModelBase
{
    private int _employeeId;
    public int EmployeeId
    {
        get => _employeeId;
        set => this.RaiseAndSetIfChanged(ref _employeeId, value);
    }
    private DateTime _date = DateTime.Now;
    public DateTime Date
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }
    private int _titleId;
    public int TitleId
    {
        get => _titleId;
        set => this.RaiseAndSetIfChanged(ref _titleId, value);
    }
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    public ReactiveCommand<Unit, JobApplicationViewModel> OnSubmitCommand { get; }
    public JobApplicationViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
