using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using CarSharingClient.ViewModels;
using ReactiveUI;
using System;

namespace CarSharingClient.Views;
public partial class CarWindow : ReactiveWindow<CarViewModel>
{
    public CarWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}