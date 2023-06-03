using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace EnterpriseWarehouseClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ProductViewModel> Products { get; } = new();

    public ObservableCollection<StorageCellViewModel> StorageCells { get; } = new();

    public ObservableCollection<InvoiceViewModel> Invoices { get; } = new();

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

    private InvoiceViewModel? _selectedInvoice;
    public InvoiceViewModel? SelectedInvoice
    {
        get => _selectedInvoice;
        set => this.RaiseAndSetIfChanged(ref _selectedInvoice, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnProductAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnProductChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnProductDeleteCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnStorageCellAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnStorageCellChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnStorageCellDeleteCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnInvoiceAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnInvoiceChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnInvoiceDeleteCommand { get; set; }

    public Interaction<ProductViewModel, ProductViewModel?> ShowProductDialog { get; }

    public Interaction<StorageCellViewModel, StorageCellViewModel?> ShowStorageCellDialog { get; }

    public Interaction<InvoiceViewModel, InvoiceViewModel?> ShowInvoiceDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowProductDialog = new Interaction<ProductViewModel, ProductViewModel?>();
        ShowStorageCellDialog = new Interaction<StorageCellViewModel, StorageCellViewModel?>();
        ShowInvoiceDialog = new Interaction<InvoiceViewModel, InvoiceViewModel?>();

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

        OnInvoiceAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var invoiceViewModel = await ShowInvoiceDialog.Handle(new InvoiceViewModel());
            if (invoiceViewModel != null)
            {
                var newProduct = await _apiClient.AddInvoiceAsync(_mapper.Map<InvoicePostDto>(invoiceViewModel));
                Invoices.Add(invoiceViewModel);
            }
        });

        OnInvoiceChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var invoiceViewModel = await ShowInvoiceDialog.Handle(SelectedInvoice!);
            if (invoiceViewModel != null)
            {
                if (invoiceViewModel.Info != null)
                {
                    var modifiedInvoice = new InvoicePostDto
                    {
                        Id = invoiceViewModel.Id,
                        NameOrganization = invoiceViewModel.NameOrganization,
                        AddressOrganization = invoiceViewModel.AddressOrganization,
                        ShipmentDate = invoiceViewModel.ShipmentDate,
                        Products = invoiceViewModel.Info
                    };
                    await _apiClient.UpdateInvoiceAsync(SelectedInvoice!.Id, modifiedInvoice);
                    _mapper.Map(invoiceViewModel, SelectedInvoice);
                }
            }
        }, this.WhenAnyValue(vm => vm.SelectedInvoice).Select(selectedInvoice => selectedInvoice != null));

        OnInvoiceDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var invoiceViewModel = await ShowInvoiceDialog.Handle(SelectedInvoice!);
            if (invoiceViewModel != null)
            {
                await _apiClient.DeleteInvoiceAsync(SelectedInvoice!.Id);
                Invoices.Remove(SelectedInvoice);
            }
        }, this.WhenAnyValue(vm => vm.SelectedInvoice).Select(selectedInvoice => selectedInvoice != null));

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

        var invoices = await _apiClient.GetInvoicesAsync();
        foreach (var invoice in invoices)
        {
            var tempInfo = new System.Collections.Generic.Dictionary<int, int>();
            foreach (var elem in invoice.Products)
            {
                tempInfo.Add(int.Parse(elem.Key), elem.Value);
            }
            Invoices.Add(new InvoiceViewModel
            {
                Id = invoice.Id,
                NameOrganization = invoice.NameOrganization,
                AddressOrganization = invoice.AddressOrganization,
                ShipmentDate = invoice.ShipmentDate,
                Info = tempInfo
            });
        }
    }
}
