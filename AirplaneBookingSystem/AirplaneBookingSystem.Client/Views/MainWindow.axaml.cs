using AirplaneBookingSystem.Client.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;

namespace AirplaneBookingSystem.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowAirplaneDialog.RegisterHandler(ShowDialogAsync)));
    }
    private async Task ShowDialogAsync(InteractionContext<AirplaneViewModel, AirplaneViewModel?> interaction)
    {
        var dialog = new AirplaneWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<AirplaneViewModel?>(this);
        interaction.SetOutput(result);
    }
}