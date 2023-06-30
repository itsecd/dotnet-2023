using AutoMapper;
using MessageBox.Avalonia.Enums;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace LibrarySchool.Client.ViewModels;
/// <summary>
/// ViewModel of class main window
/// </summary>
public class MainWindowViewModel : ViewModelBase
{
    private readonly ClientApiWrapper _clientApiWrapper;
    private readonly IMapper _mapper;


    private bool _visibleListStudent = false;
    private bool _visibleListClass = false;
    private bool _visibleListSubject = false;
    private bool _visibleListMark = false;


    private int _selectionHeader = 0;
    /// <summary>
    /// 
    /// </summary>
    public int SelectionHeader
    {
        get => _selectionHeader;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectionHeader, value);
            OnSelectedTabIndexChange();
        }
    }
    private async void OnSelectedTabIndexChange()
    {
        switch (SelectionHeader)
        {
            case 0:
                await GetListStudent();
                return;
            case 1:
                await GetListClassType();
                return;
            case 2:
                await GetListSubject();
                return;
            case 3:
                await GetListMark();
                return;
        }
    }


    private StudentViewModel? _selectedStudent;
    /// <summary>
    /// Selected student in table list student
    /// </summary>
    public StudentViewModel? SelectedStudent
    {
        get => _selectedStudent;
        set => this.RaiseAndSetIfChanged(ref _selectedStudent, value);
    }
    private ClassTypeViewModel? _selectedClassType;
    /// <summary>
    /// Selected class in table class
    /// </summary>
    public ClassTypeViewModel? SelectedClassType
    {
        get => _selectedClassType;
        set => this.RaiseAndSetIfChanged(ref _selectedClassType, value);
    }
    private SubjectViewModel? _selectedSubject;
    /// <summary>
    /// Selected subject in list subject
    /// </summary>
    public SubjectViewModel? SelectedSubject
    {
        get => _selectedSubject;
        set => this.RaiseAndSetIfChanged(ref _selectedSubject, value);
    }
    private MarkViewModel? _selectedMark;
    /// <summary>
    /// Selected mark in list mark
    /// </summary>
    public MarkViewModel? SelectedMark
    {
        get => _selectedMark;
        set => this.RaiseAndSetIfChanged(ref _selectedMark, value);
    }

    /// <summary>
    /// List information student in tabe
    /// </summary>
    public ObservableCollection<StudentViewModel> ListStudent { get; } = new();

    /// <summary>
    /// List information class in table
    /// </summary>
    public ObservableCollection<ClassTypeViewModel> ListClass { get; } = new();

    /// <summary>
    /// List information subject in table
    /// </summary>
    public ObservableCollection<SubjectViewModel> ListSubject { get; } = new();

    /// <summary>
    /// List information subject in table
    /// </summary>
    public ObservableCollection<MarkViewModel> ListMark { get; } = new();

    /// <summary>
    /// Command binding for button Add
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }

    /// <summary>
    /// Command binding for button Update
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnUpdateCommand { get; set; }

    /// <summary>
    /// Command binding for button Delete
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    /// <summary>
    /// Command binding for button get student
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnListStudentCommand { get; set; }

    /// <summary>
    /// Command binding for button get class
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnListClassTypeCommand { get; set; }

    /// <summary>
    /// Command binding for button get subject
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnListSubjectCommand { get; set; }

    /// <summary>
    /// Command binding for button get mark
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnListMarkCommand { get; set; }

    /// <summary>
    /// Command binding for button open window query
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnQueryCommand { get; set; }

    /// <summary>
    /// Open Student View in dialog
    /// </summary>
    public Interaction<StudentViewModel, StudentViewModel?> ShowStudentDialog { get; }

    /// <summary>
    /// Open ClassType View in dialog
    /// </summary>
    public Interaction<ClassTypeViewModel, ClassTypeViewModel?> ShowClassTypeDialog { get; }

    /// <summary>
    /// Open Subject View in dialog
    /// </summary>
    public Interaction<SubjectViewModel, SubjectViewModel?> ShowSubjectDialog { get; }

    /// <summary>
    /// Open Mark View in dialog
    /// </summary>
    public Interaction<MarkViewModel, MarkViewModel?> ShowMarkDialog { get; }

    /// <summary>
    /// Open Query View in dialog
    /// </summary>
    public Interaction<QueryViewModel, QueryViewModel?> ShowQueryDialog { get; }

    /// <summary>
    /// Selected an element in table or not
    /// </summary>
    public IObservable<bool> CanUpdateOrDelete { get; set; }

    /// <summary>
    /// Constructor for class MainWindowViewModel
    /// </summary>
    public MainWindowViewModel()
    {
        _clientApiWrapper = Locator.Current.GetService<ClientApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();
        ShowStudentDialog = new Interaction<StudentViewModel, StudentViewModel?>();
        ShowClassTypeDialog = new Interaction<ClassTypeViewModel, ClassTypeViewModel?>();
        ShowSubjectDialog = new Interaction<SubjectViewModel, SubjectViewModel?>();
        ShowMarkDialog = new Interaction<MarkViewModel, MarkViewModel?>();
        ShowQueryDialog = new Interaction<QueryViewModel, QueryViewModel?>();


        OnListStudentCommand = ReactiveCommand.CreateFromTask(GetListStudent,
                                                        this.WhenAnyValue(vm => vm._visibleListStudent)
                                                            .Select(student => !student));
        OnListClassTypeCommand = ReactiveCommand.CreateFromTask(GetListClassType,
                                                        this.WhenAnyValue(vm => vm._visibleListClass)
                                                            .Select(classType => !classType));
        OnListSubjectCommand = ReactiveCommand.CreateFromTask(GetListSubject,
                                                        this.WhenAnyValue(vm => vm._visibleListSubject)
                                                            .Select(subject => !subject));
        OnListMarkCommand = ReactiveCommand.CreateFromTask(GetListMark,
                                                        this.WhenAnyValue(vm => vm._visibleListMark)
                                                            .Select(mark => !mark));
        CanUpdateOrDelete = this.WhenAnyValue(
                        vm => vm.SelectedStudent,
                        vm => vm.SelectedClassType,
                        vm => vm.SelectedSubject,
                        vm => vm.SelectedMark,
                        (student, classType, subject, mark)
                        => student != null || classType != null || subject != null || mark != null);

        OnAddCommand = ReactiveCommand.CreateFromTask(AddDataAsync);
        OnUpdateCommand = ReactiveCommand.CreateFromTask(UpdateDataAsync, CanUpdateOrDelete);
        OnDeleteCommand = ReactiveCommand.CreateFromTask(DeleteDataAsync, CanUpdateOrDelete);
        OnQueryCommand = ReactiveCommand.CreateFromTask(OpenQueryAsync);
        RxApp.MainThreadScheduler.Schedule(FirstLoadingStudent);
    }

    /// <summary>
    /// Add data async to database
    /// </summary>
    /// <returns>Result task or throw exception</returns>
    public async Task AddDataAsync()
    {
        if (_visibleListStudent)
        {
            var studentViewModel = await ShowStudentDialog.Handle(new StudentViewModel());
            if (studentViewModel != null)
            {
                try
                {
                    await _clientApiWrapper.AddStudentAsync(_mapper.Map<StudentPostDto>(studentViewModel));
                    await GetListStudent();
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }
            }
        }
        else if (_visibleListClass)
        {
            var classTypeViewModel = await ShowClassTypeDialog.Handle(new ClassTypeViewModel());
            if (classTypeViewModel != null)
            {
                try
                {
                    await _clientApiWrapper.AddClassTypeAsync(_mapper.Map<ClassTypePostDto>(classTypeViewModel));
                    await GetListClassType();
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }
            }
        }
        else if (_visibleListSubject)
        {
            var subjectViewModel = await ShowSubjectDialog.Handle(new SubjectViewModel());
            if (subjectViewModel != null)
            {
                try
                {
                    await _clientApiWrapper.AddSubjectAsync(_mapper.Map<SubjectPostDto>(subjectViewModel));
                    await GetListSubject();
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }

            }
        }
        else if (_visibleListMark)
        {
            var markViewModel = await ShowMarkDialog.Handle(new MarkViewModel());
            if (markViewModel != null)
            {
                try
                {
                    await _clientApiWrapper.AddMarkAsync(_mapper.Map<MarkPostDto>(markViewModel));
                    await GetListMark();
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }

            }
        }

    }

    /// <summary>
    /// Update data async to database
    /// </summary>
    /// <returns>Result task or throw exception</returns>
    public async Task UpdateDataAsync()
    {
        if (SelectedStudent != null)
        {
            var studentViewModel = await ShowStudentDialog.Handle(SelectedStudent!);
            if (studentViewModel != null)
            {
                try
                {
                    await _clientApiWrapper.UpdateStudentAsync(SelectedStudent!.StudentId, _mapper.Map<StudentPostDto>(studentViewModel));
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }
            }
            else
                await GetListStudent();
        }
        else if (SelectedClassType != null)
        {
            var classTypeViewModel = await ShowClassTypeDialog.Handle(SelectedClassType!);
            if (classTypeViewModel != null)
            {
                try
                {
                    await _clientApiWrapper.UpdateClassTypeAsync(SelectedClassType!.ClassId, _mapper.Map<ClassTypePostDto>(classTypeViewModel));
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }
            }
            else
                await GetListClassType();
        }
        else if (SelectedSubject != null)
        {
            var subjectViewModel = await ShowSubjectDialog.Handle(SelectedSubject);
            if (subjectViewModel != null)
            {
                try
                {
                    await _clientApiWrapper.UpdateSubjectAsync(SelectedSubject.SubjectId, _mapper.Map<SubjectPostDto>(SelectedSubject));
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia
                                .MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }
            }
            else
                await GetListSubject();
        }
        else if (SelectedMark != null)
        {
            var markViewModel = await ShowMarkDialog.Handle(SelectedMark);
            if (markViewModel != null)
            {
                try
                {
                    await _clientApiWrapper.UpdateMarkAsync(SelectedMark.MarkId, _mapper.Map<MarkPostDto>(SelectedMark));
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia
                                .MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }
            }
            else
                await GetListMark();
        }
    }

    /// <summary>
    /// Delete data async to database
    /// </summary>
    /// <returns>Result task or throw exception</returns>
    public async Task DeleteDataAsync()
    {
        if (SelectedStudent != null)
        {

            if (await MessageBox.Avalonia.MessageBoxManager
                            .GetMessageBoxStandardWindow("Warning", $"Are you sure to delete student {SelectedStudent.StudentName}", ButtonEnum.YesNo, Icon.Warning)
                            .Show() == ButtonResult.Yes)
            {
                try
                {
                    await _clientApiWrapper.DeleteStudentAsync(SelectedStudent!.StudentId);
                    ListStudent.Remove(SelectedStudent);
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }
            }
        }
        else if (SelectedClassType != null)
        {
            if (await MessageBox.Avalonia.MessageBoxManager
                           .GetMessageBoxStandardWindow("Warning", $"Are you sure to delete class {SelectedClassType.Number}", ButtonEnum.YesNo, Icon.Warning)
                           .Show() == ButtonResult.Yes)
            {
                try
                {
                    await _clientApiWrapper.DeleteClassTypeAsync(SelectedClassType!.ClassId);
                    ListClass.Remove(SelectedClassType);
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }
            }
        }
        else if (SelectedSubject != null)
        {
            if (await MessageBox.Avalonia.MessageBoxManager
                          .GetMessageBoxStandardWindow("Warning", $"Are you sure to delete subject {SelectedSubject.SubjectName}", ButtonEnum.YesNo, Icon.Warning)
                          .Show() == ButtonResult.Yes)
            {
                try
                {
                    await _clientApiWrapper.DeleteSubjectAsync(SelectedSubject!.SubjectId);
                    ListSubject.Remove(SelectedSubject);
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }
            }
        }
        else if (SelectedMark != null)
        {
            if (await MessageBox.Avalonia.MessageBoxManager
                          .GetMessageBoxStandardWindow("Warning", $"Are you sure to delete mark id: {SelectedMark.MarkId}", ButtonEnum.YesNo, Icon.Warning)
                          .Show() == ButtonResult.Yes)
            {
                try
                {
                    await _clientApiWrapper.DeleteMarkAsync(SelectedMark!.MarkId);
                    ListMark.Remove(SelectedMark);
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                                .Show();
                }
            }
        }
    }

    /// <summary>
    /// Open query window
    /// </summary>
    /// <returns>Result task or throw exception</returns>
    public async Task OpenQueryAsync()
    {
        await ShowQueryDialog.Handle(new QueryViewModel(_clientApiWrapper));
    }

    private void ShowListStudent()
    {
        _visibleListStudent = true;
        _visibleListClass = false;
        _visibleListSubject = false;
        _visibleListMark = false;

        SelectedClassType = null;
        SelectedSubject = null;
        SelectedMark = null;
    }
    private void ShowListClass()
    {
        _visibleListClass = true;
        _visibleListStudent = false;
        _visibleListSubject = false;
        _visibleListMark = false;

        SelectedStudent = null;
        SelectedSubject = null;
        SelectedMark = null;
    }
    private void ShowListSubject()
    {
        _visibleListSubject = true;
        _visibleListClass = false;
        _visibleListStudent = false;
        _visibleListMark = false;

        SelectedStudent = null;
        SelectedClassType = null;
        SelectedMark = null;
    }
    private void ShowListMark()
    {
        _visibleListMark = true;
        _visibleListClass = false;
        _visibleListStudent = false;
        _visibleListSubject = false;

        SelectedClassType = null;
        SelectedStudent = null;
        SelectedSubject = null;
    }

    private async Task GetListStudent()
    {
        ShowListStudent();
        ListStudent.Clear();
        try
        {
            var listStudentResult = await _clientApiWrapper.GetAllStudentAsync();
            foreach (var student in listStudentResult)
            {
                ListStudent.Add(_mapper.Map<StudentViewModel>(student));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }
    private async Task GetListClassType()
    {
        ShowListClass();
        ListClass.Clear();
        try
        {
            var listClassTypeResult = await _clientApiWrapper.GetAllClassTypeAsync();
            foreach (var classType in listClassTypeResult)
            {
                ListClass.Add(_mapper.Map<ClassTypeViewModel>(classType));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }
    private async Task GetListSubject()
    {
        ShowListSubject();
        ListSubject.Clear();
        try
        {
            var listSubjectResult = await _clientApiWrapper.GetAllSubjectAsync();
            foreach (var subject in listSubjectResult)
            {
                ListSubject.Add(_mapper.Map<SubjectViewModel>(subject));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }
    private async Task GetListMark()
    {
        ShowListMark();
        ListMark.Clear();
        try
        {
            var listMarkResult = await _clientApiWrapper.GetAllMarkAsync();
            foreach (var mark in listMarkResult)
                ListMark.Add(_mapper.Map<MarkViewModel>(mark));
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }

    private async void FirstLoadingStudent()
    {
        ShowListStudent();
        ListStudent.Clear();
        try
        {
            var listStudentResult = await _clientApiWrapper.GetAllStudentAsync();
            foreach (var student in listStudentResult)
            {
                ListStudent.Add(_mapper.Map<StudentViewModel>(student));
            }
        }
        catch (ApiException ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }
}
