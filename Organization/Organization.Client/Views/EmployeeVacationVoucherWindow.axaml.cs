using Avalonia.Controls;
using Avalonia.Interactivity;
using Organization.Client.ViewModels;
using ReactiveUI;
using System;

namespace Organization.Client.Views;
public partial class EmployeeVacationVoucherWindow : BaseWindow<EmployeeVacationVoucherViewModel>
{
    public EmployeeVacationVoucherWindow()
    {
        InitializeComponent();
        this.WhenActivated(disposableObj =>
            disposableObj(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
