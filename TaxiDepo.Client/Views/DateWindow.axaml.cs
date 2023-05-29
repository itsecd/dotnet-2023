using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using TaxiDepo.Client.ViewModels;

namespace TaxiDepo.Client.Views;
public partial class DateWindow : ReactiveWindow<DateViewModel>
{
    public DateWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableElement
            => disposableElement(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
