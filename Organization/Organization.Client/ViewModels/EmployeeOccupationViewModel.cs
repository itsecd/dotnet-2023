using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Organization.Client.ViewModels;
public class EmployeeOccupationViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private int _occupationId;
    [Required]
    public int OccupationId
    {
        get => _occupationId;
        set => this.RaiseAndSetIfChanged(ref _occupationId, value);
    }

    private int _employeeId;
    [Required]
    public int EmployeeId
    {
        get => _employeeId;
        set => this.RaiseAndSetIfChanged(ref _employeeId, value);
    }
    public DateTimeOffset? _hireDate;
    [Required]
    public DateTimeOffset? HireDate
    {
        get => _hireDate;
        set => this.RaiseAndSetIfChanged(ref _hireDate, value);
    }
    public DateTimeOffset? _dismissalDate;
    public DateTimeOffset? DismissalDate
    {
        get => _dismissalDate;
        set => this.RaiseAndSetIfChanged(ref _dismissalDate, value);
    }

    public ReactiveCommand<Unit, EmployeeOccupationViewModel> OnSubmitCommand { get; }

    public EmployeeOccupationViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
