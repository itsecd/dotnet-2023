using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using PonrfClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace PonrfClient.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowAuctionDialog.RegisterHandler(ShowAuctionDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowBuildingDialog.RegisterHandler(ShowBuildingDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowCustomerDialog.RegisterHandler(ShowCustomerDialogAsync)));
    }

    private async Task ShowAuctionDialogAsync(InteractionContext<AuctionViewModel, AuctionViewModel?> interaction)
    {
        var dialogAuction = new AuctionWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialogAuction.ShowDialog<AuctionViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowBuildingDialogAsync(InteractionContext<BuildingViewModel, BuildingViewModel?> interaction)
    {
        var dialogBuilding = new BuildingWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialogBuilding.ShowDialog<BuildingViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowCustomerDialogAsync(InteractionContext<CustomerViewModel, CustomerViewModel?> interaction)
    {
        var dialogCustomer = new CustomerWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialogCustomer.ShowDialog<CustomerViewModel?>(this);
        interaction.SetOutput(result);
    }

    public void PrivatizedBuilding_Button_Click(object sender, RoutedEventArgs e)
    {
        var showPrivatizedBuildingWindow = new ShowPrivatizedBuildingWindow();
        showPrivatizedBuildingWindow.Show();
    }
}