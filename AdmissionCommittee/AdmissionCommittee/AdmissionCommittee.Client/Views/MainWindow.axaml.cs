using AdmissionCommittee.Client.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;

namespace AdmissionCommittee.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowEntrantDialog.RegisterHandler(ShowEntrantDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowEntResultDialog.RegisterHandler(ShowEntResultDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowResultDialog.RegisterHandler(ShowResultDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowStatementDialog.RegisterHandler(ShowStatementDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowStSpecialtyDialog.RegisterHandler(ShowStSpecialtyDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowSpecialtyDialog.RegisterHandler(ShowSpecialtyDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowRequestsDialog.RegisterHandler(ShowRequestsDialogAsync)));
    }

    private async Task ShowEntrantDialogAsync(InteractionContext<EntrantViewModel, EntrantViewModel?> interaction)
    {
        var entrantDialog = new EntrantWindow
        {
            DataContext = interaction.Input
        };

        var result = await entrantDialog.ShowDialog<EntrantViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowEntResultDialogAsync(InteractionContext<EntrantResultViewModel, EntrantResultViewModel?> interaction)
    {
        var entResultDialog = new EntrantResultWindow
        {
            DataContext = interaction.Input
        };

        var result = await entResultDialog.ShowDialog<EntrantResultViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowResultDialogAsync(InteractionContext<ResultViewModel, ResultViewModel?> interaction)
    {
        var resultDialog = new ResultWindow
        {
            DataContext = interaction.Input
        };

        var result = await resultDialog.ShowDialog<ResultViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowStatementDialogAsync(InteractionContext<StatementViewModel, StatementViewModel?> interaction)
    {
        var statementDialog = new StatementWindow
        {
            DataContext = interaction.Input
        };

        var result = await statementDialog.ShowDialog<StatementViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowStSpecialtyDialogAsync(InteractionContext<StatementSpecialtyViewModel, StatementSpecialtyViewModel?> interaction)
    {
        var stSpecialtyDialog = new StatementSpecialtyWindow
        {
            DataContext = interaction.Input
        };

        var result = await stSpecialtyDialog.ShowDialog<StatementSpecialtyViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowSpecialtyDialogAsync(InteractionContext<SpecialtyViewModel, SpecialtyViewModel?> interaction)
    {
        var specialtyDialog = new SpecialtyWindow
        {
            DataContext = interaction.Input
        };

        var result = await specialtyDialog.ShowDialog<SpecialtyViewModel?>(this);
        interaction.SetOutput(result);
    }

    public async Task ShowRequestsDialogAsync(InteractionContext<RequestsViewModel, RequestsViewModel?> interaction)
    {
        var windowRequestsView = new RequestsWindow
        {
            DataContext = interaction.Input
        };
        var result = await windowRequestsView.ShowDialog<RequestsViewModel?>(this);
        interaction.SetOutput(result);
    }
}