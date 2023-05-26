using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using PonrfClient.ViewModels;
using ReactiveUI;
using System;

namespace PonrfClient.Views;
public partial class CustomerWindow : ReactiveWindow<CustomerViewModel>
{
    public CustomerWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
