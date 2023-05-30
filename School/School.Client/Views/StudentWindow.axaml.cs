using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using School.Client.ViewModels;
using System;

namespace School.Client.Views;
public partial class StudentWindow : ReactiveWindow<StudentViewModel>
{
    public StudentWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableElement
            => disposableElement(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    public void ChangedStudentBirthDateEvent(object sender, DatePickerSelectedValueChangedEventArgs e)
    {
        ViewModel!.BirthDate = new DateTime(studentBirthDate.SelectedDate!.Value.Year,
            studentBirthDate.SelectedDate.Value.Month, studentBirthDate.SelectedDate.Value.Day);
    }
}