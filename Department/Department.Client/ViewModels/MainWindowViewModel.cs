using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Department.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ObservableCollection<CourseViewModel> Courses { get; } = new();
    public ObservableCollection<GroupViewModel> Groups { get; } = new();
    public ObservableCollection<TeacherViewModel> Teachers { get; } = new();
    public ObservableCollection<SubjectViewModel> Subjects { get; } = new();
    public ObservableCollection<TeacherViewModel> CourseProjectTeachers { get; } = new();

    private CourseViewModel? _selectedCourse;
    public CourseViewModel? SelectedCourse
    {
        get => _selectedCourse;
        set => this.RaiseAndSetIfChanged(ref _selectedCourse, value);
    }

    private GroupViewModel? _selectedGroup;
    public GroupViewModel? SelectedGroup
    {
        get => _selectedGroup;
        set => this.RaiseAndSetIfChanged(ref _selectedGroup, value);
    }

    private TeacherViewModel? _selectedTeacher;
    public TeacherViewModel? SelectedTeacher
    {
        get => _selectedTeacher;
        set => this.RaiseAndSetIfChanged(ref _selectedTeacher, value);
    }

    private SubjectViewModel? _selectedSubject;
    public SubjectViewModel? SelectedSubject
    {
        get => _selectedSubject;
        set => this.RaiseAndSetIfChanged(ref _selectedSubject, value);
    }

    public ReactiveCommand<Unit, Unit> OnAddCourseCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditCourseCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCourseCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddGroupCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditGroupCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteGroupCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddTeacherCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditTeacherCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteTeacherCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddSubjectCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditSubjectCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteSubjectCommand { get; set; }

    public Interaction<CourseViewModel, CourseViewModel?> ShowCourseDialog { get; }
    public Interaction<GroupViewModel, GroupViewModel?> ShowGroupDialog { get; }
    public Interaction<TeacherViewModel, TeacherViewModel?> ShowTeacherDialog { get; }
    public Interaction<SubjectViewModel, SubjectViewModel?> ShowSubjectDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowCourseDialog = new Interaction<CourseViewModel, CourseViewModel?>();
        ShowGroupDialog = new Interaction<GroupViewModel, GroupViewModel?>();
        ShowTeacherDialog = new Interaction<TeacherViewModel, TeacherViewModel?>();
        ShowSubjectDialog = new Interaction<SubjectViewModel, SubjectViewModel?>();

        OnAddCourseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var courseViewModel = await ShowCourseDialog.Handle(new CourseViewModel());
            if (courseViewModel != null)
            {
                var newCourse = await _apiClient.AddCourseAsync(_mapper.Map<CourseSetDto>(courseViewModel));
                Courses.Add(_mapper.Map<CourseViewModel>(newCourse));
            }
        });

        OnEditCourseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var courseViewModel = await ShowCourseDialog.Handle(SelectedCourse!);
            if (courseViewModel != null)
            {
                await _apiClient.UpdateCourseAsync(SelectedCourse!.Id, _mapper.Map<CourseSetDto>(courseViewModel));
                _mapper.Map(courseViewModel, SelectedCourse);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCourse).Select(selectCourse => selectCourse != null));

        OnDeleteCourseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCourseAsync(SelectedCourse!.Id);
            Courses.Remove(SelectedCourse);
        }, this.WhenAnyValue(vm => vm.SelectedCourse).Select(selectCourse => selectCourse != null));

        OnAddGroupCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var groupViewModel = await ShowGroupDialog.Handle(new GroupViewModel());
            if (groupViewModel != null)
            {
                var newGroup = await _apiClient.AddGroupAsync(_mapper.Map<GroupSetDto>(groupViewModel));
                Groups.Add(_mapper.Map<GroupViewModel>(newGroup));
            }
        });

        OnEditGroupCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var groupViewModel = await ShowGroupDialog.Handle(SelectedGroup!);
            if (groupViewModel != null)
            {
                await _apiClient.UpdateGroupAsync(SelectedGroup!.Id, _mapper.Map<GroupSetDto>(groupViewModel));
                _mapper.Map(groupViewModel, SelectedGroup);
            }
        }, this.WhenAnyValue(vm => vm.SelectedGroup).Select(selectGroup => selectGroup != null));

        OnDeleteGroupCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteGroupAsync(SelectedGroup!.Id);
            Groups.Remove(SelectedGroup);
        }, this.WhenAnyValue(vm => vm.SelectedGroup).Select(selectGroup => selectGroup != null));

        OnAddTeacherCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var teacherViewModel = await ShowTeacherDialog.Handle(new TeacherViewModel());
            if (teacherViewModel != null)
            {
                var newTeacher = await _apiClient.AddTeacherAsync(_mapper.Map<TeacherSetDto>(teacherViewModel));
                Teachers.Add(_mapper.Map<TeacherViewModel>(newTeacher));
            }
        });

        OnEditTeacherCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var teacherViewModel = await ShowTeacherDialog.Handle(SelectedTeacher!);
            if (teacherViewModel != null)
            {
                await _apiClient.UpdateTeacherAsync(SelectedTeacher!.Id, _mapper.Map<TeacherSetDto>(teacherViewModel));
                _mapper.Map(teacherViewModel, SelectedTeacher);
            }
        }, this.WhenAnyValue(vm => vm.SelectedTeacher).Select(selectTeacher => selectTeacher != null));

        OnDeleteTeacherCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteTeacherAsync(SelectedTeacher!.Id);
            Teachers.Remove(SelectedTeacher);
        }, this.WhenAnyValue(vm => vm.SelectedTeacher).Select(selectTeacher => selectTeacher != null));

        OnAddSubjectCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var subjectViewModel = await ShowSubjectDialog.Handle(new SubjectViewModel());
            if (subjectViewModel != null)
            {
                var newSubject = await _apiClient.AddSubjectAsync(_mapper.Map<SubjectSetDto>(subjectViewModel));
                Subjects.Add(_mapper.Map<SubjectViewModel>(newSubject));
            }
        });

        OnEditSubjectCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var subjectViewModel = await ShowSubjectDialog.Handle(SelectedSubject!);
            if (subjectViewModel != null)
            {
                await _apiClient.UpdateSubjectAsync(SelectedSubject!.Id, _mapper.Map<SubjectSetDto>(subjectViewModel));
                _mapper.Map(subjectViewModel, SelectedSubject);
            }
        }, this.WhenAnyValue(vm => vm.SelectedSubject).Select(selectSubject => selectSubject != null));

        OnDeleteSubjectCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteSubjectAsync(SelectedSubject!.Id);
            Subjects.Remove(SelectedSubject);
        }, this.WhenAnyValue(vm => vm.SelectedSubject).Select(selectSubject => selectSubject != null));

        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }

    private async void LoadDataAsync()
    {
        CourseProjectTeachers.Clear();
        var courseProjectTeachers = await _apiClient.CourseProjectTeachersAsync();
        foreach (var teacher in courseProjectTeachers)
        {
            CourseProjectTeachers.Add(_mapper.Map<TeacherViewModel>(teacher));
        }

        var courses = await _apiClient.GetCoursesAsync();
        foreach (var course in courses)
        {
            Courses.Add(_mapper.Map<CourseViewModel>(course));
        }

        var groups = await _apiClient.GetGroupAsync();
        foreach (var group in groups)
        {
            Groups.Add(_mapper.Map<GroupViewModel>(group));
        }

        var teachers = await _apiClient.GetTeachersAsync();
        foreach (var teacher in teachers)
        {
            Teachers.Add(_mapper.Map<TeacherViewModel>(teacher));
        }

        var subjects = await _apiClient.GetSubjectsAsync();
        foreach (var subject in subjects)
        {
            Subjects.Add(_mapper.Map<SubjectViewModel>(subject));
        }
    }
}
