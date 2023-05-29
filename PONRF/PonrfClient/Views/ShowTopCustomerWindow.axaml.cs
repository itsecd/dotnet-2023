using Avalonia.ReactiveUI;
using PonrfClient.ViewModels;

namespace PonrfClient.Views;
public partial class ShowTopCustomerWindow : ReactiveWindow<TopCustomerViewModel>
{
    public ShowTopCustomerWindow()
    {
        InitializeComponent();
    }
}
