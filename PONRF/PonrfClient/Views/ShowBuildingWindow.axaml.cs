using Avalonia.ReactiveUI;
using PonrfClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace PonrfClient.Views;
public partial class ShowBuildingWindow : ReactiveWindow<ShowBuildingViewModel>
{
    public ShowBuildingWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowBuildingDialog.RegisterHandler(BuildingDialogAsync)));
    }

    private async Task BuildingDialogAsync(InteractionContext<BuildingViewModel, BuildingViewModel?> interaction)
    {
        var dialogBuilding = new BuildingWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialogBuilding.ShowDialog<BuildingViewModel?>(this);
        interaction.SetOutput(result);
    }
}
