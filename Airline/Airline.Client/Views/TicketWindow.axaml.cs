using Airline.Client.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;

namespace Airline.Client.Views;
public partial class Ticket : ReactiveWindow<TicketViewModel>
{
    public Ticket()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitTicketCommand.Subscribe(Close)));
    }
    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}