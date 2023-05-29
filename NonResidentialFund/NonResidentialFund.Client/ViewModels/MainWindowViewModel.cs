using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace NonResidentialFund.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<AuctionViewModel> Auctions { get; } = new();
    public ObservableCollection<BuildingViewModel> Buildings { get; } = new();
    public ObservableCollection<BuyerViewModel> Buyers { get; } = new();
    public ObservableCollection<DistrictViewModel> Districts { get; } = new();
    public ObservableCollection<OrganizationViewModel> Organizations { get; } = new();
    public ObservableCollection<PrivatizedViewModel> Privatized { get; } = new();
    public ObservableCollection<AuctionViewModel> AuctionsNotAllLotsSold { get; } = new();
    public ObservableCollection<BuyerExpensesViewModel> TopBuyersByExpenses { get; } = new();
    public ObservableCollection<AuctionIncomeViewModel> AuctionsWithHighestIncome { get; } = new();

    private AuctionViewModel? _selectedAuction;
    private BuildingViewModel? _selectedBuilding;
    private BuyerViewModel? _selectedBuyer;
    private DistrictViewModel? _selectedDistrict;
    private OrganizationViewModel? _selectedOrganization;
    private PrivatizedViewModel? _selectedPrivatized;

    public AuctionViewModel? SelectedAuction
    {
        get => _selectedAuction;
        set => this.RaiseAndSetIfChanged(ref _selectedAuction, value);
    }
    public BuildingViewModel? SelectedBuilding
    {
        get => _selectedBuilding;
        set => this.RaiseAndSetIfChanged(ref _selectedBuilding, value);
    }
    public BuyerViewModel? SelectedBuyer
    {
        get => _selectedBuyer;
        set => this.RaiseAndSetIfChanged(ref _selectedBuyer, value);
    }
    public DistrictViewModel? SelectedDistrict
    {
        get => _selectedDistrict;
        set => this.RaiseAndSetIfChanged(ref _selectedDistrict, value);
    }
    public OrganizationViewModel? SelectedOrganization
    {
        get => _selectedOrganization;
        set => this.RaiseAndSetIfChanged(ref _selectedOrganization, value);
    }
    public PrivatizedViewModel? SelectedPrivatized
    {
        get => _selectedPrivatized;
        set => this.RaiseAndSetIfChanged(ref _selectedPrivatized, value);
    }

    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddAuctionCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateAuctionCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteAuctionCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddBuyerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateBuyerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteBuyerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddDistrictCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateDistrictCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteDistrictCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddOrganizationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateOrganizationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteOrganizationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnAddPrivatizedCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdatePrivatizedCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeletePrivatizedCommand { get; set; }

    public Interaction<AuctionViewModel, AuctionViewModel?> ShowAuctionDialog { get; }
    public Interaction<BuildingViewModel, BuildingViewModel?> ShowBuildingDialog { get; }
    public Interaction<BuyerViewModel, BuyerViewModel?> ShowBuyerDialog { get; }
    public Interaction<DistrictViewModel, DistrictViewModel?> ShowDistrictDialog { get; }
    public Interaction<OrganizationViewModel, OrganizationViewModel?> ShowOrganizationDialog { get; }
    public Interaction<PrivatizedViewModel, PrivatizedViewModel?> ShowPrivatizedDialog { get; }


    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowAuctionDialog = new Interaction<AuctionViewModel, AuctionViewModel?>();
        ShowBuildingDialog = new Interaction<BuildingViewModel, BuildingViewModel?>();
        ShowBuyerDialog = new Interaction<BuyerViewModel, BuyerViewModel?>();
        ShowDistrictDialog = new Interaction<DistrictViewModel, DistrictViewModel?>();
        ShowOrganizationDialog = new Interaction<OrganizationViewModel, OrganizationViewModel?>();
        ShowPrivatizedDialog = new Interaction<PrivatizedViewModel, PrivatizedViewModel?>();


        OnAddAuctionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var auctionViewModel = await ShowAuctionDialog.Handle(new AuctionViewModel());
            if (auctionViewModel != null)
            {
                var newAuction = await _apiClient.AddAuctionAsync(_mapper.Map<AuctionPostDto>(auctionViewModel));
                Auctions.Add(_mapper.Map<AuctionViewModel>(newAuction));
            }
        });

        OnUpdateAuctionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var auctionViewModel = await ShowAuctionDialog.Handle(_selectedAuction!);
            if (auctionViewModel != null)
            {
                var newBuilding = await _apiClient.UpdateAuctionAsync(SelectedAuction!.AuctionId,
                    _mapper.Map<AuctionPostDto>(SelectedAuction));
                _mapper.Map(auctionViewModel, SelectedAuction);
            }
        }, this.WhenAnyValue(vm => vm.SelectedAuction).Select(selectedAuction => selectedAuction != null));

        OnDeleteAuctionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteAuctionAsync(SelectedAuction!.AuctionId);
            Auctions.Remove(SelectedAuction);
        }, this.WhenAnyValue(vm => vm.SelectedAuction).Select(selectedAuction => selectedAuction != null));

        OnAddBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var buildingViewModel = await ShowBuildingDialog.Handle(new BuildingViewModel());
            if (buildingViewModel != null)
            {
                var newBuilding = await _apiClient.AddBuildingAsync(_mapper.Map<BuildingPostDto>(buildingViewModel));
                Buildings.Add(_mapper.Map<BuildingViewModel>(newBuilding));
            }
        });

        OnUpdateBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var buildingViewModel = await ShowBuildingDialog.Handle(_selectedBuilding!);
            if (buildingViewModel != null)
            {
                var newBuilding = await _apiClient.UpdateBuildingAsync(SelectedBuilding!.RegistrationNumber,
                    _mapper.Map<BuildingPostDto>(SelectedBuilding));
                _mapper.Map(buildingViewModel, SelectedBuilding);
            }
        }, this.WhenAnyValue(vm => vm.SelectedBuilding).Select(selectedBuilding => selectedBuilding != null));

        OnDeleteBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteBuildingAsync(SelectedBuilding!.RegistrationNumber);
            Buildings.Remove(SelectedBuilding);
        }, this.WhenAnyValue(vm => vm.SelectedBuilding).Select(selectedBuilding => selectedBuilding != null));

        OnAddBuyerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var buyerViewModel = await ShowBuyerDialog.Handle(new BuyerViewModel());
            if (buyerViewModel != null)
            {
                var newBuyer = await _apiClient.AddBuyerAsync(_mapper.Map<BuyerPostDto>(buyerViewModel));
                Buyers.Add(_mapper.Map<BuyerViewModel>(newBuyer));
            }
        });

        OnUpdateBuyerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var buyerViewModel = await ShowBuyerDialog.Handle(_selectedBuyer!);
            if (buyerViewModel != null)
            {
                var newBuyer = await _apiClient.UpdateBuyerAsync(SelectedBuyer!.BuyerId,
                    _mapper.Map<BuyerPostDto>(SelectedBuyer));
                _mapper.Map(buyerViewModel, SelectedBuyer);
            }
        }, this.WhenAnyValue(vm => vm.SelectedBuyer).Select(selectedBuyer => selectedBuyer != null));

        OnDeleteBuyerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteBuyerAsync(SelectedBuyer!.BuyerId);
            Buyers.Remove(SelectedBuyer);
        }, this.WhenAnyValue(vm => vm.SelectedBuyer).Select(selectedBuyer => selectedBuyer != null));

        OnAddDistrictCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var districtViewModel = await ShowDistrictDialog.Handle(new DistrictViewModel());
            if (districtViewModel != null)
            {
                var newDistrict = await _apiClient.AddDistrictAsync(_mapper.Map<DistrictPostDto>(districtViewModel));
                Districts.Add(_mapper.Map<DistrictViewModel>(newDistrict));
            }
        });

        OnUpdateDistrictCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var districtViewModel = await ShowDistrictDialog.Handle(_selectedDistrict!);
            if (districtViewModel != null)
            {
                var newDistrict = await _apiClient.UpdateDistrictAsync(SelectedDistrict!.DistrictId,
                    _mapper.Map<DistrictPostDto>(SelectedDistrict));
                _mapper.Map(districtViewModel, SelectedDistrict);
            }
        }, this.WhenAnyValue(vm => vm.SelectedDistrict).Select(selectedDistrict => selectedDistrict != null));

        OnDeleteDistrictCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDistrictAsync(SelectedDistrict!.DistrictId);
            Districts.Remove(SelectedDistrict);
        }, this.WhenAnyValue(vm => vm.SelectedDistrict).Select(selectedDistrict => selectedDistrict != null));

        OnAddOrganizationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var organizationViewModel = await ShowOrganizationDialog.Handle(new OrganizationViewModel());
            if (organizationViewModel != null)
            {
                var newOrganization = await _apiClient.AddOrganizationAsync(_mapper.Map<OrganizationPostDto>(organizationViewModel));
                Organizations.Add(_mapper.Map<OrganizationViewModel>(newOrganization));
            }
        });

        OnUpdateOrganizationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var organizationViewModel = await ShowOrganizationDialog.Handle(SelectedOrganization!);
            if (organizationViewModel != null)
            {
                var newOrganization = await _apiClient.UpdateOrganizationAsync(SelectedOrganization!.OrganizationId,
                    _mapper.Map<OrganizationPostDto>(SelectedOrganization));
                _mapper.Map(organizationViewModel, SelectedOrganization);
            }
        }, this.WhenAnyValue(vm => vm.SelectedOrganization).Select(selectedOrganization => selectedOrganization != null));

        OnDeleteOrganizationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteOrganizationAsync(SelectedOrganization!.OrganizationId);
            Organizations.Remove(SelectedOrganization);
        }, this.WhenAnyValue(vm => vm.SelectedOrganization).Select(selectedOrganization => selectedOrganization != null));

        OnAddPrivatizedCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var privatizedViewModel = await ShowPrivatizedDialog.Handle(new PrivatizedViewModel());
            if (privatizedViewModel != null)
            {
                var newPrivatized = await _apiClient.AddPrivatizedAsync(_mapper.Map<PrivatizedPostDto>(privatizedViewModel));
                Privatized.Add(_mapper.Map<PrivatizedViewModel>(newPrivatized));
            }
        });

        OnUpdatePrivatizedCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var privatizedViewModel = await ShowPrivatizedDialog.Handle(SelectedPrivatized!);
            if (privatizedViewModel != null)
            {
                var newPrivatized = await _apiClient.UpdatePrivatizedAsync(SelectedPrivatized!.RegistrationNumber,
                    _mapper.Map<PrivatizedPostDto>(SelectedPrivatized));
                _mapper.Map(privatizedViewModel, SelectedPrivatized);
            }
        }, this.WhenAnyValue(vm => vm.SelectedPrivatized).Select(selectedPrivatized => selectedPrivatized != null));

        OnDeletePrivatizedCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeletePrivatizedAsync(SelectedPrivatized!.RegistrationNumber);
            Privatized.Remove(SelectedPrivatized);
        }, this.WhenAnyValue(vm => vm.SelectedPrivatized).Select(selectedPrivatized => selectedPrivatized != null));


        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }

    private async void LoadDataAsync()
    {

        var auctions = await _apiClient.GetAuctionsAsync();
        foreach (var auction in auctions)
        {
            Auctions.Add(_mapper.Map<AuctionViewModel>(auction));
        }

        var buildings = await _apiClient.GetBuildingsAsync();
        foreach (var building in buildings)
        {
            Buildings.Add(_mapper.Map<BuildingViewModel>(building));
        }

        var buyers = await _apiClient.GetBuyersAsync();
        foreach (var buyer in buyers)
        {
            Buyers.Add(_mapper.Map<BuyerViewModel>(buyer));
        }

        var districts = await _apiClient.GetDistrictsAsync();
        foreach (var district in districts)
        {
            Districts.Add(_mapper.Map<DistrictViewModel>(district));
        }

        var organizations = await _apiClient.GetOrganizationsAsync();
        foreach (var organization in organizations)
        {
            Organizations.Add(_mapper.Map<OrganizationViewModel>(organization));
        }

        var allPrivatized = await _apiClient.GetPrivatizedAllAsync();
        foreach (var privatized in allPrivatized)
        {
            Privatized.Add(_mapper.Map<PrivatizedViewModel>(privatized));
        }

        var auctionsNotAllLotsSold = await _apiClient.GetAuctionsNotAllLotsSoldAsync();
        foreach (var auction in auctionsNotAllLotsSold)
        {
            AuctionsNotAllLotsSold.Add(_mapper.Map<AuctionViewModel>(auction));
        }

        var topBuyersByExpenses = await _apiClient.GetTopBuyersByExpensesAsync();
        foreach (var buyer in topBuyersByExpenses)
        {
            TopBuyersByExpenses.Add(_mapper.Map<BuyerExpensesViewModel>(buyer));
        }

        var auctionsWithHighestIncome = await _apiClient.GetAuctionsWithHighestIncomeAsync();
        foreach (var auction in auctionsWithHighestIncome)
        {
            AuctionsWithHighestIncome.Add(_mapper.Map<AuctionIncomeViewModel>(auction));
        }
    }
}
