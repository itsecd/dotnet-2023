using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Airline.Client.ViewModels;
using ReactiveUI;
using System;


namespace Airline.Client.Views;
public partial class Airplane : ReactiveWindow<AirplaneViewModel>
{
    public Airplane()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitAirplaneCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
