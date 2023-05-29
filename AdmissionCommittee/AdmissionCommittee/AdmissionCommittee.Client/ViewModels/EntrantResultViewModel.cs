using ReactiveUI;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;
/// <summary>
/// ViewModel of EntrantResult
/// </summary>
public class EntrantResultViewModel : ViewModelBase
{
    private int _idEntrantResult;

    /// <summary>
    /// Id of EntrantResult
    /// </summary>
    public int IdEntrantResult
    {
        get => _idEntrantResult;
        set => this.RaiseAndSetIfChanged(ref _idEntrantResult, value);
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


    private int _resultId;
    /// <summary>
    /// Id of Result
    /// </summary>
    public int ResultId
    {
        get => _resultId;
        set => this.RaiseAndSetIfChanged(ref _resultId, value);
    }


    private int _mark;
    /// <summary>
    /// Exam mark
    /// </summary>
    public int Mark
    {
        get => _mark;
        set => this.RaiseAndSetIfChanged(ref _mark, value);
    }

    /// <summary>
    /// Binding command for button Submit
    /// </summary>
    public ReactiveCommand<Unit, EntrantResultViewModel> OnSubmitCommand { get; set; }

    public EntrantResultViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}