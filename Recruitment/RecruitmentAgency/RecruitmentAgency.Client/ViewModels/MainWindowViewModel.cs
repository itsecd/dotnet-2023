using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReactiveUI;
using RecruitmentAgencyServer.Dto;
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
    public ReactiveCommand<Unit, Unit> OnAddCompanyApplicationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCompanyApplicationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCompanyApplicationCommand { get; set; }
    public Interaction<CompanyApplicationViewModel, CompanyApplicationViewModel?> ShowCompanyApplicationDialog { get; }
    public ReactiveCommand<Unit, Unit> OnAddEmployeeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeEmployeeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteEmployeeCommand { get; set; }
    public Interaction<EmployeeViewModel, EmployeeViewModel?> ShowEmployeeDialog { get; }
    public ReactiveCommand<Unit, Unit> OnAddJobApplicationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeJobApplicationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteJobApplicationCommand { get; set; }
    public Interaction<JobApplicationViewModel, JobApplicationViewModel?> ShowJobApplicationDialog { get; }
    public ReactiveCommand<Unit, Unit> OnAddTitleCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeTitleCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteTitleCommand { get; set; }
    public Interaction<TitleViewModel, TitleViewModel?> ShowTitleDialog { get; }
    public MainWindowViewModel() {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowCompanyDialog = new Interaction<CompanyViewModel, CompanyViewModel?>();
        ShowCompanyApplicationDialog = new Interaction<CompanyApplicationViewModel, CompanyApplicationViewModel?>();
        ShowEmployeeDialog = new Interaction<EmployeeViewModel, EmployeeViewModel?>();
        ShowJobApplicationDialog = new Interaction<JobApplicationViewModel, JobApplicationViewModel?>();
        ShowTitleDialog = new Interaction<TitleViewModel, TitleViewModel?>(); 

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

        OnAddCompanyApplicationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var companyApplicationViewModel = await ShowCompanyApplicationDialog.Handle(new CompanyApplicationViewModel());
            if (companyApplicationViewModel != null)
            {
                try
                {
                    var newCompanyApplication = await _apiClient.AddCompanyApplicationAsync(_mapper.Map<CompanyApplicationPostDto>(companyApplicationViewModel));
                    CompanyApplications.Add(_mapper.Map<CompanyApplicationViewModel>(newCompanyApplication));
                }
                catch { }
            }
        });

        OnChangeCompanyApplicationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var companyApplicationViewModel = await ShowCompanyApplicationDialog.Handle(SelectedCompanyApplication!);
            if (companyApplicationViewModel != null)
            {
                await _apiClient.UpdateCompanyApplicationAsync(SelectedCompanyApplication!.Id, _mapper.Map<CompanyApplicationPostDto>(companyApplicationViewModel));
                _mapper.Map(companyApplicationViewModel, SelectedCompanyApplication);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCompanyApplication).Select(selectCompanyApplication => selectCompanyApplication != null));

        OnDeleteCompanyApplicationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCompanyApplicationAsync(SelectedCompanyApplication!.Id);
            CompanyApplications.Remove(SelectedCompanyApplication!);
        }, this.WhenAnyValue(vm => vm.SelectedCompanyApplication).Select(selectCompanyApplication => selectCompanyApplication != null));
        OnAddEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var employeeViewModel = await ShowEmployeeDialog.Handle(new EmployeeViewModel());
            if (employeeViewModel != null)
            {
                var newEmployee = await _apiClient.AddEmployeeAsync(_mapper.Map<EmployeePostDto>(employeeViewModel));
                Employees.Add(_mapper.Map<EmployeeViewModel>(newEmployee));
            }
        });

        OnChangeEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var employeeViewModel = await ShowEmployeeDialog.Handle(SelectedEmployee!);
            if (employeeViewModel != null)
            {
                await _apiClient.UpdateEmployeeAsync(SelectedEmployee!.Id, _mapper.Map<EmployeePostDto>(employeeViewModel));
                _mapper.Map(employeeViewModel, SelectedEmployee);
            }
        }, this.WhenAnyValue(vm => vm.SelectedEmployee).Select(selectEmployee => selectEmployee != null));

        OnDeleteEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteEmployeeAsync(SelectedEmployee!.Id);
            Employees.Remove(SelectedEmployee!);
        }, this.WhenAnyValue(vm => vm.SelectedEmployee).Select(selectEmployee => selectEmployee != null));

        OnAddJobApplicationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var jobApplicationViewModel = await ShowJobApplicationDialog.Handle(new JobApplicationViewModel());
            if (jobApplicationViewModel != null)
            {
                try
                {
                    var newJobApplication = await _apiClient.AddJobApplicationAsync(_mapper.Map<JobApplicationPostDto>(jobApplicationViewModel));
                    JobApplications.Add(_mapper.Map<JobApplicationViewModel>(newJobApplication));
                }
                catch { }
            }
        });

        OnChangeJobApplicationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var jobApplicationViewModel = await ShowJobApplicationDialog.Handle(SelectedJobApplication!);
            if (jobApplicationViewModel != null)
            {
                await _apiClient.UpdateJobApplicationAsync(SelectedJobApplication!.Id, _mapper.Map<JobApplicationPostDto>(jobApplicationViewModel));
                _mapper.Map(jobApplicationViewModel, SelectedJobApplication);
            }
        }, this.WhenAnyValue(vm => vm.SelectedJobApplication).Select(selectJobApplication => selectJobApplication != null));

        OnDeleteJobApplicationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteJobApplicationAsync(SelectedJobApplication!.Id);
            JobApplications.Remove(SelectedJobApplication!);
        }, this.WhenAnyValue(vm => vm.SelectedJobApplication).Select(selectJobApplication => selectJobApplication != null));

        OnAddTitleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var titleViewModel = await ShowTitleDialog.Handle(new TitleViewModel());
            if (titleViewModel != null)
            {
                var newTitle = await _apiClient.AddTitleAsync(_mapper.Map<TitlePostDto>(titleViewModel));
                Titles.Add(_mapper.Map<TitleViewModel>(newTitle));
            }
        });

        OnChangeTitleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var titleViewModel = await ShowTitleDialog.Handle(SelectedTitle!);
            if (titleViewModel != null)
            {
                await _apiClient.UpdateTitleAsync(SelectedTitle!.Id, _mapper.Map<TitlePostDto>(titleViewModel));
                _mapper.Map(titleViewModel, SelectedTitle);
            }
        }, this.WhenAnyValue(vm => vm.SelectedTitle).Select(selectTitle => selectTitle != null));

        OnDeleteTitleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteTitleAsync(SelectedTitle!.Id);
            Titles.Remove(SelectedTitle!);
        }, this.WhenAnyValue(vm => vm.SelectedTitle).Select(selectTitle => selectTitle != null));

        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }
    private async void LoadDataAsync()
    {
        var companies = await _apiClient.GetCompaniesAsync();
        foreach (var company in companies)
        {
            Companies.Add(_mapper.Map<CompanyViewModel>(company));
        }
        var companyApplications = await _apiClient.GetCompanyApplicationsAsync();
        foreach (var companyApplication in companyApplications)
        {
            CompanyApplications.Add(_mapper.Map<CompanyApplicationViewModel>(companyApplication));
        }
        var jobApplications = await _apiClient.GetJobApplicationsAsync();
        foreach (var jobApplication in jobApplications)
        {
            JobApplications.Add(_mapper.Map<JobApplicationViewModel>(jobApplication));
        }
        var employees = await _apiClient.GetEmployeesAsync();
        foreach (var employee in employees)
        {
            Employees.Add(_mapper.Map<EmployeeViewModel>(employee));
        }
        var titles = await _apiClient.GetTitlesAsync();
        foreach (var title in titles)
        {
            Titles.Add(_mapper.Map<TitleViewModel>(title));
        }
    }
}
