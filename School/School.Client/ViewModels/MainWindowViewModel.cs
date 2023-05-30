using AutoMapper;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace School.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ClassViewModel? _selectedClass;

    private string _classExceptionValue = string.Empty;

    public string ClassExceptionValue
    {
        get => _classExceptionValue;
        set => this.RaiseAndSetIfChanged(ref _classExceptionValue, value);
    }

    private string _gradeExceptionValue = string.Empty;

    public string GradeExceptionValue
    {
        get => _gradeExceptionValue;
        set => this.RaiseAndSetIfChanged(ref _gradeExceptionValue, value);
    }

    private string _studentExceptionValue = string.Empty;

    public string StudentExceptionValue
    {
        get => _studentExceptionValue;
        set => this.RaiseAndSetIfChanged(ref _studentExceptionValue, value);
    }

    private string _subjectExceptionValue = string.Empty;

    public string SubjectExceptionValue
    {
        get => _subjectExceptionValue;
        set => this.RaiseAndSetIfChanged(ref _subjectExceptionValue, value);
    }

    public ClassViewModel? SelectedClass
    {
        get => _selectedClass;
        set => this.RaiseAndSetIfChanged(ref _selectedClass, value);
    }

    private GradeViewModel? _selectedGrade;

    public GradeViewModel? SelectedGrade
    {
        get => _selectedGrade;
        set => this.RaiseAndSetIfChanged(ref _selectedGrade, value);
    }

    private StudentViewModel? _selectedStudent;

    public StudentViewModel? SelectedStudent
    {
        get => _selectedStudent;
        set => this.RaiseAndSetIfChanged(ref _selectedStudent, value);
    }

    private SubjectViewModel? _selectedSubject;

    public SubjectViewModel? SelectedSubject
    {
        get => _selectedSubject;
        set => this.RaiseAndSetIfChanged(ref _selectedSubject, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ObservableCollection<ClassViewModel> Classes { get; } = new();

    public ObservableCollection<GradeViewModel> Grades { get; } = new();

    public ObservableCollection<StudentViewModel> Students { get; } = new();

    public ObservableCollection<SubjectViewModel> Subjects { get; } = new();

    public ReactiveCommand<Unit, Unit> OnAddClassCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeClassCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteClassCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddGradeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeGradeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteGradeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddStudentCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeStudentCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteStudentCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddSubjectCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeSubjectCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteSubjectCommand { get; set; }

    public Interaction<ClassViewModel, ClassViewModel?> ShowClassDialog { get; set; }

    public Interaction<GradeViewModel, GradeViewModel?> ShowGradeDialog { get; set; }

    public Interaction<StudentViewModel, StudentViewModel?> ShowStudentDialog { get; set; }

    public Interaction<SubjectViewModel, SubjectViewModel?> ShowSubjectDialog { get; set; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowClassDialog = new Interaction<ClassViewModel, ClassViewModel?>();
        ShowGradeDialog = new Interaction<GradeViewModel, GradeViewModel?>();
        ShowStudentDialog = new Interaction<StudentViewModel, StudentViewModel?>();
        ShowSubjectDialog = new Interaction<SubjectViewModel, SubjectViewModel?>();

        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);

        OnAddClassCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var classViewModel = await ShowClassDialog.Handle(new ClassViewModel());

            if (classViewModel != null)
            {
                try
                {
                    classViewModel.Id = await _apiClient
                        .PostClassAsync(_mapper.Map<ClassPostDto>(classViewModel));
                    Classes.Add(classViewModel);

                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    ClassExceptionValue = ex.Message;
                }
            }
        });

        OnChangeClassCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var classViewModel = await ShowClassDialog.Handle(SelectedClass!);

            if (classViewModel != null)
            {
                try
                {
                    await _apiClient.PutClassAsync(SelectedClass!.Id,
                        _mapper.Map<ClassPostDto>(classViewModel));
                    _mapper.Map(classViewModel, SelectedClass);
                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    ClassExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedClass)
            .Select(selectClass => selectClass != null));

        OnDeleteClassCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteClassAsync(SelectedClass!.Id);

                Classes.Remove(SelectedClass!);
                ClearExceptionsValues();
                LoadDataAsync();
            }
            catch (Exception ex)
            {
                ClassExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedClass)
            .Select(selectClass => selectClass != null));

        OnAddGradeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var gradeViewModel = await ShowGradeDialog.Handle(new GradeViewModel());

            if (gradeViewModel != null)
            {
                try
                {
                    gradeViewModel.Id = await _apiClient
                        .PostGradeAsync(_mapper.Map<GradePostDto>(gradeViewModel));
                    Grades.Add(gradeViewModel);

                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    GradeExceptionValue = ex.Message;
                }
            }
        });

        OnChangeGradeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var gradeViewModel = await ShowGradeDialog.Handle(SelectedGrade!);

            if (gradeViewModel != null)
            {
                try
                {
                    await _apiClient.PutGradeAsync(SelectedGrade!.Id,
                        _mapper.Map<GradePostDto>(gradeViewModel));
                    _mapper.Map(gradeViewModel, SelectedGrade);
                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    GradeExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedGrade)
            .Select(selectGrade => selectGrade != null));

        OnDeleteGradeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteGradeAsync(SelectedGrade!.Id);

                Grades.Remove(SelectedGrade!);
                ClearExceptionsValues();
                LoadDataAsync();
            }
            catch (Exception ex)
            {
                GradeExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedGrade)
            .Select(selectGrade => selectGrade != null));

        OnAddStudentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var studentViewModel = await ShowStudentDialog.Handle(new StudentViewModel());

            if (studentViewModel != null)
            {
                try
                {
                    studentViewModel.Id = await _apiClient
                        .PostStudentAsync(_mapper.Map<StudentPostDto>(studentViewModel));
                    Students.Add(studentViewModel);

                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    StudentExceptionValue = ex.Message;
                }
            }
        });

        OnChangeStudentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var studentViewModel = await ShowStudentDialog.Handle(SelectedStudent!);

            if (studentViewModel != null)
            {
                try
                {
                    await _apiClient.PutStudentAsync(SelectedStudent!.Id,
                        _mapper.Map<StudentPostDto>(studentViewModel));
                    _mapper.Map(studentViewModel, SelectedStudent);
                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    StudentExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedStudent)
            .Select(selectStudent => selectStudent != null));

        OnDeleteStudentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteStudentAsync(SelectedStudent!.Id);

                Students.Remove(SelectedStudent!);
                ClearExceptionsValues();
                LoadDataAsync();
            }
            catch (Exception ex)
            {
                StudentExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedStudent)
            .Select(selectStudent => selectStudent != null));

        OnAddSubjectCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var subjectViewModel = await ShowSubjectDialog.Handle(new SubjectViewModel());

            if (subjectViewModel != null)
            {
                try
                {
                    subjectViewModel.Id = await _apiClient
                        .PostSubjectAsync(_mapper.Map<SubjectPostDto>(subjectViewModel));
                    Subjects.Add(subjectViewModel);

                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    SubjectExceptionValue = ex.Message;
                }
            }
        });

        OnChangeSubjectCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var subjectViewModel = await ShowSubjectDialog.Handle(SelectedSubject!);

            if (subjectViewModel != null)
            {
                try
                {
                    await _apiClient.PutSubjectAsync(SelectedSubject!.Id,
                        _mapper.Map<SubjectPostDto>(subjectViewModel));
                    _mapper.Map(subjectViewModel, SelectedSubject);
                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    SubjectExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedSubject)
            .Select(selectSubject => selectSubject != null));

        OnDeleteSubjectCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteSubjectAsync(SelectedSubject!.Id);

                Subjects.Remove(SelectedSubject!);
                ClearExceptionsValues();
                LoadDataAsync();
            }
            catch (Exception ex)
            {
                SubjectExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedSubject)
            .Select(selectSubject => selectSubject != null));
    }

    public async void LoadDataAsync()
    {
        Classes.Clear();
        Grades.Clear();
        Students.Clear();
        Subjects.Clear();

        foreach (var schoolClass in await _apiClient.GetClassesAsync())
        {
            Classes.Add(_mapper.Map<ClassViewModel>(schoolClass));
        }

        foreach (var grade in await _apiClient.GetGradesAsync())
        {
            Grades.Add(_mapper.Map<GradeViewModel>(grade));
        }

        foreach (var student in await _apiClient.GetStudentsAsync())
        {
            Students.Add(_mapper.Map<StudentViewModel>(student));
        }

        foreach (var subject in await _apiClient.GetSubjectsAsync())
        {
            Subjects.Add(_mapper.Map<SubjectViewModel>(subject));
        }
    }

    private void ClearExceptionsValues()
    {
        ClassExceptionValue = string.Empty;
        GradeExceptionValue = string.Empty;
        StudentExceptionValue = string.Empty;
        SubjectExceptionValue = string.Empty;
    }
}