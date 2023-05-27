using AutoMapper;
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

    public DepartmentViewModel? _selectedDepartment;
    public DepartmentViewModel? SelectedDepartment
    {
        get => _selectedDepartment;
        set => this.RaiseAndSetIfChanged(ref _selectedDepartment, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<DepartmentViewModel, DepartmentViewModel?> ShowDepartmentDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowDepartmentDialog = new Interaction<DepartmentViewModel, DepartmentViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(new DepartmentViewModel());
            if (departmentViewModel != null)
            {
                var newDepartment = await _apiClient.AddDepartmentAsync(
                    _mapper.Map<PostDepartmentDto>(departmentViewModel));
                Departments.Add(_mapper.Map<DepartmentViewModel>(newDepartment));
            }
        });

        OnAddCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
        });


        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
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

        OnChangeCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
        });

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDepartmentAsync(_selectedDepartment!.Id);
            Departments.Remove(SelectedDepartment!);
        }, this.WhenAnyValue(viewModel => viewModel.SelectedDepartment)
        .Select(selectProduct => selectProduct != null));

        OnDeleteCommand.ThrownExceptions.Subscribe(error => {
            var messageViewModel = new MessageViewModel(error.Message);
            ShowMessage(messageViewModel);
        });

        RxApp.MainThreadScheduler.Schedule(LoadDepartmentsAsync);
    }

    private async void LoadDepartmentsAsync()
    {
        var departments = await _apiClient.GetDepartmentsAsync();
        foreach (var department in departments)
        {
            Departments.Add(_mapper.Map<DepartmentViewModel>(department));
        }
    }
}
