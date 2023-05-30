using Avalonia.ReactiveUI;
using PharmacyCityNetwork.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace PharmacyCityNetwork.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowProductDialog.RegisterHandler(ShowDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowGroupDialog.RegisterHandler(ShowDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowPharmacyDialog.RegisterHandler(ShowDialogAsync)));
    }
    private async Task ShowDialogAsync(InteractionContext<ProductViewModel, ProductViewModel?> interaction)
    {
        var dialog = new ProductWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ProductViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowDialogAsync(InteractionContext<GroupViewModel, GroupViewModel?> interaction)
    {
        var dialog = new GroupWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<GroupViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowDialogAsync(InteractionContext<PharmacyViewModel, PharmacyViewModel?> interaction)
    {
        var dialog = new PharmacyWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<PharmacyViewModel?>(this);
        interaction.SetOutput(result);
    }
}