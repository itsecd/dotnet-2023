using Avalonia.ReactiveUI;
using PoliclinicClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace PoliclinicClient.Views;
public partial class ShowReceptionTableWindow : ReactiveWindow<ShowReceptionTableViewModel>
{
    public ShowReceptionTableWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowReceptionDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<ReceptionViewModel, ReceptionViewModel?> interaction)
    {
        var dialog = new ReceptionWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ReceptionViewModel?>(this);
        interaction.SetOutput(result);
    }

}
