using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using HotelBookingSystem.Desktop.ViewModels;
using ReactiveUI;

namespace HotelBookingSystem.Desktop.Views;
public partial class InfoHotelsWindow : ReactiveWindow<InfoHotelsViewModel>
{
    public InfoHotelsWindow() 
    {
        InitializeComponent();
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs args)
    {
        Close();
    }
}
