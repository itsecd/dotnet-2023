using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;


namespace StoreApp.Client.ViewModels;
public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ProductViewModel> Products { get; } = new();
    public ObservableCollection<CustomerViewModel> Customers { get; } = new();
    public ObservableCollection<StoreViewModel> Stores { get; } = new();

    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;

    private ProductViewModel? _selectedProduct;
    public ProductViewModel? SelectedProduct
    {
        get => _selectedProduct;
        set => this.RaiseAndSetIfChanged(ref _selectedProduct, value);
    }
    private CustomerViewModel? _selectedCustomer;
    public CustomerViewModel? SelectedCustomer
    {
        get => _selectedCustomer;
        set => this.RaiseAndSetIfChanged(ref _selectedCustomer, value);
    }
    private StoreViewModel? _selectedStore;
    public StoreViewModel? SelectedStore
    {
        get => _selectedStore;
        set => this.RaiseAndSetIfChanged(ref _selectedStore, value);
    }

    private ReactiveCommand<Unit, Unit> OnAddCommandProduct { get; set; }
    private ReactiveCommand<Unit, Unit> OnChangeCommandProduct { get; set; }
    private ReactiveCommand<Unit, Unit> OnDeleteCommandProduct { get; set; }
    private ReactiveCommand<Unit, Unit> OnAddCommandCustomer { get; set; }
    private ReactiveCommand<Unit, Unit> OnChangeCommandCustomer { get; set; }
    private ReactiveCommand<Unit, Unit> OnDeleteCommandCustomer { get; set; }
    private ReactiveCommand<Unit, Unit> OnAddCommandStore { get; set; }
    private ReactiveCommand<Unit, Unit> OnChangeCommandStore { get; set; }
    private ReactiveCommand<Unit, Unit> OnDeleteCommandStore { get; set; }

    public Interaction<ProductViewModel, ProductViewModel?> ShowProductDialog { get; }
    public Interaction<CustomerViewModel, CustomerViewModel?> ShowCustomerDialog { get; }
    public Interaction<StoreViewModel, StoreViewModel?> ShowStoreDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();
        ShowProductDialog = new Interaction<ProductViewModel, ProductViewModel?>();
        ShowCustomerDialog = new Interaction<CustomerViewModel, CustomerViewModel?>();
        ShowStoreDialog = new Interaction<StoreViewModel, StoreViewModel?>();

        OnAddCommandProduct = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(new ProductViewModel());
            if (productViewModel != null)
            {
                var newProduct = _mapper.Map<ProductPostDto>(productViewModel);
                await _apiClient.PostProductAsync(newProduct);
                Products.Add(_mapper.Map<ProductViewModel>(newProduct));
            }
        });
        OnChangeCommandProduct = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(SelectedProduct!);
            if (productViewModel != null)
            {
                var newProduct = _mapper.Map<ProductPostDto>(productViewModel);
                await _apiClient.UpdateProductAsync(SelectedProduct!.ProductId, newProduct);
                _mapper.Map(productViewModel, SelectedProduct);
            }
        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selecProduct => selecProduct != null));
        OnDeleteCommandProduct = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteProductAsync(SelectedProduct!.ProductId);
            Products.Remove(SelectedProduct);
        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selectProduct => selectProduct != null));

        OnAddCommandCustomer = ReactiveCommand.CreateFromTask(async () =>
        {
            var customerViewModel = await ShowCustomerDialog.Handle(new CustomerViewModel());
            if (customerViewModel != null)
            {
                var newCustomer = _mapper.Map<CustomerPostDto>(customerViewModel);
                await _apiClient.PostCustomerAsync(newCustomer);
                Customers.Add(_mapper.Map<CustomerViewModel>(newCustomer));
            }
        });
        OnChangeCommandCustomer = ReactiveCommand.CreateFromTask(async () =>
        {
            var customerViewModel = await ShowCustomerDialog.Handle(SelectedCustomer!);
            if (customerViewModel != null)
            {
                var newCustomer = _mapper.Map<CustomerPostDto>(customerViewModel);
                await _apiClient.UpdateCustomerAsync(SelectedCustomer!.CustomerId, newCustomer);
                _mapper.Map(customerViewModel, SelectedCustomer);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCustomer).Select(selectCustomer => selectCustomer != null));
        OnDeleteCommandCustomer = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCustomerAsync(SelectedCustomer!.CustomerId);
            Customers.Remove(SelectedCustomer);
        }, this.WhenAnyValue(vm => vm.SelectedCustomer).Select(selectCustomer => selectCustomer != null));


        OnAddCommandStore = ReactiveCommand.CreateFromTask(async () =>
        {
            var storeViewModel = await ShowStoreDialog.Handle(new StoreViewModel());
            if (storeViewModel != null)
            {
                var newStore = _mapper.Map<StorePostDto>(storeViewModel);
                await _apiClient.PostStoreAsync(newStore);
                Stores.Add(_mapper.Map<StoreViewModel>(newStore));
            }
        });
        OnChangeCommandStore = ReactiveCommand.CreateFromTask(async () =>
        {
            var storeViewModel = await ShowStoreDialog.Handle(SelectedStore!);
            if (storeViewModel != null)
            {
                var newStore = _mapper.Map<StorePostDto>(storeViewModel);
                await _apiClient.UpdateStoreAsync(SelectedStore!.StoreId, newStore);
                _mapper.Map(storeViewModel, SelectedStore);
            }
        }, this.WhenAnyValue(vm => vm.SelectedStore).Select(selectStore => selectStore != null));
        OnDeleteCommandStore = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteStoreAsync(SelectedStore!.StoreId);
            Stores.Remove(SelectedStore);
        }, this.WhenAnyValue(vm => vm.SelectedStore).Select(selectStore => selectStore != null));


        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }

    private async void LoadDataAsync()
    {
        var products = await _apiClient.GetProductAsync();
        foreach (var product in products)
        {
            Products.Add(_mapper.Map<ProductViewModel>(product));
        }

        var customers = await _apiClient.GetCustomerAsync();
        foreach (var customer in customers)
        {
            Customers.Add(_mapper.Map<CustomerViewModel>(customer));
        }

        var stores = await _apiClient.GetStoreAsync();
        foreach (var store in stores)
        {
            Stores.Add(_mapper.Map<StoreViewModel>(store));
        }
    }
}
