using Avalonia.ReactiveUI;
using ReactiveUI;
using School.Client.ViewModels;
using System.Threading.Tasks;

namespace School.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowClassDialog.RegisterHandler(ShowClassDialogAsync)));
        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowGradeDialog.RegisterHandler(ShowGradeDialogAsync)));
        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowStudentDialog.RegisterHandler(ShowStudentDialogAsync)));
        this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowSubjectDialog.RegisterHandler(ShowSubjectDialogAsync)));
    }

    private async Task ShowClassDialogAsync(InteractionContext<ClassViewModel, ClassViewModel?> interaction)
    {
        var dialog = new ClassWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<ClassViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowGradeDialogAsync(InteractionContext<GradeViewModel, GradeViewModel?> interaction)
    {
        var dialog = new GradeWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<GradeViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowStudentDialogAsync(InteractionContext<StudentViewModel, StudentViewModel?> interaction)
    {
        var dialog = new StudentWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<StudentViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowSubjectDialogAsync(InteractionContext<SubjectViewModel, SubjectViewModel?> interaction)
    {
        var dialog = new SubjectWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<SubjectViewModel?>(this);
        interaction.SetOutput(result);
    }
}