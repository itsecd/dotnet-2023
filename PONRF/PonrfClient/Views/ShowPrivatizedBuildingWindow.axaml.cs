using Avalonia.ReactiveUI;
using PonrfClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace PonrfClient.Views;
public partial class ShowPrivatizedBuildingWindow : ReactiveWindow<ShowPrivatizedBuildingViewModel>
{
    public ShowPrivatizedBuildingWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowPrivatizedBuildingDialog.RegisterHandler(PrivatizedBuildingDialogAsync)));
    }

    private async Task PrivatizedBuildingDialogAsync(InteractionContext<PrivatizedBuildingViewModel, PrivatizedBuildingViewModel?> interaction)
    {
        var dialogPrivatizedBuilding = new PrivatizedBuildingWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialogPrivatizedBuilding.ShowDialog<PrivatizedBuildingViewModel?>(this);
        interaction.SetOutput(result);
    }
}
