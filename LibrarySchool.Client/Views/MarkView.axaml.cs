using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using LibrarySchool.Client.ViewModels;
using ReactiveUI;
using System;

namespace LibrarySchool.Client.Views;

/// <summary>
/// View of class Mark
/// </summary>
public partial class MarkView : ReactiveWindow<MarkViewModel>
{
    /// <summary>
    /// Constructor for class MarkView
    /// </summary>
    public MarkView()
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
