using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Warehouse.Client.ViewModels;

namespace Warehouse.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowProductDialog.RegisterHandler(ShowProductDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowSupplyDialog.RegisterHandler(ShowSupplyDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowWarehouseCellDialog.RegisterHandler(ShowWarehouseCellDialogAsync)));
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

    private async Task ShowSupplyDialogAsync(InteractionContext<SupplyViewModel, SupplyViewModel?> interaction)
    {
        var dialog = new SupplyWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<SupplyViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowWarehouseCellDialogAsync(InteractionContext<WarehouseCellViewModel, WarehouseCellViewModel?> interaction)
    {
        var dialog = new WarehouseCellWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<WarehouseCellViewModel?>(this);
        interaction.SetOutput(result);
    }
}