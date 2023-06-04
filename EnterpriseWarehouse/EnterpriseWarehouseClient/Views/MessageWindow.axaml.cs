using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using EnterpriseWarehouseClient.ViewModels;

namespace EnterpriseWarehouseClient.Views;
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
