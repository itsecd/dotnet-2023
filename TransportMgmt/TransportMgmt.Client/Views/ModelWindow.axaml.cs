using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using TransportMgmt.Client.ViewModels;

namespace TransportMgmt.Client.Views;
public partial class ModelWindow : ReactiveWindow<ModelViewModel>
{
    public ModelWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ModelOnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

}
