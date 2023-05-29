using ReactiveUI;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;

/// <summary>
/// ViewModel of Statement
/// </summary>
public class StatementViewModel : ViewModelBase
{
    private int _idStatement;

    /// <summary>
    /// Id of Statement
    /// </summary>
    public int IdStatement
    {
        get => _idStatement;
        set => this.RaiseAndSetIfChanged(ref _idStatement, value);
    }

    private int _entrantId;

    /// <summary>
    /// Id of Entrant
    /// </summary>
    public int EntrantId
    {
        get => _entrantId;
        set => this.RaiseAndSetIfChanged(ref _entrantId, value);
    }

    /// <summary>
    /// Command binding for button submit
    /// </summary>
    public ReactiveCommand<Unit, StatementViewModel> OnSubmitCommand { get; set; }

    public StatementViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}