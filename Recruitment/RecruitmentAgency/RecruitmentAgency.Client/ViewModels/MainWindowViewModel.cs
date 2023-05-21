using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace RecruitmentAgency.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<CompanyViewModel> Companies { get; } = new();
    private CompanyViewModel? _selectedCompany;
    public CompanyViewModel? SelectedCompany
    {
        get=> _selectedCompany;
        set=> this.RaiseAndSetIfChanged(ref _selectedCompany, value);
    }
    public ObservableCollection<CompanyApplicationViewModel> CompanyApplications { get; } = new();
    private CompanyApplicationViewModel? _selectedCompanyApplication;
    public CompanyApplicationViewModel? SelectedCompanyApplication
    {
        get => _selectedCompanyApplication;
        set => this.RaiseAndSetIfChanged(ref _selectedCompanyApplication, value);
    }
    public ObservableCollection<JobApplicationViewModel> JobApplications { get; } = new();
    private JobApplicationViewModel? _selectedJobApplication;
    public JobApplicationViewModel? SelectedJobApplication
    {
        get => _selectedJobApplication;
        set => this.RaiseAndSetIfChanged(ref _selectedJobApplication, value);
    }
    public ObservableCollection<EmployeeViewModel> Employees { get; } = new();
    private EmployeeViewModel? _selectedEmployee;
    public EmployeeViewModel? SelectedEmployee
    {
        get => _selectedEmployee;
        set => this.RaiseAndSetIfChanged(ref _selectedEmployee, value);
    }
    public ObservableCollection<TitleViewModel> Titles { get; } = new();
    private TitleViewModel? _selectedTitle;
    public TitleViewModel? SelectedTitle
    {
        get => _selectedTitle;
        set => this.RaiseAndSetIfChanged(ref _selectedTitle, value);
    }

    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;
    public ReactiveCommand<Unit, Unit> OnAddCompanyCommand { get; set; }
    public ReactiveCommand<Unit,Unit> OnChangeCompanyCommand{get;set;}
    public ReactiveCommand<Unit,Unit> OnDeleteCompanyCommand { get;set;}
    public Interaction<CompanyViewModel, CompanyViewModel?> ShowCompanyDialog { get; }
    public MainWindowViewModel() {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowCompanyDialog = new Interaction<CompanyViewModel, CompanyViewModel?>();

        OnAddCompanyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var companyViewModel = await ShowCompanyDialog.Handle(new CompanyViewModel());
            if(companyViewModel != null)
            {
                var newCompany = await _apiClient.AddCompanyAsync(_mapper.Map<CompanyPostDto>(companyViewModel));
                Companies.Add(_mapper.Map<CompanyViewModel>(newCompany));
            }
        });

        OnChangeCompanyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var companyViewModel = await ShowCompanyDialog.Handle(SelectedCompany!);
            if (companyViewModel != null)
            {
                await _apiClient.UpdateCompanyAsync(SelectedCompany!.Id, _mapper.Map<CompanyPostDto>(companyViewModel));
                _mapper.Map(companyViewModel, SelectedCompany);
            }
        }, this.WhenAnyValue(vm=>vm.SelectedCompany).Select(selectCompany=> selectCompany != null));

        OnDeleteCompanyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCompanyAsync(SelectedCompany!.Id);
            Companies.Remove(SelectedCompany!);
        }, this.WhenAnyValue(vm => vm.SelectedCompany).Select(selectCompany => selectCompany != null));

        RxApp.MainThreadScheduler.Schedule(LoadCompaniesAsync);
        /*RxApp.MainThreadScheduler.Schedule(LoadCompanyApplicationsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadEmployeesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadJobApplicationsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadTitlesAsync);*/
    }
    private async void LoadCompaniesAsync()
    {
        var companies = await _apiClient.GetCompaniesAsync();
        foreach (var company in companies)
        {
            Companies.Add(_mapper.Map<CompanyViewModel>(company));
        }
        
    }
    private async void LoadCompanyApplicationsAsync()
    {
        var companyApplications = await _apiClient.GetCompanyApplicationsAsync();
        foreach (var companyApplication in companyApplications)
        {
            CompanyApplications.Add(_mapper.Map<CompanyApplicationViewModel>(companyApplication));
        }
    }
    private async void LoadJobApplicationsAsync()
    {
        var jobApplications = await _apiClient.GetJobApplicationsAsync();
        foreach (var jobApplication in jobApplications)
        {
            JobApplications.Add(_mapper.Map<JobApplicationViewModel>(jobApplication));
        }
    }
    private async void LoadEmployeesAsync()
    {
        var employees = await _apiClient.GetEmployeesAsync();
        foreach (var employee in employees)
        {
            Employees.Add(_mapper.Map<EmployeeViewModel>(employee));
        }
    }
    private async void LoadTitlesAsync()
    {
        var titles = await _apiClient.GetTitlesAsync();
        foreach (var title in titles)
        {
            Titles.Add(_mapper.Map<TitleViewModel>(title));
        }
    }

}
