using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Media.Client.ViewModels;
using ReactiveUI;
using System;

namespace Media.Client.Views;
public partial class AlbumWindow : ReactiveWindow<AlbumViewModel>
{
    public AlbumWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs eventArgs)
    {
        Close();
    }
}