using AdmissionCommittee.Client.ViewModels;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;

namespace AdmissionCommittee.Client.Views;
public partial class StatementWindow : ReactiveWindow<StatementViewModel>
{
    public StatementWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}