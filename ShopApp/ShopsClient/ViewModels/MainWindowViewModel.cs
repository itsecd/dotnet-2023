using AutoMapper;
using ReactiveUI;
using ShopsClient.ViewModels;
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
    public Interaction<CustomerViewModel, CustomerViewModel?> ShowCustomerDialog { get;}
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


        RxApp.MainThreadScheduler.Schedule(LoadCustomersAsync);
    }

    private async void LoadCustomersAsync()
    {
        var customers = await _apiClient.GetCusomersAsync();
        foreach (var customer in customers)
        { 
            Customers.Add(_mapper.Map<CustomerViewModel>(customer));
        }
    }
}
