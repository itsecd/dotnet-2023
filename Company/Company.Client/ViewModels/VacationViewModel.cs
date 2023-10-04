using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Company.Client.ViewModels;

public class VacationViewModel : ViewModelBase
{
    private int _id;
    private int _vacationSpotId = 1;
    private DateTimeOffset _issueDate = DateTimeOffset.Now;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    [Required]
    public int VacationSpotId
    {
        get => _vacationSpotId;
        set => this.RaiseAndSetIfChanged(ref _vacationSpotId, value);
    }

    [Required]
    public DateTimeOffset IssueDate
    {
        get => _issueDate;
        set => this.RaiseAndSetIfChanged(ref _issueDate, value);
    }

    public ReactiveCommand<Unit, VacationViewModel> OnSubmitCommand { get; }

    public VacationViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}