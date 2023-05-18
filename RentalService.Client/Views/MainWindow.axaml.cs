using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RentalService.Client.ViewModels;

namespace RentalService.Client.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowClientDialog.RegisterHandler(ShowClientDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowIssuedCarDialog.RegisterHandler(ShowIssuedCarDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowRefundInformationDialog.RegisterHandler(ShowRefundInformationDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowRentalInformationDialog.RegisterHandler(ShowRentalInformationDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowRentalPointDialog.RegisterHandler(ShowRentalPointDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowVehicleModelDialog.RegisterHandler(ShowVehicleModelDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowVehicleDialog.RegisterHandler(ShowVehicleDialogAsync)));
    }
    
    private async Task ShowClientDialogAsync(InteractionContext<ClientViewModel, ClientViewModel?> interaction)
    {
        var dialog = new ClientWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ClientViewModel?>(this);
        interaction.SetOutput(result);
    }
    
    private async Task ShowIssuedCarDialogAsync(InteractionContext<IssuedCarViewModel, IssuedCarViewModel?> interaction)
    {
        var dialog = new IssuedCarWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<IssuedCarViewModel?>(this);
        interaction.SetOutput(result);
    }
    
    private async Task ShowRefundInformationDialogAsync(InteractionContext<RefundInformationViewModel, RefundInformationViewModel?> interaction)
    {
        var dialog = new RefundInformationWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<RefundInformationViewModel?>(this);
        interaction.SetOutput(result);
    }
    
    private async Task ShowRentalInformationDialogAsync(InteractionContext<RentalInformationViewModel, RentalInformationViewModel?> interaction)
    {
        var dialog = new RentalInformationWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<RentalInformationViewModel?>(this);
        interaction.SetOutput(result);
    }
    
    private async Task ShowRentalPointDialogAsync(InteractionContext<RentalPointViewModel, RentalPointViewModel?> interaction)
    {
        var dialog = new RentalPointWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<RentalPointViewModel?>(this);
        interaction.SetOutput(result);
    }
    
    private async Task ShowVehicleModelDialogAsync(InteractionContext<VehicleModelViewModel, VehicleModelViewModel?> interaction)
    {
        var dialog = new VehicleModelWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<VehicleModelViewModel?>(this);
        interaction.SetOutput(result);
    }
    
    private async Task ShowVehicleDialogAsync(InteractionContext<VehicleViewModel, VehicleViewModel?> interaction)
    {
        var dialog = new VehicleWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<VehicleViewModel?>(this);
        interaction.SetOutput(result);
    }
}