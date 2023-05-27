using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Fabrics.Client.ViewModels;
using ReactiveUI;
using System;

namespace Fabrics.Client.Views;
public partial class ProviderWindow : ReactiveWindow<ProviderViewModel>
{
    public ProviderWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
