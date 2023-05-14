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
        this.WhenActivated(d => d(ViewModel!.ShowDepartmentDialog.RegisterHandler(ShowDepartmentDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowReaderDialog.RegisterHandler(ShowReaderDialogAsync)));
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

    private async Task ShowDepartmentDialogAsync(InteractionContext<DepartmentViewModel, DepartmentViewModel?> interaction)
    {
        var dialog = new DepartmentWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<DepartmentViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowReaderDialogAsync(InteractionContext<ReaderViewModel, ReaderViewModel?> interaction)
    {
        var dialog = new ReaderWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ReaderViewModel?>(this);
        interaction.SetOutput(result);
    }
}