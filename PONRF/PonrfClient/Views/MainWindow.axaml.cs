using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using PonrfClient.ViewModels;

namespace PonrfClient.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void PrivatizedBuilding_Button_Click(object sender, RoutedEventArgs e)
    {
        var showPrivatizedBuildingWindow = new ShowPrivatizedBuildingWindow
        {
            DataContext = new ShowPrivatizedBuildingViewModel(),
        };
        showPrivatizedBuildingWindow.Show();
    }

    public void Building_Button_Click(object sender, RoutedEventArgs e)
    {
        var showBuildingWindow = new ShowBuildingWindow
        {
            DataContext = new ShowBuildingViewModel(),
        };
        showBuildingWindow.Show();
    }

    public void Auction_Button_Click(object sender, RoutedEventArgs e)
    {
        var showAuctionWindow = new ShowAuctionWindow
        {
            DataContext = new ShowAuctionViewModel(),
        };
        showAuctionWindow.Show();
    }

    public void Customer_Button_Click(object sender, RoutedEventArgs e)
    {
        var showCustomerWindow = new ShowCustomerWindow
        {
            DataContext = new ShowCustomerViewModel(),
        };
        showCustomerWindow.Show();
    }

    public void ViewAllCustomer_Button_Click(object sender, RoutedEventArgs e)
    {
        var showViewAllCustomerWindow = new ShowViewAllCustomerWindow
        {
            DataContext = new ShowViewAllCustomerViewModel(),
        };
        showViewAllCustomerWindow.Show();
    }

    public void AuctionsWithoutFullSales_Button_Click(object sender, RoutedEventArgs e)
    {
        var showAuctiosWithoutFullSalesnWindow = new ShowAuctionsWithoutFullSalesWindow
        {
            DataContext = new ShowAuctionsWithoutFullSalesViewModel(),
        };
        showAuctiosWithoutFullSalesnWindow.Show();
    }

    public void TopCustomer_Button_Click(object sender, RoutedEventArgs e)
    {
        var showTopCustomerWindow = new ShowTopCustomerWindow
        {
            DataContext = new ShowTopCustomerViewModel(),
        };
        showTopCustomerWindow.Show();
    }

    public void TopAuction_Button_Click(object sender, RoutedEventArgs e)
    {
        var showTopAuctionWindow = new ShowTopAuctionWindow
        {
            DataContext = new ShowTopAuctionViewModel(),
        };
        showTopAuctionWindow.Show();
    }
}