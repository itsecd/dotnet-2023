using AutoMapper;
using Splat;
using System.Collections.ObjectModel;

namespace RecruitmentAgency.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<CompanyViewModel> Companies { get; } = new();
    public ObservableCollection<CompanyApplicationViewModel> CompanyApplications { get; } = new();
    public ObservableCollection<JobApplicationViewModel> JobApplications { get; } = new();
    public ObservableCollection<EmployeeViewModel> Employees { get; } = new();
    public ObservableCollection<TitleViewModel> Titles { get; } = new();

    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;
    public MainWindowViewModel() {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();
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
