using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using HotelBookingSystem.Desktop.ViewModels;

namespace HotelBookingSystem.Desktop.Views;
public partial class InfoClientsInHotelWindow : ReactiveWindow<InfoClientsInHotelViewModel>
{
    public InfoClientsInHotelWindow()
    {
        InitializeComponent();
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs args)
    {
        Close();
    }
}
