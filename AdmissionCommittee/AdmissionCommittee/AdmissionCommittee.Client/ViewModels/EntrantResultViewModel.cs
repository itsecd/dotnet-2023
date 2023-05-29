using ReactiveUI;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;
public class EntrantResultViewModel : ViewModelBase
{
    private int _idEntrantResult;
    public int IdEntrantResult
    {
        get => _idEntrantResult;
        set => this.RaiseAndSetIfChanged(ref _idEntrantResult, value);
    }

    private int _entrantId;

    public int EntrantId
    {
        get => _entrantId;
        set => this.RaiseAndSetIfChanged(ref _entrantId, value);
    }


    private int _resultId;

    public int ResultId
    {
        get => _resultId;
        set => this.RaiseAndSetIfChanged(ref _resultId, value);
    }


    private int _mark;

    public int Mark
    {
        get => _mark;
        set => this.RaiseAndSetIfChanged(ref _mark, value);
    }

    public ReactiveCommand<Unit, EntrantResultViewModel> OnSubmitCommand { get; set; }

    public EntrantResultViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}