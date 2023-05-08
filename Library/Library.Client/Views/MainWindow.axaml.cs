using Avalonia.Controls;
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

        this.WhenActivated(d => d(ViewModel!.ShowBookDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<BookViewModel, BookViewModel?> interaction)
    {
        var dialog = new BookWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<BookViewModel?>(this);
        interaction.SetOutput(result);
    }
}