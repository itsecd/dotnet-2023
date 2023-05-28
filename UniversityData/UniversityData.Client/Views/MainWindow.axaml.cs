using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using UniversityData.Client.ViewModels;

namespace UniversityData.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowConstructionPropertyDialog.RegisterHandler(ShowDialogAsync)));
    }
    private async Task ShowDialogAsync(InteractionContext<ConstructionPropertyViewModel, ConstructionPropertyViewModel?> interaction)
    {
        var dialog = new ConstructionPropertyWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ConstructionPropertyViewModel?>(this);
        interaction.SetOutput(result);
    }
}
