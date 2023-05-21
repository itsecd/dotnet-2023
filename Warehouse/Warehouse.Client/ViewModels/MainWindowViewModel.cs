using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using AutoMapper;
using ReactiveUI;
using Splat;

namespace Warehouse.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ObservableCollection<ProductViewModel> Products { get; } = new();
    public ObservableCollection<SupplyViewModel> Supplies { get; } = new();
    public ObservableCollection<WarehouseCellViewModel> Cells { get; } = new();
    public ObservableCollection<ProductViewModel> AllProducts { get; } = new();

    private ProductViewModel? _selectedProduct;
    public ProductViewModel? SelectedProduct
    {
        get => _selectedProduct;
        set => this.RaiseAndSetIfChanged(ref _selectedProduct, value);
    }

    private SupplyViewModel? _selectedSupply;
    public SupplyViewModel? SelectedSupply
    {
        get => _selectedSupply;
        set => this.RaiseAndSetIfChanged(ref _selectedSupply, value);
    }

    private WarehouseCellViewModel? _selectedCell;
    public WarehouseCellViewModel? SelectedCell
    {
        get => _selectedCell;
        set => this.RaiseAndSetIfChanged(ref _selectedCell, value);
    }

    public ReactiveCommand<Unit, Unit> OnAddProductCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditProductCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteProductCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddSupplyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditSupplyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteSupplyCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddWarehouseCellCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditWarehouseCellCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteWarehouseCellCommand { get; set; }

    public Interaction<ProductViewModel, ProductViewModel?> ShowProductDialog { get; }
    public Interaction<SupplyViewModel, SupplyViewModel?> ShowSupplyDialog { get; }
    public Interaction<WarehouseCellViewModel, WarehouseCellViewModel?> ShowWarehouseCellDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowProductDialog = new Interaction<ProductViewModel, ProductViewModel?>();
        ShowSupplyDialog = new Interaction<SupplyViewModel, SupplyViewModel?>();
        ShowWarehouseCellDialog = new Interaction<WarehouseCellViewModel, WarehouseCellViewModel?>();

        OnAddProductCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(new ProductViewModel());
            if (productViewModel != null)
            {
                await _apiClient.AddProductAsync(_mapper.Map<ProductsPostDto>(productViewModel));
                _mapper.Map(productViewModel, SelectedProduct);
            }
        });

        OnEditProductCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(SelectedProduct!);
            if (productViewModel != null)
            {
                await _apiClient.UpdateProductAsync(SelectedProduct!.Id, _mapper.Map<ProductsPostDto>(productViewModel));
                _mapper.Map(productViewModel, SelectedProduct);
            }
        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selectProduct => selectProduct != null));

        OnDeleteProductCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteProductAsync(SelectedProduct!.Id);
            Products.Remove(SelectedProduct);
        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selectProduct => selectProduct != null));

        OnAddSupplyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var supplyViewModel = await ShowSupplyDialog.Handle(new SupplyViewModel());
            if (supplyViewModel != null)
            {
                await _apiClient.AddSupplyAsync(_mapper.Map<SuppliesPostDto>(supplyViewModel));
                _mapper.Map(supplyViewModel, SelectedSupply);
            }
        });

        OnEditSupplyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var supplyViewModel = await ShowSupplyDialog.Handle(SelectedSupply!);
            if (supplyViewModel != null)
            {
                await _apiClient.UpdateSupplyAsync(SelectedSupply!.Id, _mapper.Map<SuppliesPostDto>(supplyViewModel));
                _mapper.Map(supplyViewModel, SelectedSupply);
            }
        }, this.WhenAnyValue(vm => vm.SelectedSupply).Select(selectSupply => selectSupply != null));

        OnDeleteSupplyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteSupplyAsync(SelectedSupply!.Id);
            Supplies.Remove(SelectedSupply);
        }, this.WhenAnyValue(vm => vm.SelectedSupply).Select(selectSupply => selectSupply != null));

        OnAddWarehouseCellCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var warehouseCellViewModel = await ShowWarehouseCellDialog.Handle(new WarehouseCellViewModel());
            if (warehouseCellViewModel != null)
            {
                await _apiClient.AddWarehouseCellAsync(_mapper.Map<WarehouseCellsDto>(warehouseCellViewModel));
                _mapper.Map(warehouseCellViewModel, SelectedCell);
            }
        });

        OnEditWarehouseCellCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var warehouseCellViewModel = await ShowWarehouseCellDialog.Handle(SelectedCell!);
            if (warehouseCellViewModel != null)
            {
                await _apiClient.UpdateWarehouseCellAsync(SelectedCell!.CellNumber, _mapper.Map<WarehouseCellsDto>(warehouseCellViewModel));
                _mapper.Map(warehouseCellViewModel, SelectedCell);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCell).Select(selectWarehouseCell => selectWarehouseCell != null));

        OnDeleteWarehouseCellCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteWarehouseCellAsync(SelectedCell!.CellNumber);
            Cells.Remove(SelectedCell);
        }, this.WhenAnyValue(vm => vm.SelectedCell).Select(selectWarehouseCell => selectWarehouseCell != null));

        RxApp.MainThreadScheduler.Schedule(LoadProductsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadSuppliesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadCellsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadAllProductsAsync);
    }

    private async void LoadAllProductsAsync()
    {
        AllProducts.Clear();
        var products = await _apiClient.GetAllProductsAsync();
        foreach (var product in products)
        {
            AllProducts.Add(_mapper.Map<ProductViewModel>(product));
        }
    }

    private async void LoadProductsAsync()
    {
        var products = await _apiClient.GetProductsAsync();
        foreach (var product in products)
        {
            Products.Add(_mapper.Map<ProductViewModel>(product));
        }
    }

    private async void LoadSuppliesAsync()
    {
        var supplies = await _apiClient.GetSuppliesAsync();
        foreach (var supply in supplies)
        {
            Supplies.Add(_mapper.Map<SupplyViewModel>(supply));
        }
    }

    private async void LoadCellsAsync()
    {
        var cells = await _apiClient.GetWarehouseCellsAsync();
        foreach (var cell in cells)
        {
            Cells.Add(_mapper.Map<WarehouseCellViewModel>(cell));
        }
    }
}