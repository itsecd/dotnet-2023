using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;
public class StatementSpecialtyViewModel : ViewModelBase
{
    private int _idStatementSpecialty;
    public int IdStatementSpecialty
    {
        get => _idStatementSpecialty;
        set => this.RaiseAndSetIfChanged(ref _idStatementSpecialty, value);
    }

    private int _statementId;
    public int StatementId
    {
        get => _statementId;
        set => this.RaiseAndSetIfChanged(ref _statementId, value);
    }

    private int _specialtyId;
    public int SpecialtyId
    {
        get => _specialtyId;
        set => this.RaiseAndSetIfChanged(ref _specialtyId, value);
    }

    private int _priority;

    [Required]
    public int Priority
    {
        get => _priority;
        set => this.RaiseAndSetIfChanged(ref _priority, value);
    }

    private IObservable<bool> CanSubmit { get; }

    public ReactiveCommand<Unit, StatementSpecialtyViewModel> OnSubmitCommand { get; set; }

    public StatementSpecialtyViewModel()
    {
        CanSubmit = this.WhenAnyValue(vm => vm.Priority, (priority) => priority == 1 | priority == 2 | priority == 3);
        OnSubmitCommand = ReactiveCommand.Create(() => this, CanSubmit);
    }
}