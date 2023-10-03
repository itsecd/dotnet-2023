using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Company.Client.ViewModels;

public class WorkersAndJobsViewModel : ViewModelBase
{
    private int _id;
    private DateTimeOffset _hireDate = DateTimeOffset.Now;
    private DateTimeOffset _dismissalDate = DateTimeOffset.MaxValue;
    private int _workerId = 1;
    private int _jobId = 1;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    [Required]
    public DateTimeOffset HireDate
    {
        get => _hireDate;
        set => this.RaiseAndSetIfChanged(ref _hireDate, value);
    }

    [Required]
    public DateTimeOffset DismissalDate
    {
        get => _dismissalDate;
        set => this.RaiseAndSetIfChanged(ref _dismissalDate, value);
    }

    [Required]
    public int WorkerId
    {
        get => _workerId;
        set => this.RaiseAndSetIfChanged(ref _workerId, value);
    }

    [Required]
    public int JobId
    {
        get => _jobId;
        set => this.RaiseAndSetIfChanged(ref _jobId, value);
    }

    public ReactiveCommand<Unit, WorkersAndJobsViewModel> OnSubmitCommand { get; }

    public WorkersAndJobsViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}