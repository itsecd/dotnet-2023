using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using TransportMgmt.Client.ViewModels;

namespace TransportMgmt.Client.Views;
public partial class TransportWindow : ReactiveWindow<TransportViewModel>
{
    public TransportWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.TransportOnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
