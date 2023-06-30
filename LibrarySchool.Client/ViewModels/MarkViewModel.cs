using ReactiveUI;
using System;
using System.Reactive;

namespace LibrarySchool.Client.ViewModels;

/// <summary>
/// ViewModel of class Mark
/// </summary>
public class MarkViewModel : ViewModelBase
{
    private int _markId;

    /// <summary>
    /// Id mark
    /// </summary>
    public int MarkId
    {
        get => _markId;
        set => this.RaiseAndSetIfChanged(ref _markId, value);
    }

    private int _subjectId;
    /// <summary>
    /// Id subject
    /// </summary>
    public int SubjectId
    {
        get => _subjectId;
        set => this.RaiseAndSetIfChanged(ref _subjectId, value);
    }

    private int _studentId;

    /// <summary>
    /// Id student 
    /// </summary>
    public int StudentId
    {
        get => _studentId;
        set => this.RaiseAndSetIfChanged(ref _studentId, value);
    }

    private int _markValue;

    /// <summary>
    /// Value of mark
    /// </summary>
    public int MarkValue
    {
        get => _markValue;
        set => this.RaiseAndSetIfChanged(ref _markValue, value);
    }

    private DateTimeOffset _timeReceive;

    /// <summary>
    /// Time receive mark
    /// </summary>
    public DateTimeOffset TimeReceive
    {
        get => _timeReceive;
        set => this.RaiseAndSetIfChanged(ref _timeReceive, value);
    }

    /// <summary>
    /// Command binding for button Submit
    /// </summary>
    public ReactiveCommand<Unit, MarkViewModel> OnSubmitCommand { get; }

    /// <summary>
    /// Comstructor of class MarkViewModel
    /// </summary>
    public MarkViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
