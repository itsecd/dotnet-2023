using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Company.Client.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;


    public ObservableCollection<DepartmentViewModel> Departments { get; } = new();
    public ObservableCollection<JobViewModel> Jobs { get; } = new();
    public ObservableCollection<VacationViewModel> Vacations { get; } = new();
    public ObservableCollection<VacationSpotViewModel> VacationSpots { get; } = new();
    public ObservableCollection<WorkerViewModel> Workers { get; } = new();
    public ObservableCollection<WorkersAndDepartmentsViewModel> WorkersAndDepartments { get; } = new();
    public ObservableCollection<WorkersAndJobsViewModel> WorkersAndJobs { get; } = new();
    public ObservableCollection<WorkersAndVacationsViewModel> WorkersAndVacations { get; } = new();
    public ObservableCollection<WorkshopViewModel> Workshops { get; } = new();


    public DepartmentViewModel? _selectedDepartment;
    public JobViewModel? _selectedJob;
    public VacationViewModel? _selectedVacation;
    public VacationSpotViewModel? _selectedVacationSpot;
    public WorkerViewModel? _selectedWorker;
    public WorkersAndDepartmentsViewModel? _selectedWorkersAndDepartments;
    public WorkersAndJobsViewModel? _selectedWorkersAndJobs;
    public WorkersAndVacationsViewModel? _selectedWorkersAndVacations;
    public WorkshopViewModel? _selectedWorkshop;


    public DepartmentViewModel? SelectedDepartment
    {
        get => _selectedDepartment;
        set => this.RaiseAndSetIfChanged(ref _selectedDepartment, value);
    }
    public JobViewModel? SelectedJob
    {
        get => _selectedJob;
        set => this.RaiseAndSetIfChanged(ref _selectedJob, value);
    }
    public VacationViewModel? SelectedVacation
    {
        get => _selectedVacation;
        set => this.RaiseAndSetIfChanged(ref _selectedVacation, value);
    }
    public VacationSpotViewModel? SelectedVacationSpot
    {
        get => _selectedVacationSpot;
        set => this.RaiseAndSetIfChanged(ref _selectedVacationSpot, value);
    }
    public WorkerViewModel? SelectedWorker
    {
        get => _selectedWorker;
        set => this.RaiseAndSetIfChanged(ref _selectedWorker, value);
    }
    public WorkersAndDepartmentsViewModel? SelectedWorkersAndDepartments
    {
        get => _selectedWorkersAndDepartments;
        set => this.RaiseAndSetIfChanged(ref _selectedWorkersAndDepartments, value);
    }
    public WorkersAndJobsViewModel? SelectedWorkersAndJobs
    {
        get => _selectedWorkersAndJobs;
        set => this.RaiseAndSetIfChanged(ref _selectedWorkersAndJobs, value);
    }
    public WorkersAndVacationsViewModel? SelectedWorkersAndVacations
    {
        get => _selectedWorkersAndVacations;
        set => this.RaiseAndSetIfChanged(ref _selectedWorkersAndVacations, value);
    }
    public WorkshopViewModel? SelectedWorkshop
    {
        get => _selectedWorkshop;
        set => this.RaiseAndSetIfChanged(ref _selectedWorkshop, value);
    }


    public ReactiveCommand<Unit, Unit> OnAddDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddJobCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddVacationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddVacationSpotCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddWorkerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddWorkersAndDepartmentsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddWorkersAndJobsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddWorkersAndVacationsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddWorkshopCommand { get; set; }


    public ReactiveCommand<Unit, Unit> OnUpdateDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateJobCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateVacationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateVacationSpotCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateWorkerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateWorkersAndDepartmentsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateWorkersAndJobsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateWorkersAndVacationsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateWorkshopCommand { get; set; }


    public ReactiveCommand<Unit, Unit> OnDeleteDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteJobCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteVacationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteVacationSpotCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteWorkerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteWorkersAndDepartmentsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteWorkersAndJobsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteWorkersAndVacationsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteWorkshopCommand { get; set; }


    public Interaction<DepartmentViewModel, DepartmentViewModel?> ShowDepartmentDialog { get; }
    public Interaction<JobViewModel, JobViewModel?> ShowJobDialog { get; }
    public Interaction<VacationViewModel, VacationViewModel?> ShowVacationDialog { get; }
    public Interaction<VacationSpotViewModel, VacationSpotViewModel?> ShowVacationSpotDialog { get; }
    public Interaction<WorkerViewModel, WorkerViewModel?> ShowWorkerDialog { get; }
    public Interaction<WorkersAndDepartmentsViewModel, WorkersAndDepartmentsViewModel?> ShowWorkersAndDepartmentsDialog { get; }
    public Interaction<WorkersAndJobsViewModel, WorkersAndJobsViewModel?> ShowWorkersAndJobsDialog { get; }
    public Interaction<WorkersAndVacationsViewModel, WorkersAndVacationsViewModel?> ShowWorkersAndVacationsDialog { get; }
    public Interaction<WorkshopViewModel, WorkshopViewModel?> ShowWorkshopDialog { get; }


    public MainViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowDepartmentDialog = new Interaction<DepartmentViewModel, DepartmentViewModel?>();
        ShowJobDialog = new Interaction<JobViewModel, JobViewModel?>();
        ShowVacationDialog = new Interaction<VacationViewModel, VacationViewModel?>();
        ShowVacationSpotDialog = new Interaction<VacationSpotViewModel, VacationSpotViewModel?>();
        ShowWorkerDialog = new Interaction<WorkerViewModel, WorkerViewModel?>();
        ShowWorkersAndDepartmentsDialog = new Interaction<WorkersAndDepartmentsViewModel, WorkersAndDepartmentsViewModel?>();
        ShowWorkersAndJobsDialog = new Interaction<WorkersAndJobsViewModel, WorkersAndJobsViewModel?>();
        ShowWorkersAndVacationsDialog = new Interaction<WorkersAndVacationsViewModel, WorkersAndVacationsViewModel?>();
        ShowWorkshopDialog = new Interaction<WorkshopViewModel, WorkshopViewModel?>();


        OnAddDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(new DepartmentViewModel());
            if (departmentViewModel != null)
            {
                var newDepartment = await _apiClient.AddDepartmentAsync(_mapper.Map<DepartmentPostDto>(departmentViewModel));
                Departments.Add(_mapper.Map<DepartmentViewModel>(newDepartment));
            }
        });
        OnAddJobCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var jobViewModel = await ShowJobDialog.Handle(new JobViewModel());
            if (jobViewModel != null)
            {
                var newJob = await _apiClient.AddJobAsync(_mapper.Map<JobPostDto>(jobViewModel));
                Jobs.Add(_mapper.Map<JobViewModel>(newJob));
            }
        });
        OnAddVacationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vacationViewModel = await ShowVacationDialog.Handle(new VacationViewModel());
            if (vacationViewModel != null)
            {
                var newVacation = await _apiClient.AddVacationAsync(_mapper.Map<VacationPostDto>(vacationViewModel));
                Vacations.Add(_mapper.Map<VacationViewModel>(newVacation));
            }
        });
        OnAddVacationSpotCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vacationSpotViewModel = await ShowVacationSpotDialog.Handle(new VacationSpotViewModel());
            if (vacationSpotViewModel != null)
            {
                var newVacationSpot = await _apiClient.AddVacationSpotAsync(_mapper.Map<VacationSpotPostDto>(vacationSpotViewModel));
                VacationSpots.Add(_mapper.Map<VacationSpotViewModel>(newVacationSpot));
            }
        });
        OnAddWorkerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workerViewModel = await ShowWorkerDialog.Handle(new WorkerViewModel());
            if (workerViewModel != null)
            {
                var newWorker = await _apiClient.AddWorkerAsync(_mapper.Map<WorkerPostDto>(workerViewModel));
                Workers.Add(_mapper.Map<WorkerViewModel>(newWorker));
            }
        });
        OnAddWorkersAndDepartmentsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workersAndDepartmentsViewModel = await ShowWorkersAndDepartmentsDialog.Handle(new WorkersAndDepartmentsViewModel());
            if (workersAndDepartmentsViewModel != null)
            {
                var newWorkersAndDepartments = await _apiClient.AddWorkersAndDepartmentsAsync(_mapper.Map<WorkersAndDepartmentsPostDto>(workersAndDepartmentsViewModel));
                WorkersAndDepartments.Add(_mapper.Map<WorkersAndDepartmentsViewModel>(newWorkersAndDepartments));
            }
        });
        OnAddWorkersAndJobsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workersAndJobsViewModel = await ShowWorkersAndJobsDialog.Handle(new WorkersAndJobsViewModel());
            if (workersAndJobsViewModel != null)
            {
                var newWorkersAndJobs = await _apiClient.AddWorkersAndJobsAsync(_mapper.Map<WorkersAndJobsPostDto>(workersAndJobsViewModel));
                WorkersAndJobs.Add(_mapper.Map<WorkersAndJobsViewModel>(newWorkersAndJobs));
            }
        });
        OnAddWorkersAndVacationsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workersAndVacationsViewModel = await ShowWorkersAndVacationsDialog.Handle(new WorkersAndVacationsViewModel());
            if (workersAndVacationsViewModel != null)
            {
                var newWorkersAndVacations = await _apiClient.AddWorkersAndVacationsAsync(_mapper.Map<WorkersAndVacationsPostDto>(workersAndVacationsViewModel));
                WorkersAndVacations.Add(_mapper.Map<WorkersAndVacationsViewModel>(newWorkersAndVacations));
            }
        });
        OnAddWorkshopCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workshopViewModel = await ShowWorkshopDialog.Handle(new WorkshopViewModel());
            if (workshopViewModel != null)
            {
                var newWorkshop = await _apiClient.AddWorkshopAsync(_mapper.Map<WorkshopPostDto>(workshopViewModel));
                Workshops.Add(_mapper.Map<WorkshopViewModel>(newWorkshop));
            }
        });


        OnUpdateDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(SelectedDepartment!);
            if (departmentViewModel != null)
            {
                await _apiClient.UpdateDepartmentAsync(_selectedDepartment!.Id, _mapper.Map<DepartmentPostDto>(departmentViewModel));
                _mapper.Map(departmentViewModel, SelectedDepartment);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedDepartment).Select(selectedElement => selectedElement != null));
        OnUpdateJobCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var jobViewModel = await ShowJobDialog.Handle(SelectedJob!);
            if (jobViewModel != null)
            {
                await _apiClient.UpdateJobAsync(_selectedJob!.Id, _mapper.Map<JobPostDto>(jobViewModel));
                _mapper.Map(jobViewModel, SelectedJob);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedJob).Select(selectedElement => selectedElement != null));
        OnUpdateVacationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vacationViewModel = await ShowVacationDialog.Handle(SelectedVacation!);
            if (vacationViewModel != null)
            {
                await _apiClient.UpdateVacationAsync(_selectedVacation!.Id, _mapper.Map<VacationPostDto>(vacationViewModel));
                _mapper.Map(vacationViewModel, SelectedVacation);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedVacation).Select(selectedElement => selectedElement != null));
        OnUpdateVacationSpotCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var vacationSpotViewModel = await ShowVacationSpotDialog.Handle(SelectedVacationSpot!);
            if (vacationSpotViewModel != null)
            {
                await _apiClient.UpdateVacationSpotAsync(_selectedVacationSpot!.Id, _mapper.Map<VacationSpotPostDto>(vacationSpotViewModel));
                _mapper.Map(vacationSpotViewModel, SelectedVacationSpot);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedVacationSpot).Select(selectedElement => selectedElement != null));
        OnUpdateWorkerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workerViewModel = await ShowWorkerDialog.Handle(SelectedWorker!);
            if (workerViewModel != null)
            {
                await _apiClient.UpdateWorkerAsync(_selectedWorker!.Id, _mapper.Map<WorkerPostDto>(workerViewModel));
                _mapper.Map(workerViewModel, SelectedWorker);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorker).Select(selectedElement => selectedElement != null));
        OnUpdateWorkersAndDepartmentsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workersAndDepartmentsViewModel = await ShowWorkersAndDepartmentsDialog.Handle(SelectedWorkersAndDepartments!);
            if (workersAndDepartmentsViewModel != null)
            {
                await _apiClient.UpdateWorkersAndDepartmentsAsync(_selectedWorkersAndDepartments!.Id, _mapper.Map<WorkersAndDepartmentsPostDto>(workersAndDepartmentsViewModel));
                _mapper.Map(workersAndDepartmentsViewModel, SelectedWorkersAndDepartments);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorkersAndDepartments).Select(selectedElement => selectedElement != null));
        OnUpdateWorkersAndJobsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workersAndJobsViewModel = await ShowWorkersAndJobsDialog.Handle(SelectedWorkersAndJobs!);
            if (workersAndJobsViewModel != null)
            {
                await _apiClient.UpdateWorkersAndJobsAsync(_selectedWorkersAndJobs!.Id, _mapper.Map<WorkersAndJobsPostDto>(workersAndJobsViewModel));
                _mapper.Map(workersAndJobsViewModel, SelectedWorkersAndJobs);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorkersAndJobs).Select(selectedElement => selectedElement != null));
        OnUpdateWorkersAndVacationsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workersAndVacationsViewModel = await ShowWorkersAndVacationsDialog.Handle(SelectedWorkersAndVacations!);
            if (workersAndVacationsViewModel != null)
            {
                await _apiClient.UpdateWorkersAndVacationsAsync(_selectedWorkersAndVacations!.Id, _mapper.Map<WorkersAndVacationsPostDto>(workersAndVacationsViewModel));
                _mapper.Map(workersAndVacationsViewModel, SelectedWorkersAndVacations);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorkersAndVacations).Select(selectedElement => selectedElement != null));
        OnUpdateWorkshopCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workshopViewModel = await ShowWorkshopDialog.Handle(SelectedWorkshop!);
            if (workshopViewModel != null)
            {
                await _apiClient.UpdateWorkshopAsync(_selectedWorkshop!.Id, _mapper.Map<WorkshopPostDto>(workshopViewModel));
                _mapper.Map(workshopViewModel, SelectedWorkshop);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorkshop).Select(selectedElement => selectedElement != null));


        OnDeleteDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDepartmentAsync(_selectedDepartment!.Id);
            Departments.Remove(SelectedDepartment!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedDepartment).Select(selectedElement => selectedElement != null));
        OnDeleteJobCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteJobAsync(_selectedJob!.Id);
            Jobs.Remove(SelectedJob!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedJob).Select(selectedElement => selectedElement != null));
        OnDeleteVacationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteVacationAsync(_selectedVacation!.Id);
            Vacations.Remove(SelectedVacation!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedVacation).Select(selectedElement => selectedElement != null));
        OnDeleteVacationSpotCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteVacationSpotAsync(_selectedVacationSpot!.Id);
            VacationSpots.Remove(SelectedVacationSpot!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedVacationSpot).Select(selectedElement => selectedElement != null));
        OnDeleteWorkerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteWorkerAsync(_selectedWorker!.Id);
            Workers.Remove(SelectedWorker!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorker).Select(selectedElement => selectedElement != null));
        OnDeleteWorkersAndDepartmentsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteWorkersAndDepartmentsAsync(_selectedWorkersAndDepartments!.Id);
            WorkersAndDepartments.Remove(SelectedWorkersAndDepartments!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorkersAndDepartments).Select(selectedElement => selectedElement != null));
        OnDeleteWorkersAndJobsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteWorkersAndJobsAsync(_selectedWorkersAndJobs!.Id);
            WorkersAndJobs.Remove(SelectedWorkersAndJobs!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorkersAndJobs).Select(selectedElement => selectedElement != null));
        OnDeleteWorkersAndVacationsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteWorkersAndVacationsAsync(_selectedWorkersAndVacations!.Id);
            WorkersAndVacations.Remove(SelectedWorkersAndVacations!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorkersAndVacations).Select(selectedElement => selectedElement != null));
        OnDeleteWorkshopCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteWorkshopAsync(_selectedWorkshop!.Id);
            Workshops.Remove(SelectedWorkshop!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorkshop).Select(selectedElement => selectedElement != null));


        RxApp.MainThreadScheduler.Schedule(LoadDatabaseAsync);
    }


    private async void LoadDatabaseAsync()
    {
        var departments = await _apiClient.GetDepartmentsAsync();
        foreach (var department in departments)
            Departments.Add(_mapper.Map<DepartmentViewModel>(department));

        var jobs = await _apiClient.GetJobsAsync();
        foreach (var job in jobs)
            Jobs.Add(_mapper.Map<JobViewModel>(job));

        var vacations = await _apiClient.GetVacationsAsync();
        foreach (var vacation in vacations)
            Vacations.Add(_mapper.Map<VacationViewModel>(vacation));

        var vacationSpots = await _apiClient.GetVacationSpotsAsync();
        foreach (var vacationSpot in vacationSpots)
            VacationSpots.Add(_mapper.Map<VacationSpotViewModel>(vacationSpot));

        var workers = await _apiClient.GetWorkersAsync();
        foreach (var worker in workers)
            Workers.Add(_mapper.Map<WorkerViewModel>(worker));

        var workersAndDepartments = await _apiClient.GetWorkersAndDepartmentsAsync();
        foreach (var workerAndDepartment in workersAndDepartments)
            WorkersAndDepartments.Add(_mapper.Map<WorkersAndDepartmentsViewModel>(workerAndDepartment));

        var workersAndJobs = await _apiClient.GetWorkersAndJobsAsync();
        foreach (var workerAndJob in workersAndJobs)
            WorkersAndJobs.Add(_mapper.Map<WorkersAndJobsViewModel>(workerAndJob));

        var workersAndVacations = await _apiClient.GetWorkersAndVacationsAsync();
        foreach (var workerAndVacation in workersAndVacations)
            WorkersAndVacations.Add(_mapper.Map<WorkersAndVacationsViewModel>(workerAndVacation));

        var workshops = await _apiClient.GetWorkshopsAsync();
        foreach (var workshop in workshops)
            Workshops.Add(_mapper.Map<WorkshopViewModel>(workshop));
    }
}
