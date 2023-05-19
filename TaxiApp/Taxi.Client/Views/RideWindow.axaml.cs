using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Taxi.Client.ViewModels;

namespace Taxi.Client.Views;

public partial class RideWindow : ReactiveWindow<RideViewModel>
{
    public RideWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }
    
    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
    
}