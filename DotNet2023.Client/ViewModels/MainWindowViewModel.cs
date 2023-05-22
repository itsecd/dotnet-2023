using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace DotNet2023.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region ObservableCollection
    public ObservableCollection<HigherEducationInstitutionViewModel> Institutions { get; } = new();
    public ObservableCollection<DepartmentViewModel> Departments { get; } = new();
    public ObservableCollection<EducationWorkerViewModel> EducationWorkers { get; } = new();
    public ObservableCollection<FacultyViewModel> Faculties { get; } = new();
    public ObservableCollection<GroupOfStudentsViewModel> GroupOfStudents { get; } = new();
    public ObservableCollection<InstituteSpecialityViewModel> InstituteSpecialities { get; } = new();
    public ObservableCollection<SpecialityViewModel> Specialities { get; } = new();
    public ObservableCollection<StudentViewModel> Students { get; } = new();

    #endregion ObservableCollection

    #region Queries
    public ObservableCollection<SpecialityViewModel> PopularSpecialies { get; } = new();
    public ObservableCollection<HigherEducationInstitutionViewModel> InstitutionsWithMaxDepartmentsAsync { get; } = new();
    public ObservableCollection<ResponseUniversityStructByProperty> InstitutionStructAsync { get; } = new();

    #endregion Queries


    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;

    private HigherEducationInstitutionViewModel? _selectedHigherEducationInstitution;
    private DepartmentViewModel? _selectedDepartment;
    private EducationWorkerViewModel? _selectedEducationWorker;
    private FacultyViewModel? _selectedFaculty;
    private GroupOfStudentsViewModel? _selectedGroupOfStudents;
    private InstituteSpecialityViewModel? _selectedInstituteSpeciality;
    private SpecialityViewModel? _selectedSpeciality;
    private StudentViewModel? _selectedStudent;


    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        OnUpdateQueries = ReactiveCommand.CreateFromTask(() =>
        {
            LoadQueriesAsync();
            return Task.CompletedTask;
        });

        ShowInstitutionDialog = new Interaction<HigherEducationInstitutionViewModel, HigherEducationInstitutionViewModel?>();
        OnAddInstitutionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var institutionViewModel = await ShowInstitutionDialog.Handle(new HigherEducationInstitutionViewModel());
            if (institutionViewModel != null)
            {
                var newInsitution = _apiClient.GreateInstitutionAsync(
                    _mapper.Map<HigherEducationInstitutionDto>(institutionViewModel));

                Institutions.Add(_mapper.Map<HigherEducationInstitutionViewModel>(newInsitution));
            }
        });
        OnEditInstitutionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var institutionViewModel = await ShowInstitutionDialog.Handle(SelectedHigherEducationInstitution!);
            if (institutionViewModel != null)
            {
                await _apiClient.UpdateInstitutionAsync(_mapper.Map<HigherEducationInstitutionDto>(institutionViewModel));
                _mapper.Map(institutionViewModel, SelectedHigherEducationInstitution);
            }
        }, this.WhenAnyValue(vm => vm.SelectedHigherEducationInstitution)
            .Select(selectedInstitution => selectedInstitution != null));
        OnDeleteInstitutionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteInstitutionAsync(SelectedHigherEducationInstitution!.Id);
            Institutions.Remove(SelectedHigherEducationInstitution);
        }, this.WhenAnyValue(vm => vm.SelectedHigherEducationInstitution)
                    .Select(selectedHigherEducationInstitution => selectedHigherEducationInstitution != null));


        ShowDepartmentDialog = new Interaction<DepartmentViewModel, DepartmentViewModel?>();
        OnAddDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(new DepartmentViewModel());
            if (departmentViewModel != null)
            {
                var newDepartment = _apiClient.GreateDepartmentAsync(
                    _mapper.Map<DepartmentDto>(departmentViewModel));

                Departments.Add(_mapper.Map<DepartmentViewModel>(newDepartment));
            }
        });
        OnEditDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(SelectedDepartment!);
            if (departmentViewModel != null)
            {
                await _apiClient.UpdateDepartmentAsync(_mapper.Map<DepartmentDto>(departmentViewModel));
                _mapper.Map(departmentViewModel, SelectedDepartment);
            }
        }, this.WhenAnyValue(vm => vm.SelectedDepartment)
            .Select(selectedDepartment => selectedDepartment != null));
        OnDeleteDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDepartmentAsync(SelectedDepartment!.Id);
            Departments.Remove(SelectedDepartment);
        }, this.WhenAnyValue(vm => vm.SelectedDepartment)
                    .Select(selectedDepartment => selectedDepartment != null));

        ShowEducationWorkerDialog = new Interaction<EducationWorkerViewModel, EducationWorkerViewModel?>();
        OnAddEducationWorkerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workerViewModel = await ShowEducationWorkerDialog.Handle(new EducationWorkerViewModel());
            if (workerViewModel != null)
            {
                var newWorker = _apiClient.GreateEducationWorkerAsync(
                    _mapper.Map<EducationWorkerDto>(workerViewModel));
                EducationWorkers.Add(_mapper.Map<EducationWorkerViewModel>(newWorker));
            }
        });
        OnEditEducationWorkerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workerViewModel = await ShowEducationWorkerDialog.Handle(SelectedEducationWorker!);
            if (workerViewModel != null)
            {
                await _apiClient.UpdateEducationWorkerAsync(_mapper.Map<EducationWorkerDto>(workerViewModel));
                _mapper.Map(workerViewModel, SelectedEducationWorker);
            }
        }, this.WhenAnyValue(vm => vm.SelectedEducationWorker)
            .Select(selectedEducationWorker => selectedEducationWorker != null));
        OnDeleteEducationWorkerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteEducationWorkerAsync(SelectedEducationWorker!.Id);
            EducationWorkers.Remove(SelectedEducationWorker);
        }, this.WhenAnyValue(vm => vm.SelectedEducationWorker)
                    .Select(educationWorker => educationWorker != null));

        ShowFacultytDialog = new Interaction<FacultyViewModel, FacultyViewModel?>();
        OnAddFacultyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var facultyViewModel = await ShowFacultytDialog.Handle(new FacultyViewModel());
            if (facultyViewModel != null)
            {
                var newFaculty = _apiClient.GreateFacultyAsync(
                    _mapper.Map<FacultyDto>(facultyViewModel));
                Faculties.Add(_mapper.Map<FacultyViewModel>(newFaculty));
            }
        });
        OnEditFacultyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var facultyViewModel = await ShowFacultytDialog.Handle(SelectedFaculty!);
            if (facultyViewModel != null)
            {
                await _apiClient.UpdateFacultyAsync(_mapper.Map<FacultyDto>(facultyViewModel));
                _mapper.Map(facultyViewModel, SelectedFaculty);
            }
        }, this.WhenAnyValue(vm => vm.SelectedFaculty)
            .Select(selectedFaculty => selectedFaculty != null));
        OnDeleteFacultyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteFacultyAsync(SelectedFaculty!.Id);
            Faculties.Remove(SelectedFaculty);
        }, this.WhenAnyValue(vm => vm.SelectedFaculty)
                    .Select(selectedFaculty => selectedFaculty != null));

        ShowGroupOfStudentstDialog = new Interaction<GroupOfStudentsViewModel, GroupOfStudentsViewModel?>();
        OnAddGroupOfStudentsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var groupOfStudentsViewModel = await ShowGroupOfStudentstDialog.Handle(new GroupOfStudentsViewModel());
            if (groupOfStudentsViewModel != null)
            {
                var newGroup = _apiClient.CreateGroupOfStudentAsync(
                    _mapper.Map<GroupOfStudentsDto>(groupOfStudentsViewModel));
                GroupOfStudents.Add(_mapper.Map<GroupOfStudentsViewModel>(newGroup));
            }
        });
        OnEditGroupOfStudentsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var groupViewModel = await ShowGroupOfStudentstDialog.Handle(SelectedGroupOfStudents!);
            if (groupViewModel != null)
            {
                await _apiClient.UpdateGroupOfStudentsAsync(_mapper.Map<GroupOfStudentsDto>(groupViewModel));
                _mapper.Map(groupViewModel, SelectedGroupOfStudents);
            }
        }, this.WhenAnyValue(vm => vm.SelectedGroupOfStudents)
            .Select(selectedGroup => selectedGroup != null));
        OnDeleteGroupOfStudentsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteGroupOfStudentsAsync(SelectedGroupOfStudents!.Id);
            GroupOfStudents.Remove(SelectedGroupOfStudents);
        }, this.WhenAnyValue(vm => vm.SelectedGroupOfStudents)
                    .Select(selectedGroup => selectedGroup != null));


        ShowInstituteSpecialityDialog = new Interaction<InstituteSpecialityViewModel, InstituteSpecialityViewModel?>();
        OnAddInstituteSpecialityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var instituteSpecialityViewModel = await ShowInstituteSpecialityDialog.Handle(new InstituteSpecialityViewModel());
            if (instituteSpecialityViewModel != null)
            {
                var newInstituteSpeciality = _apiClient.CreateInstituteSpecialityAsync(
                    _mapper.Map<InstituteSpecialityDto>(instituteSpecialityViewModel));
                InstituteSpecialities.Add(_mapper.Map<InstituteSpecialityViewModel>(newInstituteSpeciality));
            }
        });
        OnEditInstituteSpecialityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var instituteSpecialityViewModel = await ShowInstituteSpecialityDialog.Handle(SelectedInstituteSpeciality!);
            if (instituteSpecialityViewModel != null)
            {
                await _apiClient.UpdateInstituteSpecialityAsync(_mapper.Map<InstituteSpecialityDto>(instituteSpecialityViewModel));
                _mapper.Map(instituteSpecialityViewModel, SelectedInstituteSpeciality);
            }
        }, this.WhenAnyValue(vm => vm.SelectedInstituteSpeciality)
            .Select(selectedInstituteSpeciality => selectedInstituteSpeciality != null));
        OnDeleteInstituteSpecialityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteInstituteSpecialityAsync(
                SelectedInstituteSpeciality!.IdSpeciality, SelectedInstituteSpeciality!.IdHigherEducationInstitution);
            InstituteSpecialities.Remove(SelectedInstituteSpeciality!);
        }, this.WhenAnyValue(vm => vm.SelectedInstituteSpeciality)
                    .Select(selectedInstituteSpeciality => selectedInstituteSpeciality != null));

        ShowSpecialityDialog = new Interaction<SpecialityViewModel, SpecialityViewModel?>();
        OnAddSpecialityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var specialityViewModel = await ShowSpecialityDialog.Handle(new SpecialityViewModel());
            if (specialityViewModel != null)
            {
                var newSpeciality = _apiClient.CreateSpecialityAsync(
                    _mapper.Map<SpecialityDto>(specialityViewModel));
                Specialities.Add(_mapper.Map<SpecialityViewModel>(newSpeciality));
            }
        });
        OnEditSpecialityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var specialityViewModel = await ShowSpecialityDialog.Handle(SelectedSpeciality!);
            if (specialityViewModel != null)
            {
                await _apiClient.UpdateSpecialityAsync(_mapper.Map<SpecialityDto>(specialityViewModel));
                _mapper.Map(specialityViewModel, SelectedSpeciality);
            }
        }, this.WhenAnyValue(vm => vm.SelectedSpeciality)
            .Select(selectedSpeciality => selectedSpeciality != null));
        OnDeleteSpecialityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteSpecialityAsync(SelectedSpeciality!.Code);
            Specialities.Remove(SelectedSpeciality!);
        }, this.WhenAnyValue(vm => vm.SelectedSpeciality)
                    .Select(selectedSpeciality => selectedSpeciality != null));

        ShowStudentDialog = new Interaction<StudentViewModel, StudentViewModel?>();
        OnAddStudentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var studentViewModel = await ShowStudentDialog.Handle(new StudentViewModel());
            if (studentViewModel != null)
            {
                var newStudent = _apiClient.CreateStudentAsync(
                    _mapper.Map<StudentDto>(studentViewModel));
                Students.Add(_mapper.Map<StudentViewModel>(newStudent));
            }
        });
        OnEditStudentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var studentViewModel = await ShowStudentDialog.Handle(SelectedStudent!);
            if (studentViewModel != null)
            {
                await _apiClient.UpdateStudentAsync(_mapper.Map<StudentDto>(studentViewModel));
                _mapper.Map(studentViewModel, SelectedStudent);
            }
        }, this.WhenAnyValue(vm => vm.SelectedStudent)
            .Select(selectedStudent => selectedStudent != null));
        OnDeleteStudentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteStudentAsync(SelectedStudent!.Id);
            Students.Remove(SelectedStudent!);
        }, this.WhenAnyValue(vm => vm.SelectedStudent)
                    .Select(selectedStudent => selectedStudent != null));

        RxApp.MainThreadScheduler.Schedule(LoadInstitutionAsync);
        RxApp.MainThreadScheduler.Schedule(LoadDepartmentsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadEducationWorkersAsync);
        RxApp.MainThreadScheduler.Schedule(LoadFacultiesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadGroupOfStudentsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadInstituteSpecialitiesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadSpecialitiesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadStudentsAsync);

    }

    #region Selected
    public HigherEducationInstitutionViewModel? SelectedHigherEducationInstitution
    {
        get => _selectedHigherEducationInstitution;
        set => this.RaiseAndSetIfChanged(ref _selectedHigherEducationInstitution, value);
    }
    public DepartmentViewModel? SelectedDepartment
    {
        get => _selectedDepartment;
        set => this.RaiseAndSetIfChanged(ref _selectedDepartment, value);
    }
    public EducationWorkerViewModel? SelectedEducationWorker
    {
        get => _selectedEducationWorker;
        set => this.RaiseAndSetIfChanged(ref _selectedEducationWorker, value);
    }
    public FacultyViewModel? SelectedFaculty
    {
        get => _selectedFaculty;
        set => this.RaiseAndSetIfChanged(ref _selectedFaculty, value);
    }
    public GroupOfStudentsViewModel? SelectedGroupOfStudents
    {
        get => _selectedGroupOfStudents;
        set => this.RaiseAndSetIfChanged(ref _selectedGroupOfStudents, value);
    }
    public InstituteSpecialityViewModel? SelectedInstituteSpeciality
    {
        get => _selectedInstituteSpeciality;
        set => this.RaiseAndSetIfChanged(ref _selectedInstituteSpeciality, value);
    }
    public SpecialityViewModel? SelectedSpeciality
    {
        get => _selectedSpeciality;
        set => this.RaiseAndSetIfChanged(ref _selectedSpeciality, value);
    }
    public StudentViewModel? SelectedStudent
    {
        get => _selectedStudent;
        set => this.RaiseAndSetIfChanged(ref _selectedStudent, value);
    }
    #endregion

    #region Commands
    public ReactiveCommand<Unit, Unit> OnUpdateQueries { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddInstitutionCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditInstitutionCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteInstitutionCommand { get; set; }
    public Interaction<HigherEducationInstitutionViewModel, HigherEducationInstitutionViewModel?> ShowInstitutionDialog { get; }

    public ReactiveCommand<Unit, Unit> OnAddDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteDepartmentCommand { get; set; }
    public Interaction<DepartmentViewModel, DepartmentViewModel?> ShowDepartmentDialog { get; }

    public ReactiveCommand<Unit, Unit> OnAddEducationWorkerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditEducationWorkerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteEducationWorkerCommand { get; set; }
    public Interaction<EducationWorkerViewModel, EducationWorkerViewModel?> ShowEducationWorkerDialog { get; }


    public ReactiveCommand<Unit, Unit> OnAddFacultyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditFacultyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteFacultyCommand { get; set; }
    public Interaction<FacultyViewModel, FacultyViewModel?> ShowFacultytDialog { get; }


    public ReactiveCommand<Unit, Unit> OnAddGroupOfStudentsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditGroupOfStudentsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteGroupOfStudentsCommand { get; set; }
    public Interaction<GroupOfStudentsViewModel, GroupOfStudentsViewModel?> ShowGroupOfStudentstDialog { get; }


    public ReactiveCommand<Unit, Unit> OnAddInstituteSpecialityCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditInstituteSpecialityCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteInstituteSpecialityCommand { get; set; }
    public Interaction<InstituteSpecialityViewModel, InstituteSpecialityViewModel?> ShowInstituteSpecialityDialog { get; }


    public ReactiveCommand<Unit, Unit> OnAddSpecialityCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditSpecialityCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteSpecialityCommand { get; set; }
    public Interaction<SpecialityViewModel, SpecialityViewModel?> ShowSpecialityDialog { get; }


    public ReactiveCommand<Unit, Unit> OnAddStudentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditStudentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteStudentCommand { get; set; }
    public Interaction<StudentViewModel, StudentViewModel?> ShowStudentDialog { get; }

    #endregion Commands

    #region Loads
    private async void LoadQueriesAsync()
    {
        PopularSpecialies.Clear();
        InstitutionsWithMaxDepartmentsAsync.Clear();
        InstitutionStructAsync.Clear();

        foreach (var elem in await _apiClient.GetPopularSpecialityAsync())
        {
            PopularSpecialies.Add(_mapper.Map<SpecialityViewModel>(elem));
        }
        foreach (var elem in await _apiClient.GetInstitutionsWithMaxDepartmentsAsync())
        {
            InstitutionsWithMaxDepartmentsAsync.Add(_mapper.Map<HigherEducationInstitutionViewModel>(elem));
        }
        foreach (var elem in await _apiClient.GetInstitutionStructAsync(InstitutionalProperty._0, BuildingProperty._2))
        {
            InstitutionStructAsync.Add(elem);
        }

    }

    private async void LoadInstitutionAsync()
    {
        Institutions.Clear();
        foreach (var elem in await _apiClient.GetInstitutionsAsync())
        {
            Institutions.Add(_mapper.Map<HigherEducationInstitutionViewModel>(elem));
        }
    }
    private async void LoadDepartmentsAsync()
    {
        Departments.Clear();
        foreach (var elem in await _apiClient.GetDepartmentsAsync())
        {
            Departments.Add(_mapper.Map<DepartmentViewModel>(elem));
        }
    }
    private async void LoadEducationWorkersAsync()
    {
        EducationWorkers.Clear();
        foreach (var elem in await _apiClient.GetEducationWorkersAsync())
        {
            EducationWorkers.Add(_mapper.Map<EducationWorkerViewModel>(elem));
        }
    }
    private async void LoadFacultiesAsync()
    {
        Faculties.Clear();
        foreach (var elem in await _apiClient.GetFacultiesAsync())
        {
            Faculties.Add(_mapper.Map<FacultyViewModel>(elem));
        }
    }
    private async void LoadGroupOfStudentsAsync()
    {
        GroupOfStudents.Clear();
        foreach (var elem in await _apiClient.GetGroupOfStudentsAsync())
        {
            GroupOfStudents.Add(_mapper.Map<GroupOfStudentsViewModel>(elem));
        }
    }
    private async void LoadInstituteSpecialitiesAsync()
    {
        InstituteSpecialities.Clear();
        foreach (var elem in await _apiClient.GetInstituteSpecialitiesAsync())
        {
            InstituteSpecialities.Add(_mapper.Map<InstituteSpecialityViewModel>(elem));
        }
    }
    private async void LoadSpecialitiesAsync()
    {
        Specialities.Clear();
        foreach (var elem in await _apiClient.GetSpecialitiesAsync())
        {
            Specialities.Add(_mapper.Map<SpecialityViewModel>(elem));
        }
    }
    private async void LoadStudentsAsync()
    {
        Students.Clear();
        foreach (var elem in await _apiClient.GetStudentsAsync())
        {
            Students.Add(_mapper.Map<StudentViewModel>(elem));
        }
    }

    #endregion Loads
}
