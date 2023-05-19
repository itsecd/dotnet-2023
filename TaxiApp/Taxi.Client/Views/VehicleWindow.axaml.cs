using System;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Taxi.Client.ViewModels;

namespace Taxi.Client.Views;

public partial class VehicleWindow : ReactiveWindow<VehicleViewModel>
{
    public VehicleWindow()
    {
        InitializeComponent();
        
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }
    
    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}