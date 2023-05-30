using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using School.Client.ViewModels;
using System;

namespace School.Client.Views;
public partial class ClassWindow : ReactiveWindow<ClassViewModel>
{
    public ClassWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableElement
            => disposableElement(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}