using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;


namespace Factory.Client.ViewModels;
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
