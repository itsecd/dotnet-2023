using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;
using TransportManagment.Client.ViewModels;

namespace TransportManagment.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowDriverDialog.RegisterHandler(ShowDriverDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowTransportDialog.RegisterHandler(ShowTransportDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowRouteDialog.RegisterHandler(ShowRouteDialogAsync)));
    }
    private async Task ShowDriverDialogAsync(InteractionContext<DriverViewModel, DriverViewModel?> interaction)
    {
        var dialog = new DriverWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<DriverViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowTransportDialogAsync(InteractionContext<TransportViewModel, TransportViewModel?> interaction)
    {
        var dialog = new TransportWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<TransportViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowRouteDialogAsync(InteractionContext<RouteViewModel, RouteViewModel?> interaction)
    {
        var dialog = new RouteWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<RouteViewModel?>(this);
        interaction.SetOutput(result);
    }
}