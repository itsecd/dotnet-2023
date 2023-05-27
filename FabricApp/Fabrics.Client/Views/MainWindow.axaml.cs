using Avalonia.ReactiveUI;
using Fabrics.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace Fabrics.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowFabricDialog.RegisterHandler(ShowFabricDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowProviderDialog.RegisterHandler(ShowProviderDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowShipmentDialog.RegisterHandler(ShowShipmentDialogAsync)));
    }

    private async Task ShowFabricDialogAsync(InteractionContext<FabricViewModel, FabricViewModel?> interaction)
    {
        var dialog = new FabricWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<FabricViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowProviderDialogAsync(InteractionContext<ProviderViewModel, ProviderViewModel?> interaction)
    {
        var dialog = new ProviderWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ProviderViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowShipmentDialogAsync(InteractionContext<ShipmentViewModel, ShipmentViewModel?> interaction)
    {
        var dialog = new ShipmentWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ShipmentViewModel?>(this);
        interaction.SetOutput(result);
    }
}