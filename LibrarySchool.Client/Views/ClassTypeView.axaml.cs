using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using LibrarySchool.Desktop.ViewModels;
using ReactiveUI;
using System;

namespace LibrarySchool.Desktop.Views;
#pragma warning disable CS1591
public partial class ClassTypeView : ReactiveWindow<ClassTypeViewModel>
{
    public ClassTypeView()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void BtnCloseWindow(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
#pragma warning restore CS1591
