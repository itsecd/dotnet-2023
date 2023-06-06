using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RealtorClient.ViewModels;
using System;

namespace RealtorClient.Views;
public partial class ApplicationHasHouseWindow : ReactiveWindow<ApplicationHasHouseViewModel>
{
    public ApplicationHasHouseWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
