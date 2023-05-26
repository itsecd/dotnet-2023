using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Fabrics.Client.ViewModels;
using ReactiveUI;
using System;

namespace Fabrics.Client.Views;
public partial class FabricWindow : ReactiveWindow<FabricViewModel>
{
    public FabricWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
