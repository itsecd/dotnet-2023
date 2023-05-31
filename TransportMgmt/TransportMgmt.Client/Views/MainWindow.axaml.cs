using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;
using TransportMgmt.Client.ViewModels;

namespace TransportMgmt.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowDriverDialog.RegisterHandler(ShowDriverDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowTripDialog.RegisterHandler(ShowTripDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowModelDialog.RegisterHandler(ShowModelDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowTransportDialog.RegisterHandler(ShowTransportDialogAsync)));
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
    private async Task ShowTripDialogAsync(InteractionContext<TripViewModel, TripViewModel?> interaction)
    {
        var dialog = new TripWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<TripViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowModelDialogAsync(InteractionContext<ModelViewModel, ModelViewModel?> interaction)
    {
        var dialog = new ModelWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ModelViewModel?>(this);
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

}