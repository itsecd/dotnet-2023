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

        this.WhenActivated(d => d(ViewModel!.ShowProductDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<ProductViewModel, ProductViewModel?> interaction)
    {
        var dialog = new ProductWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ProductViewModel?>(this);
        interaction.SetOutput(result);
    }
}