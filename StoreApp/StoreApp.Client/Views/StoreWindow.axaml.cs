using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using StoreApp.Client.ViewModels;
using System.Reactive;
using System;

namespace StoreApp.Client.Views;
public partial class StoreWindow : ReactiveWindow<StoreViewModel>
{
    public StoreWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommandStore.Subscribe(Close)));
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
