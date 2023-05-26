using Avalonia.Controls;
using Avalonia.ReactiveUI;
using BikeRental.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace BikeRental.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowBikeDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<BikeViewModel, BikeViewModel?> interaction)
    {
        var dialog = new BikeWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<BikeViewModel?>(this);
        interaction.SetOutput(result);
    }
}