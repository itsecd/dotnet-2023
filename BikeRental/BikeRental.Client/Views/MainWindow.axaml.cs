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

        this.WhenActivated(d => d(ViewModel!.ShowBikeDialog.RegisterHandler(ShowBikeDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowClientDialog.RegisterHandler(ShowClientDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowRentRecordDialog.RegisterHandler(ShowRentRecordDialogAsync)));
    }

    private async Task ShowBikeDialogAsync(InteractionContext<BikeViewModel, BikeViewModel?> interaction)
    {
        var dialog = new BikeWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<BikeViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowClientDialogAsync(InteractionContext<ClientViewModel, ClientViewModel?> interaction)
    {
        var dialog = new ClientWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ClientViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowRentRecordDialogAsync(InteractionContext<RentRecordViewModel, RentRecordViewModel?> interaction)
    {
        var dialog = new RentRecordWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<RentRecordViewModel?>(this);
        interaction.SetOutput(result);
    }
}