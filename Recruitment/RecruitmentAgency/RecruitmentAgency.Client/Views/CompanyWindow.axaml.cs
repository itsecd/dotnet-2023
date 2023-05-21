using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RecruitmentAgency.Client.ViewModels;
using System;

namespace RecruitmentAgency.Client.Views;
public partial class CompanyWindow : ReactiveWindow<CompanyViewModel>
{
    public CompanyWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }
    
    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
