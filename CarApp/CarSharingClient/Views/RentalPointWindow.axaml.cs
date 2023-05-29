using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using CarSharingClient.ViewModels;
using ReactiveUI;
using System;

namespace CarSharingClient.Views;
public partial class RentalPointWindow : ReactiveWindow<RentalPointViewModel>
{
    public RentalPointWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
