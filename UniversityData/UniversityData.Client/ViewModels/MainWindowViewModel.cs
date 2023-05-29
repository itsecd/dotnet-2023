using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;

namespace UniversityData.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ObservableCollection<ConstructionPropertyViewModel> ConstructionProperties { get; } = new();

    private ConstructionPropertyViewModel? _selectedConstructionProperty;
    public ConstructionPropertyViewModel? SelectedConstructionProperty
    {
        get => _selectedConstructionProperty;
        set => this.RaiseAndSetIfChanged(ref _selectedConstructionProperty, value);
    }

    public ObservableCollection<UniversityPropertyViewModel> UniversityProperties { get; } = new();

    private UniversityPropertyViewModel? _selectedUniversityProperty;
    public UniversityPropertyViewModel? SelectedUniversityProperty
    {
        get => _selectedUniversityProperty;
        set => this.RaiseAndSetIfChanged(ref _selectedUniversityProperty, value);
    }

    public ObservableCollection<DepartmentViewModel> Departments { get; } = new();

    private DepartmentViewModel? _selectedDepartment;
    public DepartmentViewModel? SelectedDepartment
    {
        get => _selectedDepartment;
        set => this.RaiseAndSetIfChanged(ref _selectedDepartment, value);
    }

    public ObservableCollection<FacultyViewModel> Faculties { get; } = new();

    private FacultyViewModel? _selectedFaculty;
    public FacultyViewModel? SelectedFaculty
    {
        get => _selectedFaculty;
        set => this.RaiseAndSetIfChanged(ref _selectedFaculty, value);
    }

    public ObservableCollection<RectorViewModel> Rectors { get; } = new();

    private RectorViewModel? _selectedRector;
    public RectorViewModel? SelectedRector
    {
        get => _selectedRector;
        set => this.RaiseAndSetIfChanged(ref _selectedRector, value);
    }

    public ObservableCollection<SpecialtyViewModel> Specialties { get; } = new();

    private SpecialtyViewModel? _selectedSpecialty;
    public SpecialtyViewModel? SelectedSpecialty
    {
        get => _selectedSpecialty;
        set => this.RaiseAndSetIfChanged(ref _selectedSpecialty, value);
    }

    public ObservableCollection<SpecialtyTableNodeViewModel> SpecialtyTableNodes { get; } = new();

    private SpecialtyTableNodeViewModel? _selectedSpecialtyTableNode;
    public SpecialtyTableNodeViewModel? SelectedSpecialtyTableNode
    {
        get => _selectedSpecialtyTableNode;
        set => this.RaiseAndSetIfChanged(ref _selectedSpecialtyTableNode, value);
    }

    public ObservableCollection<UniversityViewModel> Universities { get; } = new();

    private UniversityViewModel? _selectedUniversity;
    public UniversityViewModel? SelectedUniversity
    {
        get => _selectedUniversity;
        set => this.RaiseAndSetIfChanged(ref _selectedUniversity, value);
    }

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

    public ObservableCollection<UniversityGetDto> FirstQuery { get; } = new();
    public ObservableCollection<UniversityStructureDto> SecondQuery { get; } = new();
    public ObservableCollection<MostPopularSpecialtyDto> ThirdQuery { get; } = new();
    public ObservableCollection<UniversityGetDto> FourthQuery { get; } = new();
    public ObservableCollection<UniversityWithGivenPropertyDto> FifthQuery { get; } = new();
    public ObservableCollection<CountDivisionsWithDifferentProperties> SixthQuery { get; } = new();

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

        OnChangeConstructionPropertyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var constructionPropertyViewModel = await ShowConstructionPropertyDialog.Handle(SelectedConstructionProperty!);
            if (constructionPropertyViewModel != null)
            {
                await _apiClient.UpdateConstructionPropertyAsync(SelectedConstructionProperty!.Id, _mapper.Map<ConstructionPropertyPostDto>(constructionPropertyViewModel));
                _mapper.Map(constructionPropertyViewModel, SelectedConstructionProperty);
            }
        }, this.WhenAnyValue(vm => vm.SelectedConstructionProperty).Select(selectConstructionProperty => selectConstructionProperty != null));

        OnDeleteConstructionPropertyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteConstructionPropertyAsync(SelectedConstructionProperty!.Id);
            ConstructionProperties.Remove(SelectedConstructionProperty!);
        }, this.WhenAnyValue(vm => vm.SelectedConstructionProperty).Select(selectConstructionProperty => selectConstructionProperty != null));

        OnAddDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(new DepartmentViewModel());
            if (departmentViewModel != null)
            {
                var newDepartment = await _apiClient.AddDepartmentAsync(_mapper.Map<DepartmentPostDto>(departmentViewModel));
                Departments.Add(_mapper.Map<DepartmentViewModel>(newDepartment));
            }
        });

        OnChangeDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(SelectedDepartment!);
            if (departmentViewModel != null)
            {
                await _apiClient.UpdateDepartmentAsync(SelectedDepartment!.Id, _mapper.Map<DepartmentPostDto>(departmentViewModel));
                _mapper.Map(departmentViewModel, SelectedDepartment);
            }
        }, this.WhenAnyValue(vm => vm.SelectedDepartment).Select(selectDepartment => selectDepartment != null));

        OnDeleteDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDepartmentAsync(SelectedDepartment!.Id);
            Departments.Remove(SelectedDepartment!);
        }, this.WhenAnyValue(vm => vm.SelectedDepartment).Select(selectDepartment => selectDepartment != null));

        OnAddFacultyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var facultyViewModel = await ShowFacultyDialog.Handle(new FacultyViewModel());
            if (facultyViewModel != null)
            {
                var newFaculty = await _apiClient.AddFacultyAsync(_mapper.Map<FacultyPostDto>(facultyViewModel));
                Faculties.Add(_mapper.Map<FacultyViewModel>(newFaculty));
            }
        });

        OnChangeFacultyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var facultyViewModel = await ShowFacultyDialog.Handle(SelectedFaculty!);
            if (facultyViewModel != null)
            {
                await _apiClient.UpdateFacultyAsync(SelectedFaculty!.Id, _mapper.Map<FacultyPostDto>(facultyViewModel));
                _mapper.Map(facultyViewModel, SelectedFaculty);
            }
        }, this.WhenAnyValue(vm => vm.SelectedFaculty).Select(selectFaculty => selectFaculty != null));

        OnDeleteFacultyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDepartmentAsync(SelectedFaculty!.Id);
            Faculties.Remove(SelectedFaculty!);
        }, this.WhenAnyValue(vm => vm.SelectedFaculty).Select(selectFaculty => selectFaculty != null));

        OnAddRectorCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rectorViewModel = await ShowRectorDialog.Handle(new RectorViewModel());
            if (rectorViewModel != null)
            {
                var newRector = await _apiClient.AddRectorAsync(_mapper.Map<RectorPostDto>(rectorViewModel));
                Rectors.Add(_mapper.Map<RectorViewModel>(newRector));
            }
        });

        OnChangeRectorCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rectorViewModel = await ShowRectorDialog.Handle(SelectedRector!);
            if (rectorViewModel != null)
            {
                await _apiClient.UpdateRectorAsync(SelectedRector!.Id, _mapper.Map<RectorPostDto>(rectorViewModel));
                _mapper.Map(rectorViewModel, SelectedRector);
            }
        }, this.WhenAnyValue(vm => vm.SelectedRector).Select(selectRector => selectRector != null));

        OnDeleteRectorCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRectorAsync(SelectedRector!.Id);
            Rectors.Remove(SelectedRector!);
        }, this.WhenAnyValue(vm => vm.SelectedRector).Select(selectRector => selectRector != null));

        OnAddSpecialtyTableNodeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var specialtyTableNodeViewModel = await ShowSpecialtyTableNodeDialog.Handle(new SpecialtyTableNodeViewModel());
            if (specialtyTableNodeViewModel != null)
            {
                var newSpecialtyTableNode = await _apiClient.AddSpecialtyTableNodeAsync(_mapper.Map<SpecialtyTableNodePostDto>(specialtyTableNodeViewModel));
                SpecialtyTableNodes.Add(_mapper.Map<SpecialtyTableNodeViewModel>(newSpecialtyTableNode));
            }
        });

        OnChangeSpecialtyTableNodeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var specialtyTableNodeViewModel = await ShowSpecialtyTableNodeDialog.Handle(SelectedSpecialtyTableNode!);
            if (specialtyTableNodeViewModel != null)
            {
                await _apiClient.UpdateSpecialtyTableNodeAsync(SelectedSpecialtyTableNode!.Id, _mapper.Map<SpecialtyTableNodePostDto>(specialtyTableNodeViewModel));
                _mapper.Map(specialtyTableNodeViewModel, SelectedSpecialtyTableNode);
            }
        }, this.WhenAnyValue(vm => vm.SelectedSpecialtyTableNode).Select(selectSpecialtyTableNode => selectSpecialtyTableNode != null));

        OnDeleteSpecialtyTableNodeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRectorAsync(SelectedSpecialtyTableNode!.Id);
            SpecialtyTableNodes.Remove(SelectedSpecialtyTableNode!);
        }, this.WhenAnyValue(vm => vm.SelectedSpecialtyTableNode).Select(selectSpecialtyTableNode => selectSpecialtyTableNode != null));

        OnAddSpecialtyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var specialtyViewModel = await ShowSpecialtyDialog.Handle(new SpecialtyViewModel());
            if (specialtyViewModel != null)
            {
                var newSpecialty = await _apiClient.AddSpecialtyAsync(_mapper.Map<SpecialtyPostDto>(specialtyViewModel));
                Specialties.Add(_mapper.Map<SpecialtyViewModel>(newSpecialty));
            }
        });

        OnChangeSpecialtyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var specialtyViewModel = await ShowSpecialtyDialog.Handle(SelectedSpecialty!);
            if (specialtyViewModel != null)
            {
                await _apiClient.UpdateSpecialtyAsync(SelectedSpecialty!.Id, _mapper.Map<SpecialtyPostDto>(specialtyViewModel));
                _mapper.Map(specialtyViewModel, SelectedSpecialty);
            }
        }, this.WhenAnyValue(vm => vm.SelectedSpecialty).Select(selectRector => selectRector != null));

        OnDeleteSpecialtyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRectorAsync(SelectedSpecialty!.Id);
            Specialties.Remove(SelectedSpecialty!);
        }, this.WhenAnyValue(vm => vm.SelectedSpecialty).Select(selectSpecialty => selectSpecialty != null));

        OnAddUniversityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var universityViewModel = await ShowUniversityDialog.Handle(new UniversityViewModel());
            if (universityViewModel != null)
            {
                var newUniversity = await _apiClient.AddUniversityAsync(_mapper.Map<UniversityPostDto>(universityViewModel));
                Universities.Add(_mapper.Map<UniversityViewModel>(newUniversity));
            }
        });

        OnChangeUniversityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var universityViewModel = await ShowUniversityDialog.Handle(SelectedUniversity!);
            if (universityViewModel != null)
            {
                await _apiClient.UpdateUniversityAsync(SelectedUniversity!.Id, _mapper.Map<UniversityPostDto>(universityViewModel));
                _mapper.Map(universityViewModel, SelectedUniversity);
            }
        }, this.WhenAnyValue(vm => vm.SelectedUniversity).Select(selectUniversity => selectUniversity != null));

        OnDeleteUniversityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRectorAsync(SelectedUniversity!.Id);
            Universities.Remove(SelectedUniversity!);
        }, this.WhenAnyValue(vm => vm.SelectedUniversity).Select(selectUniversity => selectUniversity != null));

        OnAddUniversityPropertyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var universityPropertyViewModel = await ShowUniversityPropertyDialog.Handle(new UniversityPropertyViewModel());
            if (universityPropertyViewModel != null)
            {
                var newUniversityProperty = await _apiClient.AddUniversityPropertyAsync(_mapper.Map<UniversityPropertyPostDto>(universityPropertyViewModel));
                UniversityProperties.Add(_mapper.Map<UniversityPropertyViewModel>(newUniversityProperty));
            }
        });

        OnChangeUniversityPropertyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var universityPropertyViewModel = await ShowUniversityPropertyDialog.Handle(SelectedUniversityProperty!);
            if (universityPropertyViewModel != null)
            {
                await _apiClient.UpdateUniversityPropertyAsync(SelectedUniversityProperty!.Id, _mapper.Map<UniversityPropertyPostDto>(universityPropertyViewModel));
                _mapper.Map(universityPropertyViewModel, SelectedUniversityProperty);
            }
        }, this.WhenAnyValue(vm => vm.SelectedUniversityProperty).Select(selectUniversityProperty => selectUniversityProperty != null));

        OnDeleteUniversityPropertyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRectorAsync(SelectedUniversityProperty!.Id);
            UniversityProperties.Remove(SelectedUniversityProperty!);
        }, this.WhenAnyValue(vm => vm.SelectedUniversityProperty).Select(selectUniversityProperty => selectUniversityProperty != null));

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

        var paramFirstQuery = "Самарский университет";
        var firstQueryObject = await _apiClient.GetInformationOfUniversityAsync(paramFirstQuery);
        FirstQuery.Add(firstQueryObject);

        var paramSecondQuery = "СамГТУ";
        var secondQueryObject = await _apiClient.InformationOfStructureAsync(paramSecondQuery);
        SecondQuery.Add(secondQueryObject);

        var thirdQueryObjects = await _apiClient.MostPopularSpecialtiesAsync();
        foreach (var thirdQueryObject in thirdQueryObjects)
        {
            ThirdQuery.Add(thirdQueryObject);
        }

        
        var fourthQueryObjects = await _apiClient.MaxCountDepartmentsAsync();
        foreach (var fourthQueryObject in fourthQueryObjects)
        {
            FourthQuery.Add(fourthQueryObject);
        }

        
        var paramFifthQuery = 1;
        var fifthQueryObjects = await _apiClient.UniversityWithPropertyAsync(paramFifthQuery);
        foreach (var fifthQueryObject in fifthQueryObjects)
        {
            FifthQuery.Add(fifthQueryObject);
        }

        var sixthQueryObjects = await _apiClient.CountDepartmentsAsync();
        foreach (var sixthQueryObject in sixthQueryObjects)
        {
            SixthQuery.Add(sixthQueryObject);
        }
    }
}
