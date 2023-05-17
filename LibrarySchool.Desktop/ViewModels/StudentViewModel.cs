using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace LibrarySchool.Desktop.ViewModels;

/// <summary>
/// ViewModel of class Student
/// </summary>
public class StudentViewModel: ViewModelBase
{
    private int _studentId;
    /// <summary>
    /// Id student
    /// </summary>
    public int StudentId
    {
        get => _studentId;
        set => this.RaiseAndSetIfChanged(ref _studentId, value);    
    }
    private string _studentName = "";
    /// <summary>
    /// Name of student
    /// </summary>
    [Required]
    public string StudentName
    {
        get => _studentName;
        set => this.RaiseAndSetIfChanged(ref _studentName, value);
    }
    private string _passport = "";

    /// <summary>
    /// Passport of student
    /// </summary>
    [Required]
    public string Passport
    {
        get => _passport;
        set => this.RaiseAndSetIfChanged(ref _passport, value);
    }
    private DateTimeOffset? _dateOfBirth;
    /// <summary>
    /// Birth day of student
    /// </summary>
    public DateTimeOffset? DateOfBirth
    {
        get => _dateOfBirth;
        set => this.RaiseAndSetIfChanged(ref _dateOfBirth, value);  
    }
    private int _classId;
    /// <summary>
    /// Id of class where student is studying
    /// </summary>
    public int ClassId
    {
        get => _classId;
        set => this.RaiseAndSetIfChanged(ref _classId, value);
    }

    private IObservable<bool> CanSubmit { get; }

    /// <summary>
    /// Command binding for button submit
    /// </summary>
    public ReactiveCommand<Unit, StudentViewModel> OnSubmitCommand { get; set; }

    /// <summary>
    /// Constructor of class StudentViewModel
    /// </summary>
    public StudentViewModel()
    {
        CanSubmit = this.WhenAnyValue(
            x => x.StudentName,
            x => x.Passport,
            x=> x.DateOfBirth,
            (name, passport, dateOfBirth) => !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(passport) && dateOfBirth != null
        );
        OnSubmitCommand = ReactiveCommand.Create(() => this, CanSubmit);
    }
}
