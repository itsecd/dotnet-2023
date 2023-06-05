using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using MusicMarket.Client.ViewModels;
using System;

namespace MusicMarket.Client.Views;
public partial class CustomerWindow : ReactiveWindow<CustomerViewModel>
{
    public CustomerWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
