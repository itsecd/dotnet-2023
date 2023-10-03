using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Company.Client.ViewModels;

public class WorkersAndDepartmentsViewModel : ViewModelBase
{
    private int _id;
    private int _workerId = 1;
    private int _departmentId = 1;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    [Required]
    public int WorkerId
    {
        get => _workerId;
        set => this.RaiseAndSetIfChanged(ref _workerId, value);
    }

    [Required]
    public int DepartmentId
    {
        get => _departmentId;
        set => this.RaiseAndSetIfChanged(ref _departmentId, value);
    }

    public ReactiveCommand<Unit, WorkersAndDepartmentsViewModel> OnSubmitCommand { get; }

    public WorkersAndDepartmentsViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}