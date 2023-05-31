using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using TransportMgmt.Client.ViewModels;

namespace TransportMgmt.Client.Views;
public partial class TripWindow : ReactiveWindow<TripViewModel>
{
    public TripWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.TripOnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
