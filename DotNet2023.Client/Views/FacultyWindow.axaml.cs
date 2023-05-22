using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DotNet2023.Client.ViewModels;
using ReactiveUI;
using System;

namespace DotNet2023.Client.Views;
public partial class FacultyWindow : ReactiveWindow<FacultyViewModel>
{
    public FacultyWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OkButtonOnClick.Subscribe(Close)));
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
