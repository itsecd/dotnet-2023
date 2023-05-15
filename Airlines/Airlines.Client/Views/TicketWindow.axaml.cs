using Airlines.Client.ViewModels;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;

namespace Airlines.Client.Views;
public partial class TicketWindow : ReactiveWindow<TicketViewModel>
{
    public TicketWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }
    public void CancelButtonOnClick(object? sender, RoutedEventArgs eventArgs)
    {
        Close();
    }
}