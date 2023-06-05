using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using EnterpriseWarehouse.Client.ViewModels;

namespace EnterpriseWarehouse.Client.Views;
public partial class MessageWindow : ReactiveWindow<MessageViewModel>
{
    public MessageWindow()
    {
        InitializeComponent();
    }

    public void OkButton_onClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
