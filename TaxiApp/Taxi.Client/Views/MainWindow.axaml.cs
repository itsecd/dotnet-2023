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

        this.WhenActivated(d => d(ViewModel!.ShowDriverDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<DriverViewModel, DriverViewModel?> interaction)
    {
        var dialog = new DriverWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<DriverViewModel?>(this);
        interaction.SetOutput(result);
    }
}