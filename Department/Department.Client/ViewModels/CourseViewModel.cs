using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Department.Client.ViewModels;
public class CourseViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private string _subjectName = string.Empty;
    [Required]
    public string SubjectName
    {
        set => this.RaiseAndSetIfChanged(ref _subjectName, value);
        get => _subjectName;
    }

    private int _subjectId;
    [Required]
    public int SubjectId
    {
        set => this.RaiseAndSetIfChanged(ref _subjectId, value);
        get => _subjectId;
    }

    private string _courseType = string.Empty;
    [Required]
    public string CourseType
    {
        set => this.RaiseAndSetIfChanged(ref _courseType, value);
        get => _courseType;
    }

    private int _semesterHours;
    [Required]
    public int SemesterHours
    {
        set => this.RaiseAndSetIfChanged(ref _semesterHours, value);
        get => _semesterHours;
    }

    private int _groupId;
    [Required]
    public int GroupId
    {
        set => this.RaiseAndSetIfChanged(ref _groupId, value);
        get => _groupId;
    }

    private string _teachersName = string.Empty;
    [Required]
    public string TeachersName
    {
        set => this.RaiseAndSetIfChanged(ref _teachersName, value);
        get => _teachersName;
    }

    private int _teacherId;
    [Required]
    public int TeacherId
    {
        set => this.RaiseAndSetIfChanged(ref _teacherId, value);
        get => _teacherId;
    }

    public ReactiveCommand<Unit, CourseViewModel> OnSubmitCommand { get; }

    public CourseViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
