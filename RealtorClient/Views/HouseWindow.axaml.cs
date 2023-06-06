using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using RealtorClient.ViewModels;
using ReactiveUI;
using System;

namespace RealtorClient.Views;
public partial class HouseWindow : ReactiveWindow<HouseViewModel>
{
    public HouseWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
