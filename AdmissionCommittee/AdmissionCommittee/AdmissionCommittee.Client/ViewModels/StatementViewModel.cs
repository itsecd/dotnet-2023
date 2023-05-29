using ReactiveUI;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;
public class StatementViewModel : ViewModelBase
{
    private int _idStatement;
    public int IdStatement
    {
        get => _idStatement;
        set => this.RaiseAndSetIfChanged(ref _idStatement, value);
    }

    private int _entrantId;
    public int EntrantId
    {
        get => _entrantId;
        set => this.RaiseAndSetIfChanged(ref _entrantId, value);
    }

    public ReactiveCommand<Unit, StatementViewModel> OnSubmitCommand { get; set; }

    public StatementViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}