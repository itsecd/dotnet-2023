using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using PoliclinicClient.ViewModels;
using ReactiveUI;
using System;

namespace PoliclinicClient.Views;
public partial class ReceptionWindow : ReactiveWindow<ReceptionViewModel>
{
    public ReceptionWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
