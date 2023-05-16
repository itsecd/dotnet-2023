using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RentalService.Client.ViewModels;

namespace RentalService.Client.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowClientDialog.RegisterHandler(ShowClientDialogAsync)));
        
    }
    
    private async Task ShowClientDialogAsync(InteractionContext<ClientViewModel, ClientViewModel?> interaction)
    {
        var dialog = new ClientWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ClientViewModel?>(this);
        interaction.SetOutput(result);
    }
}