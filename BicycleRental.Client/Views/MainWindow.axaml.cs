using Avalonia.Controls;
using Avalonia.ReactiveUI;
using BicycleRental.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace BicycleRental.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowBicycleDialog.RegisterHandler(ShowBicycleDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowCustomerDialog.RegisterHandler(ShowCustomerDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowRentalDialog.RegisterHandler(ShowRentalDialogAsync)));
    }

    private async Task ShowBicycleDialogAsync(InteractionContext<BicycleViewModel, BicycleViewModel?> interaction)
    {
        var dialog = new BicycleWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<BicycleViewModel?>(this);
        interaction.SetOutput(result);
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

    private async Task ShowRentalDialogAsync(InteractionContext<BicycleRentalViewModel, BicycleRentalViewModel?> interaction)
    {
        var dialog = new RentalWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<BicycleRentalViewModel?>(this);
        interaction.SetOutput(result);
    }
}