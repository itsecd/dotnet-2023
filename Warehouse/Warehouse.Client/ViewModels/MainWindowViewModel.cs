using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Warehouse.Client.ViewModels;

namespace Warehouse.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ObservableCollection<ProductsViewModel> Product { get; } = new();
    public ObservableCollection<SuppliesViewModel> Supply { get; } = new();
    public ObservableCollection<WarehouseCellsViewModel> WarehouseCell { get; } = new();

    private ProductsViewModel? _selectedProduct;
    public ProductsViewModel? SelectedProduct
    {
        get => _selectedProduct;
        set => this.RaiseAndSetIfChanged(ref _selectedProduct, value);
    }

    private SuppliesViewModel? _selectedSupply;
    public SuppliesViewModel? SelectedSupply
    {
        get => _selectedSupply;
        set => this.RaiseAndSetIfChanged(ref _selectedSupply, value);
    }

    private WarehouseCellsViewModel? _selectedCell;
    public WarehouseCellsViewModel? SelectedCell
    {
        get => _selectedCell;
        set => this.RaiseAndSetIfChanged(ref _selectedCell, value);
    }

    public ReactiveCommand<Unit, Unit> OnAddProductsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditProductsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteProductsCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddSuppliesCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditSuppliesCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteSuppliesCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddWarehouseCellsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditWarehouseCellsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteWarehouseCellsCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddReaderCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditReaderCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteReaderCommand { get; set; }

    public Interaction<ProductsViewModel, ProductsViewModel?> ShowProductsDialog { get; }
    public Interaction<SuppliesViewModel, SuppliesViewModel?> ShowSuppliesDialog { get; }
    public Interaction<WarehouseCellsViewModel, WarehouseCellsViewModel?> ShowWarehouseCellsDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowProductsDialog = new Interaction<ProductsViewModel, ProductsViewModel?>();
        ShowSuppliesDialog = new Interaction<SuppliesViewModel, SuppliesViewModel?>();
        ShowWarehouseCellsDialog = new Interaction<WarehouseCellsViewModel, WarehouseCellsViewModel?>();

        OnAddProductsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productsViewModel = await ShowProductsDialog.Handle(new ProductsViewModel());
            if (ProductsViewModel != null)
            {
                var newProducts = await _apiClient.AddProductsAsync(_mapper.Map<ProductsPostDto>(ProductsViewModel));
                Productss.Add(_mapper.Map<ProductsViewModel>(newProducts));
            }
        });

        OnEditProductsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var ProductsViewModel = await ShowProductsDialog.Handle(SelectedProducts!);
            if (ProductsViewModel != null)
            {
                await _apiClient.UpdateProductsAsync(SelectedProducts!.Id, _mapper.Map<ProductsPostDto>(ProductsViewModel));
                _mapper.Map(ProductsViewModel, SelectedProducts);
            }
        }, this.WhenAnyValue(vm => vm.SelectedProducts).Select(selectProducts => selectProducts != null));

        OnDeleteProductsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteProductsAsync(SelectedProducts!.Id);
            Productss.Remove(SelectedProducts);
        }, this.WhenAnyValue(vm => vm.SelectedProducts).Select(selectProducts => selectProducts != null));

        OnAddSuppliesCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var SuppliesViewModel = await ShowSuppliesDialog.Handle(new SuppliesViewModel());
            if (SuppliesViewModel != null)
            {
                var newSupplies = await _apiClient.AddSuppliesAsync(_mapper.Map<SuppliesPostDto>(SuppliesViewModel));
                Suppliess.Add(_mapper.Map<SuppliesViewModel>(newSupplies));
            }
        });

        OnEditSuppliesCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var SuppliesViewModel = await ShowSuppliesDialog.Handle(SelectedSupplies!);
            if (SuppliesViewModel != null)
            {
                await _apiClient.UpdateSuppliesAsync(SelectedSupplies!.Id, _mapper.Map<SuppliesPostDto>(SuppliesViewModel));
                _mapper.Map(SuppliesViewModel, SelectedSupplies);
            }
        }, this.WhenAnyValue(vm => vm.SelectedSupplies).Select(selectSupplies => selectSupplies != null));

        OnDeleteSuppliesCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteSuppliesAsync(SelectedSupplies!.Id);
            Suppliess.Remove(SelectedSupplies);
        }, this.WhenAnyValue(vm => vm.SelectedSupplies).Select(selectSupplies => selectSupplies != null));

        OnAddWarehouseCellsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var WarehouseCellsViewModel = await ShowWarehouseCellsDialog.Handle(new WarehouseCellsViewModel());
            if (WarehouseCellsViewModel != null)
            {
                var newWarehouseCells = await _apiClient.AddWarehouseCellsAsync(_mapper.Map<WarehouseCellsPostDto>(WarehouseCellsViewModel));
                WarehouseCellss.Add(_mapper.Map<WarehouseCellsViewModel>(newWarehouseCells));
            }
        });

        OnEditWarehouseCellsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var WarehouseCellsViewModel = await ShowWarehouseCellsDialog.Handle(SelectedWarehouseCells!);
            if (WarehouseCellsViewModel != null)
            {
                await _apiClient.UpdateWarehouseCellsAsync(SelectedWarehouseCells!.Id, _mapper.Map<WarehouseCellsPostDto>(WarehouseCellsViewModel));
                _mapper.Map(WarehouseCellsViewModel, SelectedWarehouseCells);
            }
        }, this.WhenAnyValue(vm => vm.SelectedWarehouseCells).Select(selectWarehouseCells => selectWarehouseCells != null));

        OnDeleteWarehouseCellsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteWarehouseCellsAsync(SelectedWarehouseCells!.Id);
            WarehouseCellss.Remove(SelectedWarehouseCells);
        }, this.WhenAnyValue(vm => vm.SelectedWarehouseCells).Select(selectWarehouseCells => selectWarehouseCells != null));

        OnAddReaderCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var readerViewModel = await ShowReaderDialog.Handle(new ReaderViewModel());
            if (readerViewModel != null)
            {
                var newReader = await _apiClient.AddReaderAsync(_mapper.Map<ReaderPostDto>(readerViewModel));
                Readers.Add(_mapper.Map<ReaderViewModel>(newReader));
            }
        });

        OnEditReaderCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var readerViewModel = await ShowReaderDialog.Handle(SelectedReader!);
            if (readerViewModel != null)
            {
                await _apiClient.UpdateReaderAsync(SelectedReader!.Id, _mapper.Map<ReaderPostDto>(readerViewModel));
                _mapper.Map(readerViewModel, SelectedReader);
            }
        }, this.WhenAnyValue(vm => vm.SelectedReader).Select(selectReader => selectReader != null));

        OnDeleteReaderCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteReaderAsync(SelectedReader!.Id);
            Readers.Remove(SelectedReader);
        }, this.WhenAnyValue(vm => vm.SelectedReader).Select(selectReader => selectReader != null));

        RxApp.MainThreadScheduler.Schedule(LoadProductssAsync);
        RxApp.MainThreadScheduler.Schedule(LoadSuppliessAsync);
        RxApp.MainThreadScheduler.Schedule(LoadWarehouseCellssAsync);
        RxApp.MainThreadScheduler.Schedule(LoadReadersAsync);
        RxApp.MainThreadScheduler.Schedule(LoadTypesEditionsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadTypesWarehouseCellssAsync);
        RxApp.MainThreadScheduler.Schedule(LoadAllProductssAsync);
    }

    private async void LoadAllProductssAsync()
    {
        AllProductss.Clear();
        var Productss = await _apiClient.GetAllProductssAsync();
        foreach (var Products in Productss)
        {
            AllProductss.Add(_mapper.Map<ProductsViewModel>(Products));
        }
    }

    private async void LoadProductssAsync()
    {
        var Productss = await _apiClient.GetProductssAsync();
        foreach (var Products in Productss)
        {
            Productss.Add(_mapper.Map<ProductsViewModel>(Products));
        }
    }

    private async void LoadSuppliessAsync()
    {
        var Suppliess = await _apiClient.GetSuppliessAsync();
        foreach (var Supplies in Suppliess)
        {
            Suppliess.Add(_mapper.Map<SuppliesViewModel>(Supplies));
        }
    }

    private async void LoadWarehouseCellssAsync()
    {
        var WarehouseCellss = await _apiClient.GetWarehouseCellssAsync();
        foreach (var WarehouseCells in WarehouseCellss)
        {
            WarehouseCellss.Add(_mapper.Map<WarehouseCellsViewModel>(WarehouseCells));
        }
    }

    private async void LoadReadersAsync()
    {
        var readers = await _apiClient.GetReadersAsync();
        foreach (var reader in readers)
        {
            Readers.Add(_mapper.Map<ReaderViewModel>(reader));
        }
    }

    private async void LoadTypesEditionsAsync()
    {
        var types = await _apiClient.GetTypeEditionsAsync();
        foreach (var type in types)
        {
            TypesEditions.Add(_mapper.Map<TypeEditionViewModel>(type));
        }
    }

    private async void LoadTypesWarehouseCellssAsync()
    {
        var types = await _apiClient.GetTypeWarehouseCellssAsync();
        foreach (var type in types)
        {
            TypesWarehouseCellss.Add(_mapper.Map<TypeWarehouseCellsViewModel>(type));
        }
    }
}