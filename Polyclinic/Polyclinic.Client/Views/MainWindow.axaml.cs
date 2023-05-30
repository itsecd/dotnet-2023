using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using Polyclinic.Client.ViewModels;
using ReactiveUI;

namespace Polyclinic.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowPatientDialog.RegisterHandler(ShowDialogPatientAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowDoctorDialog.RegisterHandler(ShowDialogDoctorAsync)));
    }

    private async Task ShowDialogPatientAsync(InteractionContext<PatientViewModel, PatientViewModel?> interaction)
    {
        var dialog = new PatientWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<PatientViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowDialogDoctorAsync(InteractionContext<DoctorViewModel, DoctorViewModel?> interaction)
    {
        var dialog = new DoctorWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<DoctorViewModel?>(this);
        interaction.SetOutput(result);
    }
}