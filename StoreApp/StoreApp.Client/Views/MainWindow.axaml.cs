using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using StoreApp.Client.ViewModels;
using System.Threading.Tasks;


namespace StoreApp.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowProductDialog.RegisterHandler(ShowDialogProductAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowCustomerDialog.RegisterHandler(ShowDialogCustomerAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowStoreDialog.RegisterHandler(ShowDialogStoreAsync)));
    }
    private async Task ShowDialogProductAsync(InteractionContext<ProductViewModel, ProductViewModel?> interaction)
    {
        var dialog = new ProductWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ProductViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowDialogCustomerAsync(InteractionContext<CustomerViewModel, CustomerViewModel?> interaction)
    {
        var dialog = new CustomerWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<CustomerViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowDialogStoreAsync(InteractionContext<StoreViewModel, StoreViewModel?> interaction)
    {
        var dialog = new StoreWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<StoreViewModel?>(this);
        interaction.SetOutput(result);
    }
}