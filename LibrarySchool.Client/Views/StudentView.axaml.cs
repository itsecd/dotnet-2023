using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using LibrarySchool.Desktop.ViewModels;
using ReactiveUI;
using System;

namespace LibrarySchool.Desktop.Views;

/// <summary>
/// View of class Student 
/// </summary>
public partial class StudentView : ReactiveWindow<StudentViewModel>
{
    /// <summary>
    /// Constructor for class StudentView
    /// </summary>
    public StudentView()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    /// <summary>
    /// Event close window
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void BtnCloseWindow(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
