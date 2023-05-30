using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Department.Client.ViewModels;
using ReactiveUI;
using System;

namespace Department.Client.Views;
public partial class TeacherWindow : ReactiveWindow<CourseViewModel>
{
    public TeacherWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
