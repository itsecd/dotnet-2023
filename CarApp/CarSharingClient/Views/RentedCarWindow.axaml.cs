using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using CarSharingClient.ViewModels;
using ReactiveUI;
using System;

namespace CarSharingClient.Views;
public partial class RentedCarWindow : ReactiveWindow<RentedCarViewModel>
{
    public RentedCarWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}