using AirplaneBookingSystem.Client.ViewModels;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;

namespace AirplaneBookingSystem.Client.Views;
public partial class TicketWindow : ReactiveWindow<TicketViewModel>
{
    public TicketWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }
    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
