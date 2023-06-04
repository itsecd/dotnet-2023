using Airline.Client.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;

namespace Airline.Client.Views;
public partial class Passenger : ReactiveWindow<PassengerViewModel>
{
    public Passenger()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitPassengerCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}