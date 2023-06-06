using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using StoreApp.Client.ViewModels;
using System.Reactive;
using System;

namespace StoreApp.Client.Views;
public partial class CustomerWindow : ReactiveWindow<CustomerViewModel>
{
    public CustomerWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommandCustomer.Subscribe(Close)));
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
