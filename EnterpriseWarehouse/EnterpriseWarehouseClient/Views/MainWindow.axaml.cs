using Avalonia.ReactiveUI;
using EnterpriseWarehouseClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace EnterpriseWarehouseClient.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowProductDialog.RegisterHandler(ShowProductDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowStorageCellDialog.RegisterHandler(ShowStorageCellDialogAsync)));
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

    private async Task ShowStorageCellDialogAsync(InteractionContext<StorageCellViewModel, StorageCellViewModel?> interaction)
    {
        var dialog = new StorageCellWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<StorageCellViewModel?>(this);
        interaction.SetOutput(result);
    }
}