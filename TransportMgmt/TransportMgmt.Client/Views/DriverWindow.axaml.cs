using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TransportMgmt.Client.Views;
public partial class DriverWindow : Window
{
    public DriverWindow()
    {
        InitializeComponent();
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
