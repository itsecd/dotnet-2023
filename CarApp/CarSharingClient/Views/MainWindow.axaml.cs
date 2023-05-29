using Avalonia.Controls;
using Avalonia.ReactiveUI;
using CarSharingClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace CarSharingClient.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowCarDialog.RegisterHandler(ShowCarDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowRentalPointDialog.RegisterHandler(ShowRentalPointDialogAsync)));
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

    private async Task ShowRentalPointDialogAsync(InteractionContext<RentalPointViewModel, RentalPointViewModel?> interaction)
    {
        var dialog = new RentalPointWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<RentalPointViewModel?>(this);
        interaction.SetOutput(result);
    }
}