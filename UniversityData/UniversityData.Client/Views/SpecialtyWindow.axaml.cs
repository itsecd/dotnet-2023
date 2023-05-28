using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using UniversityData.Client.ViewModels;

namespace UniversityData.Client.Views;
public partial class SpecialtyWindow : ReactiveWindow<SpecialtyViewModel>
{
    public SpecialtyWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}