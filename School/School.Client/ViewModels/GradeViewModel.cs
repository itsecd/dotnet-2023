using ReactiveUI;
using System;
using System.Reactive;

namespace School.Client.ViewModels;

public class GradeViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _subjectId;
    
    public int SubjectId
    {
        get => _subjectId;
        set => this.RaiseAndSetIfChanged(ref _subjectId, value);
    }

    private int _studentId;

    public int StudentId
    {
        get => _studentId;
        set => this.RaiseAndSetIfChanged(ref _studentId, value);
    }

    private int _mark;

    public int Mark
    {
        get => _mark;
        set => this.RaiseAndSetIfChanged(ref _mark, value);
    }

    private DateTimeOffset _date;

    public DateTimeOffset Date
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }


    public ReactiveCommand<Unit, GradeViewModel> OnSubmitCommand { get; set; }

    public GradeViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}