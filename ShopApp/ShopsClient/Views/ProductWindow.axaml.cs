using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using ShopsClient.ViewModels;
using System;

namespace ShopsClient.Views;
public partial class ProductWindow : ReactiveWindow<ProductGroupViewModel>
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
