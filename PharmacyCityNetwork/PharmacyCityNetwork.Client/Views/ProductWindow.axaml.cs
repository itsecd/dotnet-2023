using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using PharmacyCityNetwork.Client.ViewModels;
using ReactiveUI;
using System;

namespace PharmacyCityNetwork.Client.Views;
public partial class ProductWindow : ReactiveWindow<ProductViewModel>
{
    public ProductWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }
    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}