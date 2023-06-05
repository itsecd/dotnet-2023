using Avalonia.ReactiveUI;
using PoliclinicClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace PoliclinicClient.Views;
public partial class ShowPatientTableWindow : ReactiveWindow<ShowPatientTableViewModel>
{
    public ShowPatientTableWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowPatientDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<PatientViewModel, PatientViewModel?> interaction)
    {
        var dialog = new PatientWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<PatientViewModel?>(this);
        interaction.SetOutput(result);
    }
}
