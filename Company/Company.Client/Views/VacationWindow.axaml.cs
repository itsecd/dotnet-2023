using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Company.Client.ViewModels;
using ReactiveUI;
using System;

namespace Company.Client.Views;

public partial class VacationWindow : ReactiveWindow<VacationViewModel>
{
    public VacationWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}