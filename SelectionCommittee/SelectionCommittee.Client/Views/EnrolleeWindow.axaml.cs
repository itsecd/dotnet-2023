using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SelectionCommittee.Client.ViewModels;
using System;

namespace SelectionCommittee.Client.Views;
public partial class EnrolleeWindow : ReactiveWindow<EnrolleeViewModel>
{
    public EnrolleeWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableElement
            => disposableElement(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    public void ChangedEnrolleeCreationDateEvent(object sender, DatePickerSelectedValueChangedEventArgs e)
    {
        ViewModel!.BirthDate = new DateTime(enrolleeBirthDate.SelectedDate!.Value.Year,
            enrolleeBirthDate.SelectedDate.Value.Month, enrolleeBirthDate.SelectedDate.Value.Day);
    }
}
