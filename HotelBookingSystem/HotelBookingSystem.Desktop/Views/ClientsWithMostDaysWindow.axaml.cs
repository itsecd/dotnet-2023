using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using HotelBookingSystem.Desktop.ViewModels;

namespace HotelBookingSystem.Desktop.Views;
public partial class ClientsWithMostDaysWindow : ReactiveWindow<ClientsWithMostDaysViewModel>
{
    public ClientsWithMostDaysWindow()
    {
        InitializeComponent();
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs args)
    {
        Close();
    }
}
