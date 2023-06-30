using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using LibrarySchool.Client.ViewModels;
using ReactiveUI;
using System;

namespace LibrarySchool.Client.Views;

/// <summary>
/// View of class QueryClassType
/// </summary>
public partial class QueryClassTypeView : ReactiveWindow<QueryClassTypeViewModel>
{
    /// <summary>
    /// Constructor of class QueryClassTypeView
    /// </summary>
    public QueryClassTypeView()
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
