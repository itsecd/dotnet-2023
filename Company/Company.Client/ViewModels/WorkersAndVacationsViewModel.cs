using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Company.Client.ViewModels;

public class WorkersAndVacationsViewModel : ViewModelBase
{
    private int _id;
    private int _workerId = 1;
    private int _vacationId = 1;

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
    public int VacationId
    {
        get => _vacationId;
        set => this.RaiseAndSetIfChanged(ref _vacationId, value);
    }

    public ReactiveCommand<Unit, WorkersAndVacationsViewModel> OnSubmitCommand { get; }

    public WorkersAndVacationsViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}