using Avalonia.ReactiveUI;
using PoliclinicClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace PoliclinicClient.Views;
public partial class ShowDoctorTableWindow : ReactiveWindow<ShowDoctorTableViewModel>
{
    public ShowDoctorTableWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowDoctorDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<DoctorViewModel, DoctorViewModel?> interaction)
    {
        var dialog = new DoctorWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<DoctorViewModel?>(this);
        interaction.SetOutput(result);
    }
}
