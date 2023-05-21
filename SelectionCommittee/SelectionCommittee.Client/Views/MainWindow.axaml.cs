using Avalonia.ReactiveUI;
using ReactiveUI;
using SelectionCommittee.Client.ViewModels;
using System.Threading.Tasks;

namespace SelectionCommittee.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowEnrolleeDialog.RegisterHandler(ShowEnrolleeDialogAsync)));
        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowExamResultDialog.RegisterHandler(ShowExamResultDialogAsync)));
        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowFacultyDialog.RegisterHandler(ShowFacultyDialogAsync)));
        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowSpecializationDialog.RegisterHandler(ShowSpecializationDialogAsync)));
    }

    private async Task ShowEnrolleeDialogAsync(InteractionContext<EnrolleeViewModel, EnrolleeViewModel?> interaction)
    {
        var dialog = new EnrolleeWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<EnrolleeViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowExamResultDialogAsync(InteractionContext<ExamResultViewModel, ExamResultViewModel?> interaction)
    {
        var dialog = new ExamResultWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<ExamResultViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowFacultyDialogAsync(InteractionContext<FacultyViewModel, FacultyViewModel?> interaction)
    {
        var dialog = new FacultyWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<FacultyViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowSpecializationDialogAsync(InteractionContext<SpecializationViewModel, SpecializationViewModel?> interaction)
    {
        var dialog = new SpecializationWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<SpecializationViewModel?>(this);
        interaction.SetOutput(result);
    }
}