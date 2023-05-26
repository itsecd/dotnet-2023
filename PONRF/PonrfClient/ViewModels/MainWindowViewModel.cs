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
