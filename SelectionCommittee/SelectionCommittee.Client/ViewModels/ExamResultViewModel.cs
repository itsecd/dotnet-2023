using ReactiveUI;
using System.Reactive;

namespace SelectionCommittee.Client.ViewModels;

public class ExamResultViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _subjectName = string.Empty;

    public string SubjectName
    {
        get => _subjectName;
        set => this.RaiseAndSetIfChanged(ref _subjectName, value);
    }

    private int _points;

    public int Points
    {
        get => _points;
        set => this.RaiseAndSetIfChanged(ref _points, value);
    }

    private int _enrolleeId;

    public int EnrolleeId
    {
        get => _enrolleeId;
        set => this.RaiseAndSetIfChanged(ref _enrolleeId, value);
    }

    public ReactiveCommand<Unit, ExamResultViewModel> OnSubmitCommand { get; set; }

    public ExamResultViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
