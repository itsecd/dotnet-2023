using Avalonia.ReactiveUI;
using Library.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace Library.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowBookDialog.RegisterHandler(ShowBookDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowCardDialog.RegisterHandler(ShowCardDialogAsync)));
    }

    private async Task ShowBookDialogAsync(InteractionContext<BookViewModel, BookViewModel?> interaction)
    {
        var dialog = new BookWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<BookViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowCardDialogAsync(InteractionContext<CardViewModel, CardViewModel?> interaction)
    {
        var dialog = new CardWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<CardViewModel?>(this);
        interaction.SetOutput(result);
    }
}