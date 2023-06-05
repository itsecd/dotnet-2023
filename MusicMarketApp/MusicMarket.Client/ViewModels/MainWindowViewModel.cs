using AutoMapper;
using MusicMarketClient;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;


namespace MusicMarket.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;


    public ReactiveCommand<Unit, Unit> OnAddCustomerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCustomerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCustomerCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddProductCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeProductCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteProductCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddSellerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeSellerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteSellerCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddPurchaseCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangePurchaseCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeletePurchaseCommand { get; set; }



    public ObservableCollection<CustomerViewModel> Customers { get; } = new();
    public ObservableCollection<ProductViewModel> Products { get; } = new();
    public ObservableCollection<PurchaseViewModel> Purchases { get; } = new();
    public ObservableCollection<SellerViewModel> Sellers { get; } = new();

    public Interaction<CustomerViewModel, CustomerViewModel?> ShowCustomerDialog { get; }
    public Interaction<ProductViewModel, ProductViewModel?> ShowProductDialog { get; }
    public Interaction<SellerViewModel, SellerViewModel?> ShowSellerDialog { get; }
    public Interaction<PurchaseViewModel, PurchaseViewModel?> ShowPurchaseDialog { get; }



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

    private SellerViewModel? _selectedSeller;
    public SellerViewModel? SelectedSeller
    {
        get => _selectedSeller;
        set => this.RaiseAndSetIfChanged(ref _selectedSeller, value);
    }

    private PurchaseViewModel? _selectedPurchase;
    public PurchaseViewModel? SelectedPurchase
    {
        get => _selectedPurchase;
        set => this.RaiseAndSetIfChanged(ref _selectedPurchase, value);
    }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowCustomerDialog = new Interaction<CustomerViewModel, CustomerViewModel?>();
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


        ShowProductDialog = new Interaction<ProductViewModel, ProductViewModel?>();
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


        ShowSellerDialog = new Interaction<SellerViewModel, SellerViewModel?>();
        OnAddSellerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var sellerViewModel = await ShowSellerDialog.Handle(new SellerViewModel());
            if (sellerViewModel != null)
            {
                var newSeller = await _apiClient.AddSellerAsync(_mapper.Map<SellerPostDto>(sellerViewModel));
                Sellers.Add(_mapper.Map<SellerViewModel>(newSeller));
            }
        });
        OnChangeSellerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var sellerViewModel = await ShowSellerDialog.Handle(SelectedSeller!);
            if (sellerViewModel != null)
            {
                await _apiClient.UpdateSellerAsync(SelectedSeller!.Id, _mapper.Map<SellerPostDto>(sellerViewModel));
                _mapper.Map(sellerViewModel, SelectedSeller);
            }
        }, this.WhenAnyValue(va => va.SelectedSeller).Select(selectedSeller => selectedSeller != null));

        OnDeleteSellerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteSellerAsync(SelectedSeller!.Id);
            Sellers.Remove(SelectedSeller!);
        }, this.WhenAnyValue(va => va.SelectedSeller).Select(selectedSeller => selectedSeller != null));


        ShowPurchaseDialog = new Interaction<PurchaseViewModel, PurchaseViewModel?>();
        OnAddPurchaseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var purchaseViewModel = await ShowPurchaseDialog.Handle(new PurchaseViewModel());
            if (purchaseViewModel != null)
            {
                var newPurchase = await _apiClient.AddPurchaseAsync(_mapper.Map<PurchasePostDto>(purchaseViewModel));
                Purchases.Add(_mapper.Map<PurchaseViewModel>(newPurchase));
            }
        });
        OnChangePurchaseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var purchaseViewModel = await ShowPurchaseDialog.Handle(SelectedPurchase!);
            if (purchaseViewModel != null)
            {
                await _apiClient.UpdatePurchaseAsync(SelectedPurchase!.Id, _mapper.Map<PurchasePostDto>(purchaseViewModel));
                _mapper.Map(purchaseViewModel, SelectedPurchase);
            }
        }, this.WhenAnyValue(va => va.SelectedPurchase).Select(selectedPurchase => selectedPurchase != null));

        OnDeletePurchaseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeletePurchaseAsync(SelectedPurchase!.Id);
            Purchases.Remove(SelectedPurchase!);
        }, this.WhenAnyValue(va => va.SelectedPurchase).Select(selectedPurchase => selectedPurchase != null));



        RxApp.MainThreadScheduler.Schedule(LoadCustomersAsync);
        RxApp.MainThreadScheduler.Schedule(LoadProductsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadSellersAsync);
        RxApp.MainThreadScheduler.Schedule(LoadPurchasesAsync);

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
    private async void LoadSellersAsync()
    {
        var productGroups = await _apiClient.GetSellersAsync();
        foreach (var productGroup in productGroups)
        {
            Sellers.Add(_mapper.Map<SellerViewModel>(productGroup));
        }
    }
    private async void LoadPurchasesAsync()
    {
        var purchaseRecords = await _apiClient.GetPurchasesAsync();
        foreach (var purchaseRecord in purchaseRecords)
        {
            Purchases.Add(_mapper.Map<PurchaseViewModel>(purchaseRecord));
        }
    }
}


