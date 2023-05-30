using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Microsoft.VisualBasic;
using Polyclinic.Client.ViewModels;
using ReactiveUI;

namespace Polyclinic.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowPatientDialog.RegisterHandler(ShowDialogPatientAsync)));
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
}   