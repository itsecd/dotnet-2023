using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Organization.Client.ViewModels;
public class DepartmentEmployeeViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private int _departmentId;
    [Required]
    public int DepartmentId
    {
        get => _departmentId;
        set => this.RaiseAndSetIfChanged(ref _departmentId, value);
    }

    private int _employeeId;
    [Required]
    public int EmployeeId
    {
        get => _employeeId;
        set => this.RaiseAndSetIfChanged(ref _employeeId, value);
    }

    public ReactiveCommand<Unit, DepartmentEmployeeViewModel> OnSubmitCommand { get; }

    public DepartmentEmployeeViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
