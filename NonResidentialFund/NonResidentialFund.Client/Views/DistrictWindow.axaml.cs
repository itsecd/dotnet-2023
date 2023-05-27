using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using NonResidentialFund.Client.ViewModels;
using ReactiveUI;
using System;

namespace NonResidentialFund.Client.Views;
public partial class DistrictWindow : ReactiveWindow<DistrictViewModel>
{
    public DistrictWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
