using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace PharmacyCityNetwork.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ProductViewModel> Products { get; } = new();
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;
    public ReactiveCommand<Unit, Unit> OnAddComand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeComand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteComand { get; set; }
    public Interaction<ProductViewModel, ProductViewModel?> ShowProductDialog { get; }
    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();
        ShowProductDialog = new Interaction<ProductViewModel, ProductViewModel?>();

        OnAddComand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(new ProductViewModel());
            if (productViewModel != null)
            {
                var newProduct = _mapper.Map<ProductPostDto>(productViewModel);
                await _apiClient.AddProductAsync(newProduct);
                Products.Add(productViewModel);
                Products.Clear();
            }
        });

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