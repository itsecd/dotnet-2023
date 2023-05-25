using Avalonia.Controls;
using Avalonia.ReactiveUI;
using PonrfClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace PonrfClient.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowPrivatizedBuildingDialog.RegisterHandler(ShowPrivatizedBuildingDialogAsync)));
    }

    private async Task ShowPrivatizedBuildingDialogAsync(InteractionContext<PrivatizedBuildingViewModel, PrivatizedBuildingViewModel?> interaction)
    {
        var dialogPrivatizedBuilding = new PrivatizedBuildingWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialogPrivatizedBuilding.ShowDialog<PrivatizedBuildingViewModel?>(this);
        interaction.SetOutput(result);
    }
}