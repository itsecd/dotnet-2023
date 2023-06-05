using Avalonia.Controls;
using Avalonia.ReactiveUI;
using MusicMarket.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace MusicMarket.Client.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowCustomerDialog.RegisterHandler(ShowCustomerDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowProductDialog.RegisterHandler(ShowProductDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowPurchaseDialog.RegisterHandler(ShowPurchaseAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowSellerDialog.RegisterHandler(ShowSellerDialogAsync)));
    }
    private async Task ShowCustomerDialogAsync(InteractionContext<CustomerViewModel, CustomerViewModel?> interaction)
    {
        var dialog = new CustomerWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<CustomerViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowProductDialogAsync(InteractionContext<ProductViewModel, ProductViewModel?> interaction)
    {
        var dialog = new ProductWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ProductViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowPurchaseAsync(InteractionContext<PurchaseViewModel, PurchaseViewModel?> interaction)
    {
        var dialog = new PurchaseWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<PurchaseViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowSellerDialogAsync(InteractionContext<SellerViewModel, SellerViewModel?> interaction)
    {
        var dialog = new SellerWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<SellerViewModel?>(this);
        interaction.SetOutput(result);
    }
}