using System;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Polyclinic.Client.ViewModels;
using ReactiveUI;

namespace Polyclinic.Client.Views;
public partial class DoctorWindow : ReactiveWindow<DoctorViewModel>
{
    public DoctorWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSumbitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
