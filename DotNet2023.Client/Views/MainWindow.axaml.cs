using Avalonia.ReactiveUI;
using DotNet2023.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace DotNet2023.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowDepartmentDialog.RegisterHandler(ShowDepartmentDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowEducationWorkerDialog.RegisterHandler(ShowEducationWorkerDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowFacultytDialog.RegisterHandler(ShowFacultytDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowGroupOfStudentstDialog.RegisterHandler(ShowGroupOfStudentstDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowInstituteSpecialityDialog.RegisterHandler(ShowInstituteSpecialitytDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowInstitutionDialog.RegisterHandler(ShowInstitutiontDialog)));
        this.WhenActivated(d => d(ViewModel!.ShowSpecialityDialog.RegisterHandler(ShowSpecialityDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowStudentDialog.RegisterHandler(ShowStudentDialogAsync)));
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
    private async Task ShowEducationWorkerDialogAsync(InteractionContext<EducationWorkerViewModel, EducationWorkerViewModel?> interaction)
    {
        var dialog = new EducationWorkerWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<EducationWorkerViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowFacultytDialogAsync(InteractionContext<FacultyViewModel, FacultyViewModel?> interaction)
    {
        var dialog = new FacultyWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<FacultyViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowGroupOfStudentstDialogAsync(InteractionContext<GroupOfStudentsViewModel, GroupOfStudentsViewModel?> interaction)
    {
        var dialog = new GroupOfStudentsWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<GroupOfStudentsViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowInstituteSpecialitytDialogAsync(InteractionContext<InstituteSpecialityViewModel, InstituteSpecialityViewModel?> interaction)
    {
        var dialog = new InstituteSpecialityWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<InstituteSpecialityViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowInstitutiontDialog(InteractionContext<HigherEducationInstitutionViewModel, HigherEducationInstitutionViewModel?> interaction)
    {
        var dialog = new HigherEducationInstitutionWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<HigherEducationInstitutionViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowSpecialityDialogAsync(InteractionContext<SpecialityViewModel, SpecialityViewModel?> interaction)
    {
        var dialog = new SpecialityWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<SpecialityViewModel?>(this);
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

}