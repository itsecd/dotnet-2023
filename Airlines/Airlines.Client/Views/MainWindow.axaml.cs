using Airlines.Client.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;

namespace Airlines.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowPassengerDialog.RegisterHandler(ShowPassengerDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowTicketDialog.RegisterHandler(ShowTicketDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowAirplaneDialog.RegisterHandler(ShowAirplaneDialogAsync)));
    }

    private async Task ShowPassengerDialogAsync(InteractionContext<PassengerViewModel, PassengerViewModel?> interaction)
    {
        var dialogPassenger = new PassengerWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialogPassenger.ShowDialog<PassengerViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowTicketDialogAsync(InteractionContext<TicketViewModel, TicketViewModel?> interaction)
    {
        var dialogTicket = new TicketWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialogTicket.ShowDialog<TicketViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowAirplaneDialogAsync(InteractionContext<AirplaneViewModel, AirplaneViewModel?> interaction)
    {
        var dialogAirplane = new AirplaneWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialogAirplane.ShowDialog<AirplaneViewModel?>(this);
        interaction.SetOutput(result);
    }
}