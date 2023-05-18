using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using AutoMapper;
using ReactiveUI;
using Splat;

namespace Taxi.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<DriverViewModel> Drivers { get; } = new();

    private DriverViewModel? _selectedDriver;

    public DriverViewModel? SelectedDriver
    {
        get => _selectedDriver;
        set => this.RaiseAndSetIfChanged(ref _selectedDriver, value);
    }
    
    private readonly ApiWrapper _apiClient;
    
    private readonly IMapper _mapper;
    
    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }
    
    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }
    
    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }
    
    public Interaction<DriverViewModel, DriverViewModel?> ShowDriverDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowDriverDialog = new Interaction<DriverViewModel, DriverViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(new DriverViewModel());
            if (driverViewModel != null)
            {
                var newDriver = await _apiClient.AddDriverAsync(_mapper.Map<DriverSetDto>(driverViewModel));
                Drivers.Add(_mapper.Map<DriverViewModel>(newDriver));
            }
        });

        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var driverViewModel = await ShowDriverDialog.Handle(SelectedDriver!);
            if (driverViewModel != null)
            {
                await _apiClient.UpdateDriverAsync(SelectedDriver!.Id, _mapper.Map<DriverSetDto>(driverViewModel));
                _mapper.Map(driverViewModel, SelectedDriver);
            }
        }, this.WhenAnyValue(vm => vm.SelectedDriver).Select(selectedDriver => selectedDriver != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDriverAsync(SelectedDriver!.Id);
            Drivers.Remove(SelectedDriver);
        }, this.WhenAnyValue(vm => vm.SelectedDriver).
            Select(selectedDriver => selectedDriver != null));

        
        RxApp.MainThreadScheduler.Schedule(LoadDriversAsync);
    }

    private async void LoadDriversAsync()
    {
        var drivers = await _apiClient.GetDriversAsync();
        foreach (var driver in drivers)
        {
            Drivers.Add(_mapper.Map<DriverViewModel>(driver));
        }
    }
}