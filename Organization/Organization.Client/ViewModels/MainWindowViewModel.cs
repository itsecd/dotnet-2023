﻿using AutoMapper;
using DynamicData;
using Microsoft.CodeAnalysis.Operations;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Organization.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<DepartmentEmployeeViewModel> DepartmentEmployees { get; } = new();

    public ObservableCollection<DepartmentViewModel> Departments { get; } = new();

    public ObservableCollection<EmployeeOccupationViewModel> EmployeeOccupations { get; } = new();

    public ObservableCollection<EmployeeViewModel> Employees { get; } = new();

    public ObservableCollection<EmployeeVacationVoucherViewModel> EmployeeVacationVouchers { get; } = new();

    public ObservableCollection<VoucherTypeViewModel> VoucherTypes { get; } = new();

    public ObservableCollection<WorkshopViewModel> Workshops { get; } = new();

    public DepartmentEmployeeViewModel? _selectedDepartmentEmployee;
    public DepartmentEmployeeViewModel? SelectedDepartmentEmployee
    {
        get => _selectedDepartmentEmployee;
        set => this.RaiseAndSetIfChanged(ref _selectedDepartmentEmployee, value);
    }

    public DepartmentViewModel? _selectedDepartment;
    public DepartmentViewModel? SelectedDepartment
    {
        get => _selectedDepartment;
        set => this.RaiseAndSetIfChanged(ref _selectedDepartment, value);
    }

    public EmployeeOccupationViewModel? _selectedEmployeeOccupation;
    public EmployeeOccupationViewModel? SelectedEmployeeOccupation
    {
        get => _selectedEmployeeOccupation;
        set => this.RaiseAndSetIfChanged(ref _selectedEmployeeOccupation, value);
    }

    public EmployeeViewModel? _selectedEmployee;
    public EmployeeViewModel? SelectedEmployee
    {
        get => _selectedEmployee;
        set => this.RaiseAndSetIfChanged(ref _selectedEmployee, value);
    }

    public EmployeeVacationVoucherViewModel? _selectedEmployeeVacationVoucher;
    public EmployeeVacationVoucherViewModel? SelectedEmployeeVacationVoucher
    {
        get => _selectedEmployeeVacationVoucher;
        set => this.RaiseAndSetIfChanged(ref _selectedEmployeeVacationVoucher, value);
    }

    public VoucherTypeViewModel? _selectedVoucherType;
    public VoucherTypeViewModel? SelectedVoucherType
    {
        get => _selectedVoucherType;
        set => this.RaiseAndSetIfChanged(ref _selectedVoucherType, value);
    }

    public WorkshopViewModel? _selectedWorkshop;
    public WorkshopViewModel? SelectedWorkshop
    {
        get => _selectedWorkshop;
        set => this.RaiseAndSetIfChanged(ref _selectedWorkshop, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;
    public ReactiveCommand<Unit, Unit> OnAddDepartmentEmployeeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeDepartmentEmployeeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteDepartmentEmployeeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteDepartmentCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddEmployeeOccupationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeEmployeeOccupationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteEmployeeOccupationCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddEmployeeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeEmployeeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteEmployeeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddEmployeeVacationVoucherCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeEmployeeVacationVoucherCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteEmployeeVacationVoucherCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddVoucherTypeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeVoucherTypeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteVoucherTypeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddWorkshopCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeWorkshopCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteWorkshopCommand { get; set; }

    public Interaction<DepartmentEmployeeViewModel, 
        DepartmentEmployeeViewModel?> ShowDepartmentEmployeeDialog { get; }

    public Interaction<DepartmentViewModel, DepartmentViewModel?> ShowDepartmentDialog { get; }

    public Interaction<EmployeeOccupationViewModel, 
        EmployeeOccupationViewModel?> ShowEmployeeOccupationDialog { get; }

    public Interaction<EmployeeViewModel, EmployeeViewModel?> ShowEmployeeDialog { get; }

    public Interaction<EmployeeVacationVoucherViewModel, 
        EmployeeVacationVoucherViewModel?> ShowEmployeeVacationVoucherDialog { get; }

    public Interaction<VoucherTypeViewModel, VoucherTypeViewModel?> ShowVoucherTypeDialog { get; }

    public Interaction<WorkshopViewModel, WorkshopViewModel?> ShowWorkshopDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowDepartmentEmployeeDialog = 
            new Interaction<DepartmentEmployeeViewModel, DepartmentEmployeeViewModel?>();

        ShowDepartmentDialog = new Interaction<DepartmentViewModel, DepartmentViewModel?>();

        ShowEmployeeOccupationDialog = 
            new Interaction<EmployeeOccupationViewModel, EmployeeOccupationViewModel?>();

        ShowEmployeeDialog = new Interaction<EmployeeViewModel, EmployeeViewModel?>();

        ShowEmployeeVacationVoucherDialog = 
            new Interaction<EmployeeVacationVoucherViewModel, EmployeeVacationVoucherViewModel?>();

        ShowVoucherTypeDialog = new Interaction<VoucherTypeViewModel, VoucherTypeViewModel?>();

        ShowWorkshopDialog = new Interaction<WorkshopViewModel, WorkshopViewModel?>();

        OnAddDepartmentEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentEmployeeViewModel = await ShowDepartmentEmployeeDialog
                .Handle(new DepartmentEmployeeViewModel());
            if (departmentEmployeeViewModel != null)
            {
                var newDepartmentEmployee = await _apiClient.AddDepartmentEmployeeAsync(
                    _mapper.Map<PostDepartmentEmployeeDto>(departmentEmployeeViewModel));
                DepartmentEmployees.Add(_mapper.Map<DepartmentEmployeeViewModel>(newDepartmentEmployee));
            }
        });

        OnAddDepartmentEmployeeCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });

        OnChangeDepartmentEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentEmployeeViewModel = await ShowDepartmentEmployeeDialog
                .Handle(SelectedDepartmentEmployee!);
            if (departmentEmployeeViewModel != null)
            {
                var newDepartmentEmployee = await _apiClient.UpdateDepartmentEmployeeAsync
                    (_selectedDepartmentEmployee!.Id,
                    _mapper.Map<PostDepartmentEmployeeDto>(departmentEmployeeViewModel));
                
                _mapper.Map(departmentEmployeeViewModel, SelectedDepartmentEmployee);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedDepartmentEmployee)
        .Select(selectProduct => selectProduct != null));

        OnChangeDepartmentEmployeeCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });

        OnDeleteDepartmentEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDepartmentEmployeeAsync(_selectedDepartmentEmployee!.Id);
            DepartmentEmployees.Remove(SelectedDepartmentEmployee!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedDepartmentEmployee)
        .Select(selectProduct => selectProduct != null));

        OnDeleteDepartmentEmployeeCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });

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
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
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
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
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
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });


        OnAddEmployeeOccupationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var employeeOccupationViewModel = await ShowEmployeeOccupationDialog
                .Handle(new EmployeeOccupationViewModel());
            if (employeeOccupationViewModel != null)
            {
                var newEmployeeOccupation = await _apiClient.AddEmployeeOccupationAsync(
                    _mapper.Map<PostEmployeeOccupationDto>(employeeOccupationViewModel));
                EmployeeOccupations.Add(_mapper.Map<EmployeeOccupationViewModel>(newEmployeeOccupation));
            }
        });

        OnAddEmployeeOccupationCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });


        OnChangeEmployeeOccupationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var employeeOccupationViewModel = await ShowEmployeeOccupationDialog
                .Handle(SelectedEmployeeOccupation!);
            if (employeeOccupationViewModel != null)
            {
                var newEmployeeOccupation = await _apiClient.UpdateEmployeeOccupationAsync(
                    _selectedEmployeeOccupation!.Id,
                    _mapper.Map<PostEmployeeOccupationDto>(employeeOccupationViewModel));
                _mapper.Map(employeeOccupationViewModel, SelectedEmployeeOccupation);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedEmployeeOccupation)
        .Select(selectProduct => selectProduct != null));

        OnChangeEmployeeOccupationCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });

        OnDeleteEmployeeOccupationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteEmployeeOccupationAsync(_selectedEmployeeOccupation!.Id);
            EmployeeOccupations.Remove(SelectedEmployeeOccupation!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedEmployeeOccupation)
        .Select(selectProduct => selectProduct != null));

        OnDeleteEmployeeOccupationCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
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
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
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
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
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
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });


        OnAddEmployeeVacationVoucherCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var employeeVacationVoucherViewModel = 
                await ShowEmployeeVacationVoucherDialog.Handle(new EmployeeVacationVoucherViewModel());
            if (employeeVacationVoucherViewModel != null)
            {
                var newEmployeeVacationVoucher = await _apiClient.AddEmployeeVacationVoucherAsync(
                    _mapper.Map<PostEmployeeVacationVoucherDto>(employeeVacationVoucherViewModel));
                EmployeeVacationVouchers.Add
                    (_mapper.Map<EmployeeVacationVoucherViewModel>(newEmployeeVacationVoucher));
            }
        });

        OnAddEmployeeVacationVoucherCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });


        OnChangeEmployeeVacationVoucherCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var employeeVacationVoucherViewModel = await ShowEmployeeVacationVoucherDialog
            .Handle(SelectedEmployeeVacationVoucher!);
            if (employeeVacationVoucherViewModel != null)
            {
                var newEmployeeVacationVoucher = await _apiClient.UpdateEmployeeVacationVoucherAsync(
                    _selectedEmployeeVacationVoucher!.Id,
                    _mapper.Map<PostEmployeeVacationVoucherDto>(employeeVacationVoucherViewModel));
                _mapper.Map(employeeVacationVoucherViewModel, SelectedEmployeeVacationVoucher);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedEmployeeVacationVoucher)
        .Select(selectProduct => selectProduct != null));

        OnChangeEmployeeVacationVoucherCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });


        OnDeleteEmployeeVacationVoucherCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteEmployeeVacationVoucherAsync(_selectedEmployeeVacationVoucher!.Id);
            EmployeeVacationVouchers.Remove(SelectedEmployeeVacationVoucher!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedEmployeeVacationVoucher)
        .Select(selectProduct => selectProduct != null));

        OnDeleteEmployeeVacationVoucherCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });


        OnAddVoucherTypeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var voucherTypeViewModel = await ShowVoucherTypeDialog.Handle(new VoucherTypeViewModel());
            if (voucherTypeViewModel != null)
            {
                var newVoucherType = await _apiClient.AddVoucherTypeAsync(
                    _mapper.Map<PostVoucherTypeDto>(voucherTypeViewModel));
                VoucherTypes.Add(_mapper.Map<VoucherTypeViewModel>(newVoucherType));
            }
        });

        OnAddVoucherTypeCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });


        OnChangeVoucherTypeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var voucherTypeViewModel = await ShowVoucherTypeDialog.Handle(SelectedVoucherType!);
            if (voucherTypeViewModel != null)
            {
                var newVoucherType = await _apiClient.UpdateVoucherTypeAsync(_selectedVoucherType!.Id,
                    _mapper.Map<PostVoucherTypeDto>(voucherTypeViewModel));
                _mapper.Map(voucherTypeViewModel, SelectedVoucherType);
            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedVoucherType)
        .Select(selectProduct => selectProduct != null));

        OnChangeVoucherTypeCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });

        OnDeleteVoucherTypeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteVoucherTypeAsync(_selectedVoucherType!.Id);
            VoucherTypes.Remove(SelectedVoucherType!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedVoucherType)
        .Select(selectProduct => selectProduct != null));

        OnDeleteVoucherTypeCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
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
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
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
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
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
            RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
        });

        RxApp.MainThreadScheduler.Schedule(LoadDatabaseDataAsync);
    }

    private async void LoadDatabaseDataAsync()
    {
        DepartmentEmployees.Clear();
        Departments.Clear();
        EmployeeOccupations.Clear();
        Employees.Clear();
        EmployeeVacationVouchers.Clear();
        VoucherTypes.Clear();
        Workshops.Clear();

        var departmentEmployees = await _apiClient.GetDepartmentEmployeesAsync();
        foreach (var departmentEmployee in departmentEmployees)
        {
            DepartmentEmployees.Add(_mapper.Map<DepartmentEmployeeViewModel>(departmentEmployee));
        }

        var departments = await _apiClient.GetDepartmentsAsync();
        foreach (var department in departments)
        {
            Departments.Add(_mapper.Map<DepartmentViewModel>(department));
        }

        var employeeOccupations = await _apiClient.GetEmployeeOccupationsAsync();
        foreach (var employeeOccupation in employeeOccupations)
        {
            EmployeeOccupations.Add(_mapper.Map<EmployeeOccupationViewModel>(employeeOccupation));
        }

        var employees = await _apiClient.GetEmployeesAsync();
        foreach (var employee in employees)
        {
            Employees.Add(_mapper.Map<EmployeeViewModel>(employee));
        }

        var employeeVacationVouchers = await _apiClient.GetEmployeeVacationVouchersAsync();
        foreach (var employeeVacationVoucher in employeeVacationVouchers)
        {
            EmployeeVacationVouchers
                .Add(_mapper.Map<EmployeeVacationVoucherViewModel>(employeeVacationVoucher));
        }

        var voucherTypes = await _apiClient.GetVoucherTypesAsync();
        foreach (var voucherType in voucherTypes)
        {
            VoucherTypes.Add(_mapper.Map<VoucherTypeViewModel>(voucherType));
        }

        var workshops = await _apiClient.GetWorkshopsAsync();
        foreach (var workshop in workshops)
        {
            Workshops.Add(_mapper.Map<WorkshopViewModel>(workshop));
        }
    }
}
