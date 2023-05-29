using AdmissionCommittee.Client.ViewModels;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;

namespace AdmissionCommittee.Client.Views;
public partial class RequestCityWindow : ReactiveWindow<RequestCityViewModel>
{
    public RequestCityWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void BtnCloseWindow(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}