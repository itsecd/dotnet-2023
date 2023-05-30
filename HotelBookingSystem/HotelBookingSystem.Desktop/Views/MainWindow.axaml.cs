using Avalonia.Controls;
using Avalonia.ReactiveUI;
using HotelBookingSystem.Desktop.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace HotelBookingSystem.Desktop.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowHotelDialog.RegisterHandler(ShowHotelDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowRoomDialog.RegisterHandler(ShowRoomDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowLodgerDialog.RegisterHandler(ShowLodgerDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowBroomDialog.RegisterHandler(ShowBookedRoomsDialogAsync)));

        this.WhenActivated(d => d(ViewModel!.ShowInfoHotels.RegisterHandler(ShowInfoHotelsAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowInfoClientsInHotel.RegisterHandler(ShowInfoClientsInHotelAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowTop5MostBooked.RegisterHandler(ShowTop5MostBookedAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowAvailableRooms.RegisterHandler(ShowAvailableRoomsAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowClientsWithMostDays.RegisterHandler(ShowClientsWithMostDaysAsync)));
    }

    private async Task ShowHotelDialogAsync(InteractionContext<HotelViewModel, HotelViewModel?> interaction)
    {
        var dialog = new AddHotelWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<HotelViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowRoomDialogAsync(InteractionContext<RoomViewModel, RoomViewModel?> interaction)
    {
        var dialog = new AddRoomWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<RoomViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowLodgerDialogAsync(InteractionContext<LodgerViewModel, LodgerViewModel?> interaction)
    {
        var dialog = new AddLodgerWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<LodgerViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowBookedRoomsDialogAsync(InteractionContext<BookedRoomsViewModel, BookedRoomsViewModel?> interaction)
    {
        var dialog = new AddBookedRoomsWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<BookedRoomsViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowInfoHotelsAsync(InteractionContext<InfoHotelsViewModel, InfoHotelsViewModel?> interaction)
    {
        var dialog = new InfoHotelsWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<InfoHotelsViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowInfoClientsInHotelAsync(InteractionContext<InfoClientsInHotelViewModel, InfoClientsInHotelViewModel?> interaction)
    {
        var dialog = new InfoClientsInHotelWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<InfoClientsInHotelViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowTop5MostBookedAsync(InteractionContext<Top5MostBookedViewModel, Top5MostBookedViewModel?> interaction)
    {
        var dialog = new Top5MostBookedWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<Top5MostBookedViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowAvailableRoomsAsync(InteractionContext<AvailableRoomsViewModel, AvailableRoomsViewModel?> interaction)
    {
        var dialog = new AvailableRoomsWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<AvailableRoomsViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowClientsWithMostDaysAsync(InteractionContext<ClientsWithMostDaysViewModel, ClientsWithMostDaysViewModel?> interaction)
    {
        var dialog = new ClientsWithMostDaysWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ClientsWithMostDaysViewModel?>(this);
        interaction.SetOutput(result);
    }
}