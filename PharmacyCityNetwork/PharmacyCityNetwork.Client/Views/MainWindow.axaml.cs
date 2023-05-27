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
}