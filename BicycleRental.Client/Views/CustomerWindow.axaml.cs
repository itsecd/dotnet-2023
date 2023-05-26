using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using BicycleRental.Client.ViewModels;
using ReactiveUI;
using System;

namespace BicycleRental.Client.Views;
public partial class CustomerWindow : ReactiveWindow<CustomerViewModel>
{
    public CustomerWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs eventArgs)
    {
        Close();
    }
}
