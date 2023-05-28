using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using AutoMapper;
using ReactiveUI;
using Splat;

namespace UniversityData.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ObservableCollection<ConstructionPropertyViewModel> ConstructionProperties { get; } = new();
    public ObservableCollection<UniversityPropertyViewModel> UniversityProperties { get; } = new();
    public ObservableCollection<DepartmentViewModel> Departments { get; } = new();
    public ObservableCollection<FacultyViewModel> Faculties { get; } = new();
    public ObservableCollection<RectorViewModel> Rectors { get; } = new();
    public ObservableCollection<SpecialtyViewModel> Specialties { get; } = new();
    public ObservableCollection<SpecialtyTableNodeViewModel> SpecialtyTableNodes { get; } = new();
    public ObservableCollection<UniversityViewModel> Universities { get; } = new();

    public ReactiveCommand<Unit, Unit> OnAddConstructionPropertyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeConstructionPropertyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteConstructionPropertyCommand { get; set; }
    public Interaction<ConstructionPropertyViewModel, ConstructionPropertyViewModel?> ShowConstructionPropertyDialog { get; }
    public ReactiveCommand<Unit, Unit> OnAddDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteDepartmentCommand { get; set; }
    public Interaction<DepartmentViewModel, DepartmentViewModel?> ShowDepartmentDialog { get; }
    public ReactiveCommand<Unit, Unit> OnAddFacultyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeFacultyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteFacultyCommand { get; set; }
    public Interaction<FacultyViewModel, FacultyViewModel?> ShowFacultyDialog { get; }
    public ReactiveCommand<Unit, Unit> OnAddRectorCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeRectorCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteRectorCommand { get; set; }
    public Interaction<RectorViewModel, RectorViewModel?> ShowRectorDialog { get; }
    public ReactiveCommand<Unit, Unit> OnAddSpecialtyTableNodeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeSpecialtyTableNodeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteSpecialtyTableNodeCommand { get; set; }
    public Interaction<SpecialtyTableNodeViewModel, SpecialtyTableNodeViewModel?> ShowSpecialtyTableNodeDialog { get; }
    public ReactiveCommand<Unit, Unit> OnAddSpecialtyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeSpecialtyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteSpecialtyCommand { get; set; }
    public Interaction<SpecialtyViewModel, SpecialtyViewModel?> ShowSpecialtyDialog { get; }
    public ReactiveCommand<Unit, Unit> OnAddUniversityCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeUniversityCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteUniversityCommand { get; set; }
    public Interaction<UniversityViewModel, UniversityViewModel?> ShowUniversityDialog { get; }
    public ReactiveCommand<Unit, Unit> OnAddUniversityPropertyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeUniversityPropertyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteUniversityPropertyCommand { get; set; }
    public Interaction<UniversityPropertyViewModel, UniversityPropertyViewModel?> ShowUniversityPropertyDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowConstructionPropertyDialog = new Interaction<ConstructionPropertyViewModel, ConstructionPropertyViewModel?>();
        ShowDepartmentDialog = new Interaction<DepartmentViewModel, DepartmentViewModel?>();
        ShowFacultyDialog = new Interaction<FacultyViewModel, FacultyViewModel?>();
        ShowRectorDialog = new Interaction<RectorViewModel, RectorViewModel?>();
        ShowSpecialtyTableNodeDialog = new Interaction<SpecialtyTableNodeViewModel, SpecialtyTableNodeViewModel?>();
        ShowSpecialtyDialog = new Interaction<SpecialtyViewModel, SpecialtyViewModel?>();
        ShowUniversityDialog = new Interaction<UniversityViewModel, UniversityViewModel?>();
        ShowUniversityPropertyDialog = new Interaction<UniversityPropertyViewModel, UniversityPropertyViewModel?>();

        OnAddConstructionPropertyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
        var constructionPropertyViewModel = await ShowConstructionPropertyDialog.Handle(new ConstructionPropertyViewModel());
        if (constructionPropertyViewModel != null)
            {
                var newConstructionProperty = await _apiClient.AddConstructionPropertyAsync(_mapper.Map<ConstructionPropertyPostDto>(constructionPropertyViewModel));
                ConstructionProperties.Add(_mapper.Map<ConstructionPropertyViewModel>(newConstructionProperty));
            }
        });

        OnAddDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(new DepartmentViewModel());
            if (departmentViewModel != null)
            {
                var newDepartment = await _apiClient.AddDepartmentAsync(_mapper.Map<DepartmentPostDto>(departmentViewModel));
                Departments.Add(_mapper.Map<DepartmentViewModel>(newDepartment));
            }
        });

        OnAddFacultyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var facultyViewModel = await ShowFacultyDialog.Handle(new FacultyViewModel());
            if (facultyViewModel != null)
            {
                var newFaculty = await _apiClient.AddFacultyAsync(_mapper.Map<FacultyPostDto>(facultyViewModel));
                Faculties.Add(_mapper.Map<FacultyViewModel>(newFaculty));
            }
        });

        OnAddRectorCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rectorViewModel = await ShowRectorDialog.Handle(new RectorViewModel());
            if (rectorViewModel != null)
            {
                var newRector = await _apiClient.AddRectorAsync(_mapper.Map<RectorPostDto>(rectorViewModel));
                Rectors.Add(_mapper.Map<RectorViewModel>(newRector));
            }
        });

        OnAddSpecialtyTableNodeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var specialtyTableNodeViewModel = await ShowSpecialtyTableNodeDialog.Handle(new SpecialtyTableNodeViewModel());
            if (specialtyTableNodeViewModel != null)
            {
                var newSpecialtyTableNode = await _apiClient.AddSpecialtyTableNodeAsync(_mapper.Map<SpecialtyTableNodePostDto>(specialtyTableNodeViewModel));
                SpecialtyTableNodes.Add(_mapper.Map<SpecialtyTableNodeViewModel>(newSpecialtyTableNode));
            }
        });

        OnAddSpecialtyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var specialtyViewModel = await ShowSpecialtyDialog.Handle(new SpecialtyViewModel());
            if (specialtyViewModel != null)
            {
                var newSpecialty = await _apiClient.AddSpecialtyAsync(_mapper.Map<SpecialtyPostDto>(specialtyViewModel));
                Specialties.Add(_mapper.Map<SpecialtyViewModel>(newSpecialty));
            }
        });

        OnAddUniversityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var universityViewModel = await ShowUniversityDialog.Handle(new UniversityViewModel());
            if (universityViewModel != null)
            {
                var newUniversity = await _apiClient.AddUniversityAsync(_mapper.Map<UniversityPostDto>(universityViewModel));
                Universities.Add(_mapper.Map<UniversityViewModel>(newUniversity));
            }
        });

        OnAddUniversityPropertyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var universityPropertyViewModel = await ShowUniversityPropertyDialog.Handle(new UniversityPropertyViewModel());
            if (universityPropertyViewModel != null)
            {
                var newUniversityProperty = await _apiClient.AddUniversityPropertyAsync(_mapper.Map<UniversityPropertyPostDto>(universityPropertyViewModel));
                UniversityProperties.Add(_mapper.Map<UniversityPropertyViewModel>(newUniversityProperty));
            }
        });

        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }

    private async void LoadDataAsync()
    {
        var constructionProperties = await _apiClient.GetConstructionPropertyAsync();
        foreach (var constructionProperty in constructionProperties)
        {
            ConstructionProperties.Add(_mapper.Map<ConstructionPropertyViewModel>(constructionProperty));
        }
        var universityProperties = await _apiClient.GetUniversityPropertyAsync();
        foreach (var universityProperty in universityProperties)
        {
            UniversityProperties.Add(_mapper.Map<UniversityPropertyViewModel>(universityProperty));
        }
        var departments = await _apiClient.GetDepartmentAsync();
        foreach (var department in departments)
        {
            Departments.Add(_mapper.Map<DepartmentViewModel>(department));
        }
        var faculties = await _apiClient.GetFacultyAsync();
        foreach (var faculty in faculties)
        {
            Faculties.Add(_mapper.Map<FacultyViewModel>(faculty));
        }
        var rectors = await _apiClient.GetRectorAsync();
        foreach (var rector in rectors)
        {
            Rectors.Add(_mapper.Map<RectorViewModel>(rector));
        }
        var specialties = await _apiClient.GetSpecialtyAsync();
        foreach (var specialty in specialties)
        {
            Specialties.Add(_mapper.Map<SpecialtyViewModel>(specialty));
        }
        var specialtyTableNodes = await _apiClient.GetSpecialtyTableNodeAsync();
        foreach (var specialtyTableNode in specialtyTableNodes)
        {
            SpecialtyTableNodes.Add(_mapper.Map<SpecialtyTableNodeViewModel>(specialtyTableNode));
        }
        var universitites = await _apiClient.GetUniversityAsync();
        foreach (var university in universitites)
        {
            Universities.Add(_mapper.Map<UniversityViewModel>(university));
        }
    }
}
