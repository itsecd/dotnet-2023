using Avalonia.Controls;
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