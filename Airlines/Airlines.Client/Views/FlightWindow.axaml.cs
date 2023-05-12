using Airlines.Client.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using System;
using ReactiveUI;

namespace Airlines.Client.Views;
public partial class FlightWindow : ReactiveWindow<FlightViewModel>
{
    public FlightWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs eventArgs)
    {
        Close();
    }
}
