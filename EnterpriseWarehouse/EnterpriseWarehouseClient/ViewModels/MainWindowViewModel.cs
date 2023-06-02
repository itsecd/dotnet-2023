using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace EnterpriseWarehouseClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ProductViewModel> Products { get; } = new();

    private ProductViewModel? _selectedProduct;
    public ProductViewModel? SelectedProduct
    {
        get => _selectedProduct;
        set => this.RaiseAndSetIfChanged(ref _selectedProduct, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<ProductViewModel, ProductViewModel?> ShowProductDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowProductDialog = new Interaction<ProductViewModel, ProductViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(new ProductViewModel());
            if (productViewModel != null)
            {
                var newProduct = await _apiClient.AddProductAsync(_mapper.Map<ProductPostDto>(productViewModel));
                Products.Add(_mapper.Map<ProductViewModel>(newProduct));
            }
        });

        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(SelectedProduct!);
            if (productViewModel != null)
            {
                await _apiClient.UpdateProductAsync(SelectedProduct!.Id, _mapper.Map<ProductPostDto>(productViewModel));
                _mapper.Map(productViewModel, SelectedProduct);
            }
        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selectedProduct => selectedProduct != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(SelectedProduct!);
            if (productViewModel != null)
            {
                await _apiClient.DeleteProductAsync(SelectedProduct!.Id);
                Products.Remove(SelectedProduct);
            }
        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selectedProduct => selectedProduct != null));

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
