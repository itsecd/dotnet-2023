using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Media.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace Media.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowArtistDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<ArtistViewModel, ArtistViewModel?> interaction)
    {
        var dialog = new ArtistWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ArtistViewModel?>(this);
        interaction.SetOutput(result);
    }
}