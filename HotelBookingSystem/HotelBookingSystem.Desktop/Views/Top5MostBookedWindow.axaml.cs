using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using HotelBookingSystem.Desktop.ViewModels;

namespace HotelBookingSystem.Desktop.Views;
public partial class Top5MostBookedWindow : ReactiveWindow<Top5MostBookedViewModel>
{
    public Top5MostBookedWindow()
    {
        InitializeComponent();
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs args)
    {
        Close();
    }
}
