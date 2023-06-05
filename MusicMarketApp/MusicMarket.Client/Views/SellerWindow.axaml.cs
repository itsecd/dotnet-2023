using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using MusicMarket.Client.ViewModels;
using ReactiveUI;
using System;

namespace MusicMarket.Client.Views;
public partial class SellerWindow : ReactiveWindow<SellerViewModel>
{
    public SellerWindow()
    {
        
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
        }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
    Close();
    }
    
}
