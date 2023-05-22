using ReactiveUI;
using System.Reactive;

namespace RecruitmentAgency.Client.ViewModels;
public class EmployeeViewModel : ViewModelBase
{
    private string _personalName;
    public string PersonalName
    {
        get => _personalName;
        set => this.RaiseAndSetIfChanged(ref _personalName, value);
    }
    private string _telephone;
    public string Telephone
    {
        get => _telephone;
        set => this.RaiseAndSetIfChanged(ref _telephone, value);
    }
    private int _workExperience;
    public int WorkExperience
    {
        get => _workExperience;
        set => this.RaiseAndSetIfChanged(ref _workExperience, value);
    }
    private string _education;
    public string Education
    {
        get => _education;
        set => this.RaiseAndSetIfChanged(ref _education, value);
    }
    private int _salary;
    public int Salary
    {
        get => _salary;
        set => this.RaiseAndSetIfChanged(ref _salary, value);
    }
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    public ReactiveCommand<Unit, EmployeeViewModel> OnSubmitCommand { get; }
    public EmployeeViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
