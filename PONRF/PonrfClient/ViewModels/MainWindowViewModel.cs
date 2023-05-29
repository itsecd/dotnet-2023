using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace PonrfClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<PrivatizedBuildingViewModel> PrivatizedBuildings { get; } = new();
    public ObservableCollection<AuctionViewModel> Auctions { get; } = new();
    public ObservableCollection<BuildingViewModel> Buildings { get; } = new();
    public ObservableCollection<CustomerViewModel> Customers { get; } = new();
    public ObservableCollection<CustomerViewModel> ViewAllCustomers { get; } = new();
    public ObservableCollection<AuctionsWithoutFullSalesViewModel> AuctionWithoutFullSales { get; } = new();
    public ObservableCollection<TopCustomerViewModel> TopCustomer { get; } = new();
    public ObservableCollection<TopAuctionViewModel> TopAuction { get; } = new();

    private PrivatizedBuildingViewModel? _selectedPrivatizedBuilding;
    public PrivatizedBuildingViewModel? SelectedPrivatizedBuilding
    {
        get => _selectedPrivatizedBuilding;
        set => this.RaiseAndSetIfChanged(ref _selectedPrivatizedBuilding, value);
    }

    private AuctionViewModel? _selectedAuction;
    public AuctionViewModel? SelectedAuction
    {
        get => _selectedAuction;
        set => this.RaiseAndSetIfChanged(ref _selectedAuction, value);
    }

    private BuildingViewModel? _selectedBuilding;
    public BuildingViewModel? SelectedBuilding
    {
        get => _selectedBuilding;
        set => this.RaiseAndSetIfChanged(ref _selectedBuilding, value);
    }

    private CustomerViewModel? _selectedCustomer;
    public CustomerViewModel? SelectedCustomer
    {
        get => _selectedCustomer;
        set => this.RaiseAndSetIfChanged(ref _selectedCustomer, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddPrivatizedBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangePrivatizedBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeletePrivatizedBuildingCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddAuctionCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeAuctionCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteAuctionCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteBuildingCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCustomerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCustomerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCustomerCommand { get; set; }

    public ReactiveCommand<Unit, Unit> ShowViewAllCustomers { get; set; }
    public ReactiveCommand<Unit, Unit> ShowAuctionWithoutFullSales { get; set; }
    public ReactiveCommand<Unit, Unit> ShowTopCustomer { get; set; }
    public ReactiveCommand<Unit, Unit> ShowTopAuction { get; set; }

    public Interaction<PrivatizedBuildingViewModel, PrivatizedBuildingViewModel?> ShowPrivatizedBuildingDialog { get; }
    public Interaction<AuctionViewModel, AuctionViewModel?> ShowAuctionDialog { get; }
    public Interaction<BuildingViewModel, BuildingViewModel?> ShowBuildingDialog { get; }
    public Interaction<CustomerViewModel, CustomerViewModel?> ShowCustomerDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowPrivatizedBuildingDialog = new Interaction<PrivatizedBuildingViewModel, PrivatizedBuildingViewModel?>();

        OnAddPrivatizedBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var privatizedBuildingViewModel = await ShowPrivatizedBuildingDialog.Handle(new PrivatizedBuildingViewModel());
            if (privatizedBuildingViewModel != null)
            {
                var newPrivatizedBuilding = _mapper.Map<PrivatizedBuildingPostDto>(privatizedBuildingViewModel);
                await _apiClient.AddPrivatizedBuildingAsync(newPrivatizedBuilding);
                PrivatizedBuildings.Add(privatizedBuildingViewModel);
                PrivatizedBuildings.Clear();
                LoadPrivatizedBuildingAsync();
            }
        });

        OnChangePrivatizedBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var privatizedBuildingViewModel = await ShowPrivatizedBuildingDialog.Handle(SelectedPrivatizedBuilding!);
            if (privatizedBuildingViewModel != null)
            {
                var newPrivatizedBuilding = _mapper.Map<PrivatizedBuildingPostDto>(privatizedBuildingViewModel);
                await _apiClient.UpdatePrivatizedBuildingAsync(SelectedPrivatizedBuilding!.Id, newPrivatizedBuilding);
                _mapper.Map(privatizedBuildingViewModel, SelectedPrivatizedBuilding);
            }
        }, this.WhenAnyValue(vm => vm.SelectedPrivatizedBuilding).Select(selectedPrivatizedBuilding => selectedPrivatizedBuilding != null));

        OnDeletePrivatizedBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeletePrivatizedBuildingAsync(SelectedPrivatizedBuilding!.Id);
            PrivatizedBuildings.Remove(SelectedPrivatizedBuilding);
        }, this.WhenAnyValue(vm => vm.SelectedPrivatizedBuilding).Select(selectedPrivatizedBuilding => selectedPrivatizedBuilding != null));

        ShowAuctionDialog = new Interaction<AuctionViewModel, AuctionViewModel?>();

        OnAddAuctionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var auctionViewModel = await ShowAuctionDialog.Handle(new AuctionViewModel());
            if (auctionViewModel != null)
            {
                var newAuction = _mapper.Map<AuctionPostDto>(auctionViewModel);
                await _apiClient.AddAuctionAsync(newAuction);
                Auctions.Add(auctionViewModel);
                Auctions.Clear();
                LoadAuctionAsync();
            }
        });

        OnChangeAuctionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var auctionViewModel = await ShowAuctionDialog.Handle(SelectedAuction!);
            if (auctionViewModel != null)
            {
                var newAuction = _mapper.Map<AuctionPostDto>(auctionViewModel);
                await _apiClient.UpdateAuctionAsync(SelectedAuction!.Id, newAuction);
                _mapper.Map(auctionViewModel, SelectedAuction);
            }
        }, this.WhenAnyValue(vm => vm.SelectedAuction).Select(selectedAuction => selectedAuction != null));

        OnDeleteAuctionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteAuctionAsync(SelectedAuction!.Id);
            Auctions.Remove(SelectedAuction);
        }, this.WhenAnyValue(vm => vm.SelectedAuction).Select(selectedAuction => selectedAuction != null));

        ShowBuildingDialog = new Interaction<BuildingViewModel, BuildingViewModel?>();

        OnAddBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var buildingViewModel = await ShowBuildingDialog.Handle(new BuildingViewModel());
            if (buildingViewModel != null)
            {
                var newBuilding = _mapper.Map<BuildingPostDto>(buildingViewModel);
                await _apiClient.AddBuildingAsync(newBuilding);
                Buildings.Add(buildingViewModel);
                Buildings.Clear();
                LoadBuildingAsync();
            }
        });

        OnChangeBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var buildingViewModel = await ShowBuildingDialog.Handle(SelectedBuilding!);
            if (buildingViewModel != null)
            {
                var newBuilding = _mapper.Map<BuildingPostDto>(buildingViewModel);
                await _apiClient.UpdateBuildingAsync(SelectedBuilding!.Id, newBuilding);
                _mapper.Map(buildingViewModel, SelectedBuilding);
            }
        }, this.WhenAnyValue(vm => vm.SelectedBuilding).Select(selectedBuilding => selectedBuilding != null));

        OnDeleteBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteBuildingAsync(SelectedBuilding!.Id);
            Buildings.Remove(SelectedBuilding);
        }, this.WhenAnyValue(vm => vm.SelectedBuilding).Select(selectedBuilding => selectedBuilding != null));

        ShowCustomerDialog = new Interaction<CustomerViewModel, CustomerViewModel?>();

        OnAddCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var customerViewModel = await ShowCustomerDialog.Handle(new CustomerViewModel());
            if (customerViewModel != null)
            {
                var newCustomer = _mapper.Map<CustomerPostDto>(customerViewModel);
                await _apiClient.AddCustomerAsync(newCustomer);
                Customers.Add(customerViewModel);
                Customers.Clear();
                LoadCustomerAsync();
            }
        });

        OnChangeCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var customerViewModel = await ShowCustomerDialog.Handle(SelectedCustomer!);
            if (customerViewModel != null)
            {
                var newCustomer = _mapper.Map<CustomerPostDto>(customerViewModel);
                await _apiClient.UpdateCustomerAsync(SelectedCustomer!.Id, newCustomer);
                _mapper.Map(customerViewModel, SelectedCustomer);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCustomer).Select(selectedCustomer => selectedCustomer != null));

        OnDeleteCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCustomerAsync(SelectedCustomer!.Id);
            Customers.Remove(SelectedCustomer);
        }, this.WhenAnyValue(vm => vm.SelectedCustomer).Select(selectedCustomer => selectedCustomer != null));

        ShowViewAllCustomers = ReactiveCommand.CreateFromTask(async () =>
        {
            var requestCustomer = await _apiClient.ViewAllCustomers();
            foreach (var customer in requestCustomer)
            {
                ViewAllCustomers.Add(_mapper.Map<CustomerViewModel>(customer));
            }
        });

        ShowAuctionWithoutFullSales = ReactiveCommand.CreateFromTask(async () =>
        {
            var requestAuction = await _apiClient.AuctionWithoutFullSales();
            foreach (var auction in requestAuction)
            {
                AuctionWithoutFullSales.Add(_mapper.Map<AuctionsWithoutFullSalesViewModel>(auction));
            }
        });

        ShowTopCustomer = ReactiveCommand.CreateFromTask(async () =>
        {
            var requestCustomer = await _apiClient.TopCustomer();
            foreach (var customer in requestCustomer)
            {
                TopCustomer.Add(_mapper.Map<TopCustomerViewModel>(customer));
            }
        });

        ShowTopAuction = ReactiveCommand.CreateFromTask(async () =>
        {
            var requestAuction = await _apiClient.TopAuction();
            foreach (var auction in requestAuction)
            {
                TopAuction.Add(_mapper.Map<TopAuctionViewModel>(auction));
            }
        });

        RxApp.MainThreadScheduler.Schedule(LoadPrivatizedBuildingAsync);
        RxApp.MainThreadScheduler.Schedule(LoadAuctionAsync);
        RxApp.MainThreadScheduler.Schedule(LoadBuildingAsync);
        RxApp.MainThreadScheduler.Schedule(LoadCustomerAsync);
    }

    private async void LoadPrivatizedBuildingAsync()
    {
        var privatizedBuildings = await _apiClient.GetPrivatizedBuildingAsync();
        foreach (var privatizedBuilding in privatizedBuildings)
        {
            PrivatizedBuildings.Add(_mapper.Map<PrivatizedBuildingViewModel>(privatizedBuilding));
        }
    }

    private async void LoadAuctionAsync()
    {
        var auctions = await _apiClient.GetAuctionAsync();
        foreach (var auction in auctions)
        {
            Auctions.Add(_mapper.Map<AuctionViewModel>(auction));
        }
    }

    private async void LoadBuildingAsync()
    {
        var buildings = await _apiClient.GetBuildingAsync();
        foreach (var building in buildings)
        {
            Buildings.Add(_mapper.Map<BuildingViewModel>(building));
        }
    }

    private async void LoadCustomerAsync()
    {
        var customers = await _apiClient.GetCustomerAsync();
        foreach (var customer in customers)
        {
            Customers.Add(_mapper.Map<CustomerViewModel>(customer));
        }
    }
}
