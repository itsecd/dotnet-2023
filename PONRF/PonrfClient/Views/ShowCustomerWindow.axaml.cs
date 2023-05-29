using Avalonia.ReactiveUI;
using PonrfClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace PonrfClient.Views;
public partial class ShowCustomerWindow : ReactiveWindow<ShowCustomerViewModel>
{
    public ShowCustomerWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowCustomerDialog.RegisterHandler(CustomerDialogAsync)));
    }

    private async Task CustomerDialogAsync(InteractionContext<CustomerViewModel, CustomerViewModel?> interaction)
    {
        var dialogCustomer = new CustomerWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialogCustomer.ShowDialog<CustomerViewModel?>(this);
        interaction.SetOutput(result);
    }
}
