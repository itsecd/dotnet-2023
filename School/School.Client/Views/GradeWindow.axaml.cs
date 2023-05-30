using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using School.Client.ViewModels;
using System;

namespace School.Client.Views;
public partial class GradeWindow : ReactiveWindow<GradeViewModel>
{
    public GradeWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableElement
            => disposableElement(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    public void ChangedMarkDateEvent(object sender, DatePickerSelectedValueChangedEventArgs e)
    {
        ViewModel!.Date = new DateTime(date.SelectedDate!.Value.Year,
            date.SelectedDate.Value.Month, date.SelectedDate.Value.Day);
    }
}