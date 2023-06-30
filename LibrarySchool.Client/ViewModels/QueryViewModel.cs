using LibrarySchool.Desktop.Models;
using MessageBox.Avalonia.Enums;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace LibrarySchool.Desktop.ViewModels;

/// <summary>
/// ViewModel of window query
/// </summary>
public class QueryViewModel : ViewModelBase
{
    private readonly ClientApiWrapper _clientApiWrapper;

    /// <summary>
    /// List information student for query student in class
    /// </summary>
    public ObservableCollection<StudentInClassWithClassName> ListStudentInClass { get; } = new ();

    /// <summary>
    /// List information student for query top 5 student
    /// </summary>
    public ObservableCollection<StudentGetAverageDto> ListTopFiveStudent { get; } = new();

    /// <summary>
    /// List information student for query top 5 student in period
    /// </summary>
    public ObservableCollection<StudentGetAverageDto> ListTopFiveStudentInPeriod { get; } = new();

    /// <summary>
    /// List information all subject
    /// </summary>
    public ObservableCollection<SubjectGetDto> ListInformationAllSubject { get; } = new();

    /// <summary>
    /// List information mark for query max, min, average
    /// </summary>
    public ObservableCollection<MaxMinAverageWithSubjectName> ListMaxMinAverageMark { get; } = new();

    private bool _visibleAllSubject = false;
    /// <summary>
    /// Visible table all subject
    /// </summary>
    public bool VisibleAllSubject
    {
        get => _visibleAllSubject;
        set => this.RaiseAndSetIfChanged(ref _visibleAllSubject, value);
    } 

    private bool _visibleStudentInClass = false;
    /// <summary>
    /// Visible table all sutdent in class
    /// </summary>
    public bool VisibleStudentInClass
    {
        get => _visibleStudentInClass;
        set => this.RaiseAndSetIfChanged(ref _visibleStudentInClass, value);
    }

    private bool _visibleTopFiveStudent = false;
    /// <summary>
    /// Visible table top 5 student
    /// </summary>
    public bool VisibleTopFiveStudent
    {
        get => _visibleTopFiveStudent;
        set => this.RaiseAndSetIfChanged(ref _visibleTopFiveStudent, value);
    }

    private bool _visibleTopFiveStudentInPeriod = false;
    /// <summary>
    /// Visible top 5 student in period
    /// </summary>
    public bool VisibleTopFiveStudentInPeriod
    {
        get => _visibleTopFiveStudentInPeriod;
        set => this.RaiseAndSetIfChanged(ref _visibleTopFiveStudentInPeriod, value);
    }
    private bool _visibleMaxMinAverageMark = false;
    /// <summary>
    /// Visible table max, min, avg mark
    /// </summary>
    public bool VisibleMaxMinAverageMark
    {
        get => _visibleMaxMinAverageMark;
        set => this.RaiseAndSetIfChanged(ref _visibleMaxMinAverageMark, value);
    }

    /// <summary>
    /// Command binding for button query student in class
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnGetListStudentInClass { get; set; }

    /// <summary>
    /// Command binding for button query top 5 student
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnGetListTopFiveStudent { get; set; }

    /// <summary>
    /// Command binding for button query top 5 student in period
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnGetListTopFiveStudentInPeriod { get; set; }

    /// <summary>
    /// Command binding for button query get all subject
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnGetInformationAllSubject { get; set; }

    /// <summary>
    /// Command binding for button query get max, min, average by subject
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnGetMaxMinAverage { get; set; }

    /// <summary>
    /// Open window get class id dialog
    /// </summary>
    public Interaction<QueryClassTypeViewModel, QueryClassTypeViewModel?> ShowGetClassIdDialog { get; set; }

    /// <summary>
    /// Open window get period dialog
    /// </summary>
    public Interaction<TopFiveInPeriodViewModel, TopFiveInPeriodViewModel?> ShowTopFiveInPeriodDialog { get; set; }

    private TopFiveInPeriodViewModel? _lastSettedPeriod;
    /// <summary>
    /// Last setted period 
    /// </summary>
    public TopFiveInPeriodViewModel? LastSettedPeriod
    {
        get => _lastSettedPeriod;
        set => this.RaiseAndSetIfChanged(ref _lastSettedPeriod, value);
    }

    private async Task QueryGetStudentInClass()
    {
        ShowListStudentInClass();
        ListStudentInClass.Clear();
        var queryClassTypeViewModel = await ShowGetClassIdDialog.Handle(new QueryClassTypeViewModel());
        if (queryClassTypeViewModel == null)
            return;
        var classId = queryClassTypeViewModel.ClassId;

        try
        {
            var gotListStudentInClass = await _clientApiWrapper.GetAllStudentsInClassAsync(classId);
            var classInformation = await _clientApiWrapper.GetClassByIdAsync(classId);

            foreach (var student in gotListStudentInClass)
            {
                ListStudentInClass.Add(
                    new StudentInClassWithClassName()
                    {
                        StudentName = student.StudentName,
                        StudentId = student.StudentId,
                        Passport = student.Passport,
                        ClassLetter = classInformation.Letter,
                        ClassNumber = classInformation.Number,
                        DateOfBirth = student.DateOfBirth
                    });
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
        
    }
    private async Task QueryGetTopFiveStudent()
    {
        ListTopFiveStudent.Clear();
        ShowTopFiveStudent();
        try
        {
            var listStudentResult = await _clientApiWrapper.TopFiveStudentAsync();
            foreach (var student in listStudentResult)
                ListTopFiveStudent.Add(student);
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }
    private async Task QueryTopFiveStudentInPeriod()
    {
        ListTopFiveStudentInPeriod.Clear();
        ShowTopFiveStudentInPeriod();
        if (LastSettedPeriod != null)
            LastSettedPeriod = await ShowTopFiveInPeriodDialog.Handle(LastSettedPeriod);
        else
            LastSettedPeriod = await ShowTopFiveInPeriodDialog.Handle(new TopFiveInPeriodViewModel());
        if (LastSettedPeriod != null)
        {
            try
            {
                var listStudentResult = await _clientApiWrapper
                    .TopFiveStudentInPeriodAsync(LastSettedPeriod.SettedStartPeriod!.Value, LastSettedPeriod.SettedEndPeriod!.Value);
                foreach (var student in listStudentResult)
                    ListTopFiveStudentInPeriod.Add(student);
            }
            catch (Exception ex)
            {
                await MessageBox.Avalonia.MessageBoxManager
                            .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                            .Show();
            }
        }
    }
    private async Task QueryInformationAllSubject()
    {
        ShowInformationAllSubject();
        ListInformationAllSubject.Clear();
        try
        {
            var resultAllSubject = await _clientApiWrapper.GetAllSubjectAsync();
            foreach (var subject in resultAllSubject)
                ListInformationAllSubject.Add(subject);
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }
    private async Task QueryListMaxMinAverageMark()
    {
        ShowMaxMinAverage();
        ListMaxMinAverageMark.Clear();
        var allSubject = await _clientApiWrapper.GetAllSubjectAsync();
        foreach (var subject in allSubject)
        {
            try
            {
                var maxMinAverage = await _clientApiWrapper.MaxMinAverageMarkBySubjectAsync(subject.SubjectId);
                ListMaxMinAverageMark.Add(new MaxMinAverageWithSubjectName()
                {
                    SubjectId = subject.SubjectId,
                    SubjectName = subject.SubjectName,
                    Average = maxMinAverage.Average,
                    Max = maxMinAverage.Max,
                    Min = maxMinAverage.Min
                });
            }
            catch (Exception ex)
            {
                await MessageBox.Avalonia.MessageBoxManager
                            .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                            .Show();
            }
        }
    }

    /// <summary>
    /// Constructor for class QueryViewModel with parameter ClientApiWrapper
    /// </summary>
    /// <param name="clientApiWrapper"></param>
    public QueryViewModel(ClientApiWrapper clientApiWrapper)
    {
        
        _clientApiWrapper = clientApiWrapper;
        ShowGetClassIdDialog = new Interaction<QueryClassTypeViewModel, QueryClassTypeViewModel?>();
        ShowTopFiveInPeriodDialog = new Interaction<TopFiveInPeriodViewModel, TopFiveInPeriodViewModel?>();
        OnGetListStudentInClass = ReactiveCommand.CreateFromTask(QueryGetStudentInClass);
        OnGetListTopFiveStudent = ReactiveCommand.CreateFromTask(QueryGetTopFiveStudent,
          this.WhenAnyValue(vm => vm.VisibleTopFiveStudent).Select(visible => !visible));
        OnGetInformationAllSubject = ReactiveCommand.CreateFromTask(QueryInformationAllSubject,
          this.WhenAnyValue(vm => vm.VisibleAllSubject).Select(visible => !visible));
        OnGetListTopFiveStudentInPeriod = ReactiveCommand.CreateFromTask(QueryTopFiveStudentInPeriod);
        OnGetMaxMinAverage = ReactiveCommand.CreateFromTask(QueryListMaxMinAverageMark,
          this.WhenAnyValue(vm => vm.VisibleMaxMinAverageMark).Select(visible => !visible));
    }

    #pragma warning disable CS8618
    /// <summary>
    /// Constructor for class ClientApiWrapper without parametter, but we don't use it
    /// (We declare it only for loading view)
    /// </summary>
    public QueryViewModel() 
    {
        ShowGetClassIdDialog = new Interaction<QueryClassTypeViewModel, QueryClassTypeViewModel?>();
        ShowTopFiveInPeriodDialog = new Interaction<TopFiveInPeriodViewModel, TopFiveInPeriodViewModel?>();
        OnGetListStudentInClass = ReactiveCommand.CreateFromTask(QueryGetStudentInClass);
        OnGetListTopFiveStudent = ReactiveCommand.CreateFromTask(QueryGetTopFiveStudent,
           this.WhenAnyValue(vm => vm.VisibleTopFiveStudent).Select(visible => !visible)
           );
        OnGetListTopFiveStudentInPeriod = ReactiveCommand.CreateFromTask(QueryTopFiveStudentInPeriod);
    }
    #pragma warning restore CS8618

    private void ShowListStudentInClass()
    {
        VisibleStudentInClass = true;

        VisibleAllSubject = false;
        VisibleTopFiveStudent = false;
        VisibleTopFiveStudentInPeriod = false;
        VisibleMaxMinAverageMark = false;
    }
    private void ShowTopFiveStudent()
    {
        VisibleTopFiveStudent = true;

        VisibleStudentInClass = false;
        VisibleAllSubject = false;
        VisibleTopFiveStudentInPeriod = false;
        VisibleMaxMinAverageMark = false;
    }
    private void ShowTopFiveStudentInPeriod()
    {
        VisibleTopFiveStudentInPeriod = true;

        VisibleStudentInClass = false;
        VisibleAllSubject = false;
        VisibleMaxMinAverageMark = false;
        VisibleTopFiveStudent = false;
    }
    private void ShowInformationAllSubject()
    {
        VisibleAllSubject = true;

        VisibleMaxMinAverageMark = false;
        VisibleStudentInClass = false;
        VisibleTopFiveStudent = false;
        VisibleTopFiveStudentInPeriod =false;
    }
    private void ShowMaxMinAverage()
    {
        VisibleMaxMinAverageMark = true;

        VisibleAllSubject = false;
        VisibleStudentInClass = false;
        VisibleTopFiveStudent = false;
        VisibleTopFiveStudentInPeriod = false;
    }
}
