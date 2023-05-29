using AutoMapper;
using Avalonia.Controls;
using DynamicData;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace TransportMgmt.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<DriverViewModel> Drivers { get; } = new();

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
                var newDriver = await _apiClient.AddDriversAsync(_mapper.Map<DriverPostDto>(driverViewModel));
                Drivers.Add(_mapper.Map<DriverViewModel>(newDriver));
            }
        });

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
