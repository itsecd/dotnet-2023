using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RealtorClient.ViewModels;
using System;

namespace RealtorClient.Views;

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

