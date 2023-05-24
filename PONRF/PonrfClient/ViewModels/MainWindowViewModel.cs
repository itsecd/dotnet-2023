using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace PonrfClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<PrivatizedBuildingViewModel> PrivatizedBuildings { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadPrivatizedBuildingAsync);
    }

    private async void LoadPrivatizedBuildingAsync()
    {
        var privatizedBuildings = await _apiClient.GetPrivatizedBuildingAsync();
        foreach (var privatizedBuilding in privatizedBuildings)
        {
            PrivatizedBuildings.Add(_mapper.Map<PrivatizedBuildingViewModel>(privatizedBuilding));
        }
    }
}
