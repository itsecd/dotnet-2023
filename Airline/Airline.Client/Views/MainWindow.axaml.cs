using Airline.Client.ViewModels;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;

namespace Airline.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel !.ShowAirplaneDialog.RegisterHandler(ShowDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowPassengerDialog.RegisterHandler(ShowDialogPassengerAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowTicketDialog.RegisterHandler(ShowDialogTicketAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<AirplaneViewModel, AirplaneViewModel?> interaction)
    {
        var dialog = new Airplane
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<AirplaneViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowDialogPassengerAsync(InteractionContext<PassengerViewModel, PassengerViewModel?> interaction)
    {
        var dialog = new Passenger
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<PassengerViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowDialogTicketAsync(InteractionContext<TicketViewModel, TicketViewModel?> interaction)
    {
        var dialog = new Ticket
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<TicketViewModel?>(this);
        interaction.SetOutput(result);
    }
}