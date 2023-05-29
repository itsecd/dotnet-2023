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

        this.WhenActivated(d => d(ViewModel!.ShowHotelDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<HotelViewModel, HotelViewModel?> interaction)
    {
        var dialog = new AddHotelWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<HotelViewModel?>(this);
        interaction.SetOutput(result);
    }
}