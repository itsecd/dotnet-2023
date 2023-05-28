using AutoMapper;
using DynamicData;
using Microsoft.CodeAnalysis.Operations;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Organization.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<DepartmentViewModel> Departments { get; } = new();

    public ObservableCollection<WorkshopViewModel> Workshops { get; } = new();

    public ObservableCollection<EmployeeViewModel> Employees { get; } = new();

    public DepartmentViewModel? _selectedDepartment;
    public DepartmentViewModel? SelectedDepartment
    {
        get => _selectedDepartment;
        set => this.RaiseAndSetIfChanged(ref _selectedDepartment, value);
    }

    public WorkshopViewModel? _selectedWorkshop;
    public WorkshopViewModel? SelectedWorkshop
    {
        get => _selectedWorkshop;
        set => this.RaiseAndSetIfChanged(ref _selectedWorkshop, value);
    }

    public EmployeeViewModel? _selectedEmployee;
    public EmployeeViewModel? SelectedEmployee
    {
        get => _selectedEmployee;
        set => this.RaiseAndSetIfChanged(ref _selectedEmployee, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteDepartmentCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddWorkshopCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeWorkshopCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteWorkshopCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddEmployeeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeEmployeeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteEmployeeCommand { get; set; }

    public Interaction<DepartmentViewModel, DepartmentViewModel?> ShowDepartmentDialog { get; }

    public Interaction<WorkshopViewModel, WorkshopViewModel?> ShowWorkshopDialog { get; }

    public Interaction<EmployeeViewModel, EmployeeViewModel?> ShowEmployeeDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowDepartmentDialog = new Interaction<DepartmentViewModel, DepartmentViewModel?>();

        ShowWorkshopDialog = new Interaction<WorkshopViewModel, WorkshopViewModel?>();

        ShowEmployeeDialog = new Interaction<EmployeeViewModel, EmployeeViewModel?>();

        OnAddDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(new DepartmentViewModel());
            if (departmentViewModel != null)
            {
                var newDepartment = await _apiClient.AddDepartmentAsync(
                    _mapper.Map<PostDepartmentDto>(departmentViewModel));
                Departments.Add(_mapper.Map<DepartmentViewModel>(newDepartment));
            }
        });

        OnAddDepartmentCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(ReloadData);
        });


        OnChangeDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(SelectedDepartment!);
            if (departmentViewModel != null)
            {
                var newDepartment = await _apiClient.UpdateDepartmentAsync(_selectedDepartment!.Id,
                    _mapper.Map<PostDepartmentDto>(departmentViewModel));
                _mapper.Map(departmentViewModel, SelectedDepartment);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedDepartment)
        .Select(selectProduct => selectProduct != null));

        OnChangeDepartmentCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(ReloadData);
        });

        OnDeleteDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDepartmentAsync(_selectedDepartment!.Id);
            Departments.Remove(SelectedDepartment!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedDepartment)
        .Select(selectProduct => selectProduct != null));

        OnDeleteDepartmentCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(ReloadData);
        });



        OnAddWorkshopCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workshopViewModel = await ShowWorkshopDialog.Handle(new WorkshopViewModel());
            if (workshopViewModel != null)
            {
                var newWorkshop = await _apiClient.AddWorkshopAsync(
                    _mapper.Map<PostWorkshopDto>(workshopViewModel));
                Workshops.Add(_mapper.Map<WorkshopViewModel>(newWorkshop));
            }
        });

        OnAddWorkshopCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(ReloadData);
        });


        OnChangeWorkshopCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var workshopViewModel = await ShowWorkshopDialog.Handle(SelectedWorkshop!);
            if (workshopViewModel != null)
            {
                var newWorkshop = await _apiClient.UpdateWorkshopAsync(_selectedWorkshop!.Id,
                    _mapper.Map<PostWorkshopDto>(workshopViewModel));
                _mapper.Map(workshopViewModel, SelectedWorkshop);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorkshop)
        .Select(selectProduct => selectProduct != null));

        OnChangeWorkshopCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(ReloadData);
        });

        OnDeleteWorkshopCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteWorkshopAsync(_selectedWorkshop!.Id);
            Workshops.Remove(SelectedWorkshop!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedWorkshop)
        .Select(selectProduct => selectProduct != null));

        OnDeleteWorkshopCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(ReloadData);
        });


        OnAddEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var employeeViewModel = await ShowEmployeeDialog.Handle(new EmployeeViewModel());
            if (employeeViewModel != null)
            {
                var newEmployee = await _apiClient.AddEmployeeAsync(
                    _mapper.Map<PostEmployeeDto>(employeeViewModel));
                Employees.Add(_mapper.Map<EmployeeViewModel>(newEmployee));
            }
        });

        OnAddEmployeeCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(ReloadData);
        });


        OnChangeEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var employeeViewModel = await ShowEmployeeDialog.Handle(SelectedEmployee!);
            if (employeeViewModel != null)
            {
                var newEmployee = await _apiClient.UpdateEmployeeAsync(
                    (int)_selectedEmployee!.Id,
                    _mapper.Map<PostEmployeeDto>(employeeViewModel));
                _mapper.Map(employeeViewModel, SelectedEmployee);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedEmployee)
        .Select(selectProduct => selectProduct != null));

        OnChangeEmployeeCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(ReloadData);
        });

        OnDeleteEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteEmployeeAsync((int)_selectedEmployee!.Id);
            Employees.Remove(SelectedEmployee!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedEmployee)
        .Select(selectProduct => selectProduct != null));

        OnDeleteEmployeeCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(ReloadData);
        });

        RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
    }

    private async void LoadDatabaseDataAsync()
    {
        var departments = await _apiClient.GetDepartmentsAsync();
        foreach (var department in departments)
        {
            Departments.Add(_mapper.Map<DepartmentViewModel>(department));
        }
        var employees = await _apiClient.GetEmployeesAsync();
        foreach (var employee in employees)
        {
            Employees.Add(_mapper.Map<EmployeeViewModel>(employee));
        }

        var workshops = await _apiClient.GetWorkshopsAsync();
        foreach (var workshop in workshops)
        {
            Workshops.Add(_mapper.Map<WorkshopViewModel>(workshop));
        }
    }

    private async void ReloadData()
    {
        Departments.Clear();
        Employees.Clear();
        Workshops.Clear();
        var departments = await _apiClient.GetDepartmentsAsync();
        foreach (var department in departments)
        {
            Departments.Add(_mapper.Map<DepartmentViewModel>(department));
        }
        var employees = await _apiClient.GetEmployeesAsync();
        foreach (var employee in employees)
        {
            Employees.Add(_mapper.Map<EmployeeViewModel>(employee));
        }

        var workshops = await _apiClient.GetWorkshopsAsync();
        foreach (var workshop in workshops)
        {
            Workshops.Add(_mapper.Map<WorkshopViewModel>(workshop));
        }
    }
}
