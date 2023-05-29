using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using BikeRental.Client.ViewModels;
using ReactiveUI;
using System;

namespace BikeRental.Client.Views;
public partial class ClientWindow : ReactiveWindow<ClientViewModel>
{
    public ClientWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
