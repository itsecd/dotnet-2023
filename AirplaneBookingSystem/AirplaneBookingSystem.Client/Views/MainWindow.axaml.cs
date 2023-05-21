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
        this.WhenActivated(d => d(ViewModel!.ShowFlightDialog.RegisterHandler(ShowDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowClientDialog.RegisterHandler(ShowDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowTicketDialog.RegisterHandler(ShowDialogAsync)));
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
    private async Task ShowDialogAsync(InteractionContext<FlightViewModel, FlightViewModel?> interaction)
    {
        var dialog = new FlightWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<FlightViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowDialogAsync(InteractionContext<TicketViewModel, TicketViewModel?> interaction)
    {
        var dialog = new TicketWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<TicketViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowDialogAsync(InteractionContext<ClientViewModel, ClientViewModel?> interaction)
    {
        var dialog = new ClientWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ClientViewModel?>(this);
        interaction.SetOutput(result);
    }
}