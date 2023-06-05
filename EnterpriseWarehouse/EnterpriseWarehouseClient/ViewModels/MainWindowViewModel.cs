using AutoMapper;
using ReactiveUI;
using Splat;
using System;
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

    public ObservableCollection<InvoiceContentViewModel> InvoicesContent { get; } = new();

    public ObservableCollection<ProductViewModel> TopFiveProductsByStockAvailability { get; } = new();

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

    private InvoiceContentViewModel? _selectedInvoiceContent;
    public InvoiceContentViewModel? SelectedInvoiceContent
    {
        get => _selectedInvoiceContent;
        set => this.RaiseAndSetIfChanged(ref _selectedInvoiceContent, value);
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

    public ReactiveCommand<Unit, Unit> OnInvoiceContentAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnInvoiceContentChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnInvoiceContentDeleteCommand { get; set; }

    public Interaction<ProductViewModel, ProductViewModel?> ShowProductDialog { get; }

    public Interaction<StorageCellViewModel, StorageCellViewModel?> ShowStorageCellDialog { get; }

    public Interaction<InvoiceViewModel, InvoiceViewModel?> ShowInvoiceDialog { get; }

    public Interaction<InvoiceContentViewModel, InvoiceContentViewModel?> ShowInvoiceContentDialog { get; }

    public Interaction<MessageViewModel, MessageViewModel?> ShowMessageDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowProductDialog = new Interaction<ProductViewModel, ProductViewModel?>();
        ShowStorageCellDialog = new Interaction<StorageCellViewModel, StorageCellViewModel?>();
        ShowInvoiceDialog = new Interaction<InvoiceViewModel, InvoiceViewModel?>();
        ShowInvoiceContentDialog = new Interaction<InvoiceContentViewModel, InvoiceContentViewModel?>();
        ShowMessageDialog = new Interaction<MessageViewModel, MessageViewModel?>();

        OnProductAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                var productViewModel = await ShowProductDialog.Handle(new ProductViewModel());
                if (productViewModel != null)
                {
                    var newProduct = await _apiClient.AddProductAsync(_mapper.Map<ProductPostDto>(productViewModel));
                    Products.Add(productViewModel);
                }
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        });

        OnProductChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                var productViewModel = await ShowProductDialog.Handle(SelectedProduct!);
                if (productViewModel != null)
                {
                    await _apiClient.UpdateProductAsync(SelectedProduct!.ItemNumber, _mapper.Map<ProductPostDto>(productViewModel));
                    _mapper.Map(productViewModel, SelectedProduct);
                }
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selectedProduct => selectedProduct != null));

        OnProductDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                var productViewModel = await ShowProductDialog.Handle(SelectedProduct!);
                if (productViewModel != null)
                {
                    await _apiClient.DeleteProductAsync(SelectedProduct!.ItemNumber);
                    while (StorageCells.FirstOrDefault(storageCell => storageCell.ProductIN == SelectedProduct.ItemNumber) != null)
                        StorageCells.Remove(StorageCells.FirstOrDefault(storageCell => storageCell.ProductIN == SelectedProduct.ItemNumber));
                    Products.Remove(SelectedProduct);
                }
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selectedProduct => selectedProduct != null));

        OnStorageCellAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                var storageCellViewModel = await ShowStorageCellDialog.Handle(new StorageCellViewModel());
                if (storageCellViewModel != null)
                {
                    var newProduct = await _apiClient.AddStorageCellAsync(_mapper.Map<StorageCellPostDto>(storageCellViewModel));
                    StorageCells.Add(storageCellViewModel);
                }
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        });

        OnStorageCellChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                var storageCellViewModel = await ShowStorageCellDialog.Handle(SelectedStorageCell!);
                if (storageCellViewModel != null)
                {
                    await _apiClient.UpdateStorageCellAsync(SelectedStorageCell!.Number, _mapper.Map<StorageCellPostDto>(storageCellViewModel));
                    _mapper.Map(storageCellViewModel, SelectedStorageCell);
                }
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        }, this.WhenAnyValue(vm => vm.SelectedStorageCell).Select(selectedStorageCell => selectedStorageCell != null));

        OnStorageCellDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                var storageCellViewModel = await ShowStorageCellDialog.Handle(SelectedStorageCell!);
                if (storageCellViewModel != null)
                {
                    await _apiClient.DeleteStorageCellAsync(SelectedStorageCell!.Number);
                    StorageCells.Remove(SelectedStorageCell);
                }
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        }, this.WhenAnyValue(vm => vm.SelectedStorageCell).Select(selectedStorageCell => selectedStorageCell != null));

        OnInvoiceAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                var invoiceViewModel = await ShowInvoiceDialog.Handle(new InvoiceViewModel());
                if (invoiceViewModel != null)
                {
                    var newProduct = await _apiClient.AddInvoiceAsync(_mapper.Map<InvoicePostDto>(invoiceViewModel));
                    Invoices.Add(invoiceViewModel);
                }
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        });

        OnInvoiceChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
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
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        }, this.WhenAnyValue(vm => vm.SelectedInvoice).Select(selectedInvoice => selectedInvoice != null));

        OnInvoiceDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                var invoiceViewModel = await ShowInvoiceDialog.Handle(SelectedInvoice!);
                if (invoiceViewModel != null)
                {
                    await _apiClient.DeleteInvoiceAsync(SelectedInvoice!.Id);
                    if (SelectedInvoice.Info != null)
                    {
                        foreach (var elem in SelectedInvoice.Info)
                        {
                            InvoicesContent.Remove(InvoicesContent.FirstOrDefault(x => x.InvoiceId == SelectedInvoice.Id));
                        }
                    }
                    Invoices.Remove(SelectedInvoice);
                }
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        }, this.WhenAnyValue(vm => vm.SelectedInvoice).Select(selectedInvoice => selectedInvoice != null));

        OnInvoiceContentAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                var invoiceContentViewModel = await ShowInvoiceContentDialog.Handle(new InvoiceContentViewModel());
                if (invoiceContentViewModel != null)
                {
                    var newProduct = await _apiClient.AddInvoiceContentAsync(_mapper.Map<InvoiceContentPostDto>(invoiceContentViewModel));
                    InvoicesContent.Add(invoiceContentViewModel);
                }
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        });

        OnInvoiceContentChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                var invoiceContentViewModel = await ShowInvoiceContentDialog.Handle(SelectedInvoiceContent!);
                if (invoiceContentViewModel != null)
                {
                    await _apiClient.UpdateInvoiceContentAsync(SelectedInvoiceContent!.InvoiceId, _mapper.Map<InvoiceContentPostDto>(invoiceContentViewModel));
                    _mapper.Map(invoiceContentViewModel, SelectedInvoiceContent);
                }
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        }, this.WhenAnyValue(vm => vm.SelectedInvoiceContent).Select(selectedInvoiceContent => selectedInvoiceContent != null));

        OnInvoiceContentDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                var invoiceContentViewModel = await ShowInvoiceContentDialog.Handle(SelectedInvoiceContent!);
                if (invoiceContentViewModel != null)
                {
                    await _apiClient.DeleteInvoiceContentAsync(SelectedInvoiceContent!.InvoiceId);
                    InvoicesContent.Remove(SelectedInvoiceContent);
                }
            }
            catch (Exception e)
            {
                var message = new MessageViewModel(e.Message);
                await ShowMessageDialog.Handle(message!);
            }
        }, this.WhenAnyValue(vm => vm.SelectedInvoiceContent).Select(selectedInvoiceContent => selectedInvoiceContent != null));

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

        var invoicesContent = await _apiClient.GetInvoiceContentAsync();
        foreach (var invoiceContent in invoicesContent)
        {
            InvoicesContent.Add(_mapper.Map<InvoiceContentViewModel>(invoiceContent));
        }

        var topFiveProductsByStockAvailability = await _apiClient.GetTopFiveProductsByStockAvailabilityAsync();
        foreach (var elem in topFiveProductsByStockAvailability)
        {
            TopFiveProductsByStockAvailability.Add(_mapper.Map<ProductViewModel>(elem));
        }
    }
}
