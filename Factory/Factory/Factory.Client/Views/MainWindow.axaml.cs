using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Factory.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace Factory.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowEnterpriseDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<EnterpriseViewModel, EnterpriseViewModel?> interaction)
    {
        var dialog = new EnterpriseWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<EnterpriseViewModel?>(this);
        interaction.SetOutput(result);
    }
}