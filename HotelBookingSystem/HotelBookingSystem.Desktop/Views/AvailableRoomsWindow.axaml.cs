using Avalonia.Controls;
using Avalonia.Interactivity;

namespace HotelBookingSystem.Desktop.Views;
public partial class AvailableRoomsWindow : Window
{
    public AvailableRoomsWindow()
    {
        InitializeComponent();
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs args)
    {
        Close();
    }
}
