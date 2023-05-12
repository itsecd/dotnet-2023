using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;
using TaxiDepo.Client.ViewModels;

namespace TaxiDepo.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowCarDialog.RegisterHandler(ShowCarDialogAsync)));
        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowDriverDialog.RegisterHandler(ShowDriverDialogAsync)));
        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowRideDialog.RegisterHandler(ShowRideDialogAsync)));
        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowUserDialog.RegisterHandler(ShowUserDialogAsync)));
    }

    private async Task ShowCarDialogAsync(InteractionContext<CarViewModel, CarViewModel?> interaction)
    {
        var dialog = new CarWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<CarViewModel?>(this);
        interaction.SetOutput(result);
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

    private async Task ShowRideDialogAsync(InteractionContext<RideViewModel, RideViewModel?> interaction)
    {
        var dialog = new RideWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<RideViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowUserDialogAsync(InteractionContext<UserViewModel, UserViewModel?> interaction)
    {
        var dialog = new UserWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<UserViewModel?>(this);
        interaction.SetOutput(result);
    }
}