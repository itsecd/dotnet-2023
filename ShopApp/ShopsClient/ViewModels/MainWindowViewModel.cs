using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace ShopsClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<CustomerViewModel> Customers { get; } = new();
    public ObservableCollection<ProductViewModel> Products { get; } = new();
    public ObservableCollection<ProductGroupViewModel> ProductGroups { get; } = new();
    public ObservableCollection<ProductQuantityViewModel> ProductQuantitys { get; } = new();
    public ObservableCollection<PurchaseRecordViewModel> PurchaseRecords { get; } = new();
    public ObservableCollection<ShopViewModel> Shops { get; } = new();
    public ObservableCollection<PurchaseRecordViewModel> Top5PurchaseRecords { get; } = new();

    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;

    private CustomerViewModel? _selectedCustomer;
    public CustomerViewModel? SelectedCustomer
    {
        get => _selectedCustomer;
        set => this.RaiseAndSetIfChanged(ref _selectedCustomer, value);
    }
    private ProductViewModel? _selectedProduct;
    public ProductViewModel? SelectedProduct
    {
        get => _selectedProduct;
        set => this.RaiseAndSetIfChanged(ref _selectedProduct, value);
    }
    private ProductGroupViewModel? _selectedProductGroup;
    public ProductGroupViewModel? SelectedProductGroup
    {
        get => _selectedProductGroup;
        set => this.RaiseAndSetIfChanged(ref _selectedProductGroup, value);
    }
    private ProductQuantityViewModel? _selectedProductQuantity;
    public ProductQuantityViewModel? SelectedProductQuantity
    {
        get => _selectedProductQuantity;
        set => this.RaiseAndSetIfChanged(ref _selectedProductQuantity, value);
    }
    private PurchaseRecordViewModel? _selectedPurchaseRecord;
    public PurchaseRecordViewModel? SelectedPurchaseRecord
    {
        get => _selectedPurchaseRecord;
        set => this.RaiseAndSetIfChanged(ref _selectedPurchaseRecord, value);
    }
    private ShopViewModel? _selectedShop;
    public ShopViewModel? SelectedShop
    {
        get => _selectedShop;
        set => this.RaiseAndSetIfChanged(ref _selectedShop, value);
    }
    public ReactiveCommand<Unit, Unit> OnAddCustomerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCustomerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCustomerCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddProductCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeProductCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteProductCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddProductGroupCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeProductGroupCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteProductGroupCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddProductQuantityCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeProductQuantityCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteProductQuantityCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddPurchaseRecordCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangePurchaseRecordCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeletePurchaseRecordCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddShopCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeShopCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteShopCommand { get; set; }
    public Interaction<CustomerViewModel, CustomerViewModel?> ShowCustomerDialog { get; }
    public Interaction<ProductViewModel, ProductViewModel?> ShowProductDialog { get; }
    public Interaction<ProductGroupViewModel, ProductGroupViewModel?> ShowProductGroupDialog { get; }
    public Interaction<ProductQuantityViewModel, ProductQuantityViewModel?> ShowProductQuantityDialog { get; }
    public Interaction<PurchaseRecordViewModel, PurchaseRecordViewModel?> ShowPurchaseRecordDialog { get; }
    public Interaction<ShopViewModel, ShopViewModel?> ShowShopDialog { get; }
    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowCustomerDialog = new Interaction<CustomerViewModel, CustomerViewModel?>();
        ShowProductDialog = new Interaction<ProductViewModel, ProductViewModel?>();
        ShowProductGroupDialog = new Interaction<ProductGroupViewModel, ProductGroupViewModel?>();
        ShowProductQuantityDialog = new Interaction<ProductQuantityViewModel, ProductQuantityViewModel?>();
        ShowPurchaseRecordDialog = new Interaction<PurchaseRecordViewModel, PurchaseRecordViewModel?>();
        ShowShopDialog = new Interaction<ShopViewModel, ShopViewModel?>();

        OnAddCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var customerViewModel = await ShowCustomerDialog.Handle(new CustomerViewModel());
            if (customerViewModel != null)
            {
                var newCustomer = await _apiClient.AddCustomerAsync(_mapper.Map<CustomerPostDto>(customerViewModel));
                Customers.Add(_mapper.Map<CustomerViewModel>(newCustomer));
            }
        });
        OnChangeCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var customerViewModel = await ShowCustomerDialog.Handle(SelectedCustomer!);
            if (customerViewModel != null)
            {
                await _apiClient.UpdateCustomerAsync(SelectedCustomer!.Id, _mapper.Map<CustomerPostDto>(customerViewModel));
                _mapper.Map(customerViewModel, SelectedCustomer);
            }
        }, this.WhenAnyValue(va => va.SelectedCustomer).Select(selectedCustomer => selectedCustomer != null));

        OnDeleteCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCustomerAsync(SelectedCustomer!.Id);
            Customers.Remove(SelectedCustomer!);
        }, this.WhenAnyValue(va => va.SelectedCustomer).Select(selectedCustomer => selectedCustomer != null));

        OnAddProductCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(new ProductViewModel());
            if (productViewModel != null)
            {
                var newProduct = await _apiClient.AddProductAsync(_mapper.Map<ProductPostDto>(productViewModel));
                Products.Add(_mapper.Map<ProductViewModel>(newProduct));
            }
        });
        OnChangeProductCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(SelectedProduct!);
            if (productViewModel != null)
            {
                await _apiClient.UpdateProductAsync(SelectedProduct!.Id, _mapper.Map<ProductPostDto>(productViewModel));
                _mapper.Map(productViewModel, SelectedProduct);
            }
        }, this.WhenAnyValue(va => va.SelectedProduct).Select(selectedProduct => selectedProduct != null));

        OnDeleteProductCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteProductAsync(SelectedProduct!.Id);
            Products.Remove(SelectedProduct!);
        }, this.WhenAnyValue(va => va.SelectedProduct).Select(selectedProduct => selectedProduct != null));


        OnAddProductGroupCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productGroupViewModel = await ShowProductGroupDialog.Handle(new ProductGroupViewModel());
            if (productGroupViewModel != null)
            {
                var newProductGroup = await _apiClient.AddProductGroupAsync(_mapper.Map<ProductGroupPostDto>(productGroupViewModel));
                ProductGroups.Add(_mapper.Map<ProductGroupViewModel>(newProductGroup));
            }
        });
        OnChangeProductGroupCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productGroupViewModel = await ShowProductGroupDialog.Handle(SelectedProductGroup!);
            if (productGroupViewModel != null)
            {
                await _apiClient.UpdateProductGroupAsync(SelectedProductGroup!.Id, _mapper.Map<ProductGroupPostDto>(productGroupViewModel));
                _mapper.Map(productGroupViewModel, SelectedProductGroup);
            }
        }, this.WhenAnyValue(va => va.SelectedProductGroup).Select(selectedProductGroup => selectedProductGroup != null));

        OnDeleteProductGroupCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteProductGroupAsync(SelectedProductGroup!.Id);
            ProductGroups.Remove(SelectedProductGroup!);
        }, this.WhenAnyValue(va => va.SelectedProductGroup).Select(selectedProductGroup => selectedProductGroup != null));


        OnAddProductQuantityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productQuantityViewModel = await ShowProductQuantityDialog.Handle(new ProductQuantityViewModel());
            if (productQuantityViewModel != null)
            {
                var newProductQuantity = await _apiClient.AddProductQuantityAsync(_mapper.Map<ProductQuantityPostDto>(productQuantityViewModel));
                ProductQuantitys.Add(_mapper.Map<ProductQuantityViewModel>(newProductQuantity));
            }
        });
        OnChangeProductQuantityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var productQuantityViewModel = await ShowProductQuantityDialog.Handle(SelectedProductQuantity!);
            if (productQuantityViewModel != null)
            {
                await _apiClient.UpdateProductQuantityAsync(SelectedProductQuantity!.Id, _mapper.Map<ProductQuantityPostDto>(productQuantityViewModel));
                _mapper.Map(productQuantityViewModel, SelectedProductQuantity);
            }
        }, this.WhenAnyValue(va => va.SelectedProductQuantity).Select(selectedProductQuantity => selectedProductQuantity != null));

        OnDeleteProductQuantityCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteProductQuantityAsync(SelectedProductQuantity!.Id);
            ProductQuantitys.Remove(SelectedProductQuantity!);
        }, this.WhenAnyValue(va => va.SelectedProductQuantity).Select(selectedProductQuantity => selectedProductQuantity != null));


        OnAddPurchaseRecordCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var purchaseRecordViewModel = await ShowPurchaseRecordDialog.Handle(new PurchaseRecordViewModel());
            if (purchaseRecordViewModel != null)
            {
                var newPurchaseRecord = await _apiClient.AddPurchaseRecordAsync(_mapper.Map<PurchaseRecordPostDto>(purchaseRecordViewModel));
                PurchaseRecords.Add(_mapper.Map<PurchaseRecordViewModel>(newPurchaseRecord));
            }
        });
        OnChangePurchaseRecordCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var purchaseRecordViewModel = await ShowPurchaseRecordDialog.Handle(SelectedPurchaseRecord!);
            if (purchaseRecordViewModel != null)
            {
                await _apiClient.UpdatePurchaseRecordAsync(SelectedPurchaseRecord!.Id, _mapper.Map<PurchaseRecordPostDto>(purchaseRecordViewModel));
                _mapper.Map(purchaseRecordViewModel, SelectedPurchaseRecord);
            }
        }, this.WhenAnyValue(va => va.SelectedPurchaseRecord).Select(selectedPurchaseRecord => selectedPurchaseRecord != null));

        OnDeletePurchaseRecordCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeletePurchaseRecordAsync(SelectedPurchaseRecord!.Id);
            PurchaseRecords.Remove(SelectedPurchaseRecord!);
        }, this.WhenAnyValue(va => va.SelectedPurchaseRecord).Select(selectedPurchaseRecord => selectedPurchaseRecord != null));


        OnAddShopCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var shopViewModel = await ShowShopDialog.Handle(new ShopViewModel());
            if (shopViewModel != null)
            {
                var newShop = await _apiClient.AddShopAsync(_mapper.Map<ShopPostDto>(shopViewModel));
                Shops.Add(_mapper.Map<ShopViewModel>(newShop));
            }
        });
        OnChangeShopCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var shopViewModel = await ShowShopDialog.Handle(SelectedShop!);
            if (shopViewModel != null)
            {
                await _apiClient.UpdateShopAsync(SelectedShop!.Id, _mapper.Map<ShopPostDto>(shopViewModel));
                _mapper.Map(shopViewModel, SelectedShop);
            }
        }, this.WhenAnyValue(va => va.SelectedShop).Select(selectedShop => selectedShop != null));

        OnDeleteShopCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteShopAsync(SelectedShop!.Id);
            Shops.Remove(SelectedShop!);
        }, this.WhenAnyValue(va => va.SelectedShop).Select(selectedShop => selectedShop != null));



        RxApp.MainThreadScheduler.Schedule(LoadCustomersAsync);
        RxApp.MainThreadScheduler.Schedule(LoadProductsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadProductGroupsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadProductQuantityAsync);
        RxApp.MainThreadScheduler.Schedule(LoadPurchaseRecordsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadShopsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadTop5PurchaseRecordsAsync);
    }
    private async void LoadCustomersAsync()
    {
        var customers = await _apiClient.GetCusomersAsync();
        foreach (var customer in customers)
        {
            Customers.Add(_mapper.Map<CustomerViewModel>(customer));
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
    private async void LoadProductGroupsAsync()
    {
        var productGroups = await _apiClient.GetProductGroupsAsync();
        foreach (var productGroup in productGroups)
        {
            ProductGroups.Add(_mapper.Map<ProductGroupViewModel>(productGroup));
        }
    }
    private async void LoadProductQuantityAsync()
    {
        var productQuantitys = await _apiClient.GetProductQuantitysAsync();
        foreach (var productQuantity in productQuantitys)
        {
            ProductQuantitys.Add(_mapper.Map<ProductQuantityViewModel>(productQuantity));
        }
    }
    private async void LoadPurchaseRecordsAsync()
    {
        var purchaseRecords = await _apiClient.GetPurchaseRecordsAsync();
        foreach (var purchaseRecord in purchaseRecords)
        {
            PurchaseRecords.Add(_mapper.Map<PurchaseRecordViewModel>(purchaseRecord));
        }
    }
    private async void LoadShopsAsync()
    {
        var shops = await _apiClient.GetShopsAsync();
        foreach (var shop in shops)
        {
            Shops.Add(_mapper.Map<ShopViewModel>(shop));
        }
    }
    private async void LoadTop5PurchaseRecordsAsync()
    {
        var top5PurchaseRecords = await _apiClient.Top5PurchasesAsync();
        foreach (var purchaseRecord in top5PurchaseRecords)
        {
            Top5PurchaseRecords.Add(_mapper.Map<PurchaseRecordViewModel>(purchaseRecord));
        }
    }
}
