using System;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Warehouse.Client.ViewModels;

namespace Warehouse.Client.Views;
public partial class WarehouseCellWindow : ReactiveWindow<WarehouseCellViewModel>
{
    public WarehouseCellWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}