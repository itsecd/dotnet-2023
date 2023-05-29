using Avalonia.ReactiveUI;
using NonResidentialFund.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace NonResidentialFund.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowAuctionDialog.RegisterHandler(ShowAuctionDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowBuildingDialog.RegisterHandler(ShowBuildingDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowBuyerDialog.RegisterHandler(ShowBuyerDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowDistrictDialog.RegisterHandler(ShowDistrictDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowOrganizationDialog.RegisterHandler(ShowOrganizationDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowPrivatizedDialog.RegisterHandler(ShowPrivatizedDialogAsync)));
    }

    private async Task ShowAuctionDialogAsync(InteractionContext<AuctionViewModel, AuctionViewModel?> interaction)
    {
        var dialog = new AuctionWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<AuctionViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowBuildingDialogAsync(InteractionContext<BuildingViewModel, BuildingViewModel?> interaction)
    {
        var dialog = new BuildingWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<BuildingViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowBuyerDialogAsync(InteractionContext<BuyerViewModel, BuyerViewModel?> interaction)
    {
        var dialog = new BuyerWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<BuyerViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowDistrictDialogAsync(InteractionContext<DistrictViewModel, DistrictViewModel?> interaction)
    {
        var dialog = new DistrictWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<DistrictViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowOrganizationDialogAsync(InteractionContext<OrganizationViewModel, OrganizationViewModel?> interaction)
    {
        var dialog = new OrganizationWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<OrganizationViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowPrivatizedDialogAsync(InteractionContext<PrivatizedViewModel, PrivatizedViewModel?> interaction)
    {
        var dialog = new PrivatizedWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<PrivatizedViewModel?>(this);
        interaction.SetOutput(result);
    }
}