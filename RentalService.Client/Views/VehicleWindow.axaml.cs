using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RentalService.Client.ViewModels;

namespace RentalService.Client.Views;

public partial class VehicleWindow : ReactiveWindow<VehicleViewModel>
{
    public VehicleWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OkButtonOnClick.Subscribe(Close)));
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

}