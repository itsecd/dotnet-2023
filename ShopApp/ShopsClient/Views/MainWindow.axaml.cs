using Avalonia.ReactiveUI;
using ReactiveUI;
using ShopsClient.ViewModels;
using System.Threading.Tasks;

namespace ShopsClient.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowCustomerDialog.RegisterHandler(ShowCustomerDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowProductDialog.RegisterHandler(ShowProductDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowProductGroupDialog.RegisterHandler(ShowProductGroupDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowProductQuantityDialog.RegisterHandler(ShowProductQuantityDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowPurchaseRecordDialog.RegisterHandler(ShowPurchaseRecordAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowShopDialog.RegisterHandler(ShowShopDialogAsync)));
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
    private async Task ShowProductGroupDialogAsync(InteractionContext<ProductGroupViewModel, ProductGroupViewModel?> interaction)
    {
        var dialog = new ProductGroupWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ProductGroupViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowProductQuantityDialogAsync(InteractionContext<ProductQuantityViewModel, ProductQuantityViewModel?> interaction)
    {
        var dialog = new ProductQuantityWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ProductQuantityViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowPurchaseRecordAsync(InteractionContext<PurchaseRecordViewModel, PurchaseRecordViewModel?> interaction)
    {
        var dialog = new PurchaseRecordWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<PurchaseRecordViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowShopDialogAsync(InteractionContext<ShopViewModel, ShopViewModel?> interaction)
    {
        var dialog = new ShopWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ShopViewModel?>(this);
        interaction.SetOutput(result);
    }
}