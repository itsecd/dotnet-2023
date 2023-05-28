using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Organization.Client.ViewModels;
public class EmployeeVacationVoucherViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private int _vacationVoucherId;
    [Required]
    public int VacationVoucherId
    {
        get => _vacationVoucherId;
        set => this.RaiseAndSetIfChanged(ref _vacationVoucherId, value);
    }

    private int _employeeId;
    [Required]
    public int EmployeeId
    {
        get => _employeeId;
        set => this.RaiseAndSetIfChanged(ref _employeeId, value);
    }

    public ReactiveCommand<Unit, EmployeeVacationVoucherViewModel> OnSubmitCommand { get; }

    public EmployeeVacationVoucherViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
