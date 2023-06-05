using Avalonia.ReactiveUI;
using EnterpriseWarehouse.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace EnterpriseWarehouse.Client.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowProductDialog.RegisterHandler(ShowProductDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowStorageCellDialog.RegisterHandler(ShowStorageCellDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowInvoiceDialog.RegisterHandler(ShowInvoiceDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowInvoiceContentDialog.RegisterHandler(ShowInvoicContentDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowMessageDialog.RegisterHandler(ShowMessageDialogAsync)));
    }

    private async Task ShowProductDialogAsync(InteractionContext<ProductViewModel, ProductViewModel?> interaction)
    {
        var dialog = new ProductWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ProductViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowStorageCellDialogAsync(InteractionContext<StorageCellViewModel, StorageCellViewModel?> interaction)
    {
        var dialog = new StorageCellWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<StorageCellViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowInvoiceDialogAsync(InteractionContext<InvoiceViewModel, InvoiceViewModel?> interaction)
    {
        var dialog = new InvoiceWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<InvoiceViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowInvoicContentDialogAsync(InteractionContext<InvoiceContentViewModel, InvoiceContentViewModel?> interaction)
    {
        var dialog = new InvoiceContentWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<InvoiceContentViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowMessageDialogAsync(InteractionContext<MessageViewModel, MessageViewModel?> interaction)
    {
        var dialog = new MessageWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<MessageViewModel?>(this);
        interaction.SetOutput(null);
    }
}