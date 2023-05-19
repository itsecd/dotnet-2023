using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Factory.Client.ViewModels;
using ReactiveUI;
using System;

namespace Factory.Client.Views;
public partial class EnterpriseWindow : ReactiveWindow<EnterpriseViewModel>
{
    public EnterpriseWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel !.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
