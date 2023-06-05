using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using TransportManagment.Client.ViewModels;

namespace TransportManagment.Client.Views;
public partial class TransportWindow : ReactiveWindow<TransportViewModel>
{
    public TransportWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }
    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
