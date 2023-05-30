using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using HotelBookingSystem.Desktop.ViewModels;
using ReactiveUI;
using System;

namespace HotelBookingSystem.Desktop.Views;
public partial class AddRoomWindow : ReactiveWindow<RoomViewModel>
{
    public AddRoomWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OkCommand.Subscribe(Close)));
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs args)
    {
        Close();
    }
}
