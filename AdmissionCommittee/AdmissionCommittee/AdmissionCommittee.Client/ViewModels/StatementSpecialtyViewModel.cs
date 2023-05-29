using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;

/// <summary>
/// ViewModel of StatementSpecialty
/// </summary>
public class StatementSpecialtyViewModel : ViewModelBase
{
    private int _idStatementSpecialty;

    /// <summary>
    /// Id of StatementSpecialty
    /// </summary>
    public int IdStatementSpecialty
    {
        get => _idStatementSpecialty;
        set => this.RaiseAndSetIfChanged(ref _idStatementSpecialty, value);
    }

    private int _statementId;

    /// <summary>
    /// Id of Statement
    /// </summary>
    public int StatementId
    {
        get => _statementId;
        set => this.RaiseAndSetIfChanged(ref _statementId, value);
    }

    private int _specialtyId;

    /// <summary>
    /// Id of Specialty
    /// </summary>
    public int SpecialtyId
    {
        get => _specialtyId;
        set => this.RaiseAndSetIfChanged(ref _specialtyId, value);
    }

    private int _priority;

    /// <summary>
    /// Specialty priority
    /// </summary>
    [Required]
    public int Priority
    {
        get => _priority;
        set => this.RaiseAndSetIfChanged(ref _priority, value);
    }

    private IObservable<bool> CanSubmit { get; }

    /// <summary>
    /// Command binding for button submit
    /// </summary>
    public ReactiveCommand<Unit, StatementSpecialtyViewModel> OnSubmitCommand { get; set; }

    public StatementSpecialtyViewModel()
    {
        CanSubmit = this.WhenAnyValue(vm => vm.Priority, (priority) => priority == 1 | priority == 2 | priority == 3);
        OnSubmitCommand = ReactiveCommand.Create(() => this, CanSubmit);
    }
}