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
}