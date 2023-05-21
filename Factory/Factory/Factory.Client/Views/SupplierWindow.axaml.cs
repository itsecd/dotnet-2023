using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Factory.Client.ViewModels;
using ReactiveUI;
using System;

namespace Factory.Client.Views;
public partial class SupplierWindow : ReactiveWindow<SupplierViewModel>
{
    public SupplierWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }
    public void CancelButton_OnClick(object? sender, RoutedEventArgs eventArgs)
    {
        Close();
    }
}
