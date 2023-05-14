using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Library.Client.ViewModels;
using ReactiveUI;
using System;

namespace Library.Client.Views;
public partial class CardWindow : ReactiveWindow<CardViewModel>
{
    public CardWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}