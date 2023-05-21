using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace Fabrics.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<FabricViewModel> Fabrics { get; } = new ();   

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;
    public ObservableCollection<ProviderViewModel> Providers { get; } = new ();   
    public ObservableCollection<ShipmentViewModel> Shipments { get; } = new ();   

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadFabricAsync);
    }

    private async void LoadFabricAsync()
    {
        var fabrics = await _apiClient.GetFabricAsync();
        foreach(var fabric in fabrics)
        {
            Fabrics.Add(_mapper.Map<FabricViewModel>(fabric));
        }
    }
}
