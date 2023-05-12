using Airlines.Client.ViewModels;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;

namespace Airlines.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowPassengerDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<PassengerViewModel, PassengerViewModel?> interaction)
    {
        var dialog = new PassengerWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<PassengerViewModel?>(this);
        interaction.SetOutput(result);
    }
}