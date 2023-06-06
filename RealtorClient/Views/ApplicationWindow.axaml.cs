using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RealtorClient.ViewModels;
using System;

namespace RealtorClient.Views;
public partial class ApplicationWindow : ReactiveWindow<ApplicationViewModel>
{
    public ApplicationWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
