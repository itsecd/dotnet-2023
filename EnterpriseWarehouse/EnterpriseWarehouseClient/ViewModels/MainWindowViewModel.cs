using AutoMapper;
using EnterpriseWarehouse.Client;
using EnterpriseWarehouse.Client.ViewModels;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace EnterpriseWarehouseClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ProductViewModel> Products { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadProductsAsync);
    }

    private async void LoadProductsAsync()
    {
        var products = await _apiClient.GetProductsAsync();
        foreach (var product in products)
        {
            Products.Add(_mapper.Map<ProductViewModel>(product));
        }
    }
}
