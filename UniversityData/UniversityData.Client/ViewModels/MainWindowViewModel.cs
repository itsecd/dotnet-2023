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
    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<ConstructionPropertyViewModel, ConstructionPropertyViewModel?> ShowConstructionPropertyDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowConstructionPropertyDialog = new Interaction<ConstructionPropertyViewModel, ConstructionPropertyViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
        var constructionPropertyViewModel = await ShowConstructionPropertyDialog.Handle(new ConstructionPropertyViewModel());
        if (constructionPropertyViewModel != null)
            {
                var newConstructionProperty = await _apiClient.AddConstructionPropertyAsync(_mapper.Map<ConstructionPropertyPostDto>(constructionPropertyViewModel));
                ConstructionProperties.Add(_mapper.Map<ConstructionPropertyViewModel>(newConstructionProperty));
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
