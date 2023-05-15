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

        this.WhenActivated(d => d(ViewModel!.ShowArtistDialog.RegisterHandler(ShowArtistDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowAlbumDialog.RegisterHandler(ShowAlbumDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowGenreDialog.RegisterHandler(ShowGenreDialogAsync)));
    }

    private async Task ShowArtistDialogAsync(InteractionContext<ArtistViewModel, ArtistViewModel?> interaction)
    {
        var dialog = new ArtistWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ArtistViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowAlbumDialogAsync(InteractionContext<AlbumViewModel, AlbumViewModel?> interaction)
    {
        var dialog = new AlbumWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<AlbumViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowGenreDialogAsync(InteractionContext<GenreViewModel, GenreViewModel?> interaction)
    {
        var dialog = new GenreWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<GenreViewModel?>(this);
        interaction.SetOutput(result);
    }
}