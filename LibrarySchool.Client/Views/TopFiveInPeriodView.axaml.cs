using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using LibrarySchool.Client.ViewModels;
using ReactiveUI;
using System;

namespace LibrarySchool.Client.Views;

/// <summary>
/// View of window get period
/// </summary>
public partial class TopFiveInPeriodView : ReactiveWindow<TopFiveInPeriodViewModel>
{
    /// <summary>
    /// Constructor for class TopFiveInPeriodView
    /// </summary>
    public TopFiveInPeriodView()
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
