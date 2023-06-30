using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using LibrarySchool.Client.ViewModels;
using ReactiveUI;
using System;

namespace LibrarySchool.Client.Views;

/// <summary>
/// View of class subject
/// </summary>
public partial class SubjectView : ReactiveWindow<SubjectViewModel>
{
    /// <summary>
    /// Constructor for class SubjectView
    /// </summary>
    public SubjectView()
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
