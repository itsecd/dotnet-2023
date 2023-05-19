using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Taxi.Client.ViewModels;

namespace Taxi.Client.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowDriverDialog.RegisterHandler(ShowDriverDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowPassengerDialog.RegisterHandler(ShowPassengerDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowVehicleDialog.RegisterHandler(ShowVehicleDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowVehicleClassificationDialog.RegisterHandler(ShowVehicleClassificationDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowRideDialog.RegisterHandler(ShowRideDialogAsync)));
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
    
    private async Task ShowPassengerDialogAsync(InteractionContext<PassengerViewModel, PassengerViewModel?> interaction)
    {
        var dialog = new PassengerWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<PassengerViewModel?>(this);
        interaction.SetOutput(result);
    }
    
    private async Task ShowVehicleDialogAsync(InteractionContext<VehicleViewModel, VehicleViewModel?> interaction)
    {
        var dialog = new VehicleWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<VehicleViewModel?>(this);
        interaction.SetOutput(result);
    }
    
    
    private async Task ShowVehicleClassificationDialogAsync(InteractionContext<VehicleClassificationViewModel, VehicleClassificationViewModel?> interaction)
    {
        var dialog = new VehicleClassificationWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<VehicleClassificationViewModel?>(this);
        interaction.SetOutput(result);
    }
    
    private async Task ShowRideDialogAsync(InteractionContext<RideViewModel, RideViewModel?> interaction)
    {
        var dialog = new RideWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<RideViewModel?>(this);
        interaction.SetOutput(result);
    }
}