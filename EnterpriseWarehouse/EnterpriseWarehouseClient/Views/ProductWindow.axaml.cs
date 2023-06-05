using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using EnterpriseWarehouse.Client.ViewModels;
using ReactiveUI;
using System;

namespace EnterpriseWarehouse.Client.Views;
public partial class ProductWindow : ReactiveWindow<ProductViewModel>
{
    public ProductWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_onClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
