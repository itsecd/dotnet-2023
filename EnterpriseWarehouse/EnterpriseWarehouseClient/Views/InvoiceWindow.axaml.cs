using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using EnterpriseWarehouseClient.ViewModels;
using ReactiveUI;
using System;

namespace EnterpriseWarehouseClient.Views;
public partial class InvoiceWindow : ReactiveWindow<InvoiceViewModel>
{
    public InvoiceWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_onClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
