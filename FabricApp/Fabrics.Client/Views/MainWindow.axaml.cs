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

        this.WhenActivated(d => d(ViewModel!.ShowFabricDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<FabricViewModel, FabricViewModel?> interaction)
    {
        var dialog = new FabricWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<FabricViewModel?>(this);
        interaction.SetOutput(result);
    }
}