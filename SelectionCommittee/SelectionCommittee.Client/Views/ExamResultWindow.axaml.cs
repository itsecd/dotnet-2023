using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SelectionCommittee.Client.ViewModels;
using System;

namespace SelectionCommittee.Client.Views;
public partial class ExamResultWindow : ReactiveWindow<ExamResultViewModel>
{
    public ExamResultWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableElement
            => disposableElement(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
