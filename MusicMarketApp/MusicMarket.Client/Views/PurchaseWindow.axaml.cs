using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using MusicMarket.Client.ViewModels;

namespace MusicMarket.Client.Views;
public partial class PurchaseWindow : ReactiveWindow<PurchaseViewModel>
{
    public PurchaseWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
