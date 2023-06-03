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

    public ObservableCollection<StorageCellViewModel> StorageCells { get; } = new();

    private ProductViewModel? _selectedProduct;
    public ProductViewModel? SelectedProduct
    {
        get => _selectedProduct;
        set => this.RaiseAndSetIfChanged(ref _selectedProduct, value);
    }

    private StorageCellViewModel? _selectedStorageCell;
    public StorageCellViewModel? SelectedStorageCell
    {
        get => _selectedStorageCell;
        set => this.RaiseAndSetIfChanged(ref _selectedStorageCell, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnProductAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnProductChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnProductDeleteCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnStorageCellAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnStorageCellChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnStorageCellDeleteCommand { get; set; }

    public Interaction<ProductViewModel, ProductViewModel?> ShowProductDialog { get; }

    public Interaction<StorageCellViewModel, StorageCellViewModel?> ShowStorageCellDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowProductDialog = new Interaction<ProductViewModel, ProductViewModel?>();
        ShowStorageCellDialog = new Interaction<StorageCellViewModel, StorageCellViewModel?>();

        OnProductAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(new ProductViewModel());
            if (productViewModel != null)
            {
                var newProduct = await _apiClient.AddProductAsync(_mapper.Map<ProductPostDto>(productViewModel));
                Products.Add(productViewModel);
            }
        });

        OnProductChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(SelectedProduct!);
            if (productViewModel != null)
            {
                await _apiClient.UpdateProductAsync(SelectedProduct!.ItemNumber, _mapper.Map<ProductPostDto>(productViewModel));
                _mapper.Map(productViewModel, SelectedProduct);
            }
        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selectedProduct => selectedProduct != null));

        OnProductDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(SelectedProduct!);
            if (productViewModel != null)
            {
                await _apiClient.DeleteProductAsync(SelectedProduct!.ItemNumber);
                Products.Remove(SelectedProduct);
            }
        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selectedProduct => selectedProduct != null));

        OnStorageCellAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var storageCellViewModel = await ShowStorageCellDialog.Handle(new StorageCellViewModel());
            if (storageCellViewModel != null)
            {
                var newProduct = await _apiClient.AddStorageCellAsync(_mapper.Map<StorageCellPostDto>(storageCellViewModel));
                StorageCells.Add(storageCellViewModel);
            }
        });

        OnStorageCellChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var storageCellViewModel = await ShowStorageCellDialog.Handle(SelectedStorageCell!);
            if (storageCellViewModel != null)
            {
                await _apiClient.UpdateStorageCellAsync(SelectedStorageCell!.Number, _mapper.Map<StorageCellPostDto>(storageCellViewModel));
                _mapper.Map(storageCellViewModel, SelectedStorageCell);
            }
        }, this.WhenAnyValue(vm => vm.SelectedStorageCell).Select(selectedStorageCell => selectedStorageCell != null));

        OnStorageCellDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var storageCellViewModel = await ShowStorageCellDialog.Handle(SelectedStorageCell!);
            if (storageCellViewModel != null)
            {
                await _apiClient.DeleteStorageCellAsync(SelectedStorageCell!.Number);
                StorageCells.Remove(SelectedStorageCell);
            }
        }, this.WhenAnyValue(vm => vm.SelectedStorageCell).Select(selectedStorageCell => selectedStorageCell != null));

        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }

    private async void LoadDataAsync()
    {
        var products = await _apiClient.GetProductsAsync();
        foreach (var product in products)
        {
            Products.Add(_mapper.Map<ProductViewModel>(product));
        }
        var storageCells = await _apiClient.GetStorageCellsAsync();
        foreach (var storageCell in storageCells)
        {
            StorageCells.Add(_mapper.Map<StorageCellViewModel>(storageCell));
        }
    }
}
