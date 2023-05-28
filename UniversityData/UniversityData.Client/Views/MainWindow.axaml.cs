using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using UniversityData.Client.ViewModels;

namespace UniversityData.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowConstructionPropertyDialog.RegisterHandler(ShowConstructionPropertyDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowDepartmentDialog.RegisterHandler(ShowDepartmentDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowFacultyDialog.RegisterHandler(ShowFacultyDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowRectorDialog.RegisterHandler(ShowRectorDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowSpecialtyTableNodeDialog.RegisterHandler(ShowSpecialtyTableNodeDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowSpecialtyDialog.RegisterHandler(ShowSpecialtyDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowUniversityDialog.RegisterHandler(ShowUniversityDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowUniversityPropertyDialog.RegisterHandler(ShowUniversityPropertyDialogAsync)));
    }
    private async Task ShowConstructionPropertyDialogAsync(InteractionContext<ConstructionPropertyViewModel, ConstructionPropertyViewModel?> interaction)
    {
        var dialog = new ConstructionPropertyWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ConstructionPropertyViewModel?>(this);
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

    private async Task ShowFacultyDialogAsync(InteractionContext<FacultyViewModel, FacultyViewModel?> interaction)
    {
        var dialog = new FacultyWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<FacultyViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowRectorDialogAsync(InteractionContext<RectorViewModel, RectorViewModel?> interaction)
    {
        var dialog = new RectorWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<RectorViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowSpecialtyTableNodeDialogAsync(InteractionContext<SpecialtyTableNodeViewModel, SpecialtyTableNodeViewModel?> interaction)
    {
        var dialog = new SpecialtyTableNodeWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<SpecialtyTableNodeViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowSpecialtyDialogAsync(InteractionContext<SpecialtyViewModel, SpecialtyViewModel?> interaction)
    {
        var dialog = new SpecialtyWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<SpecialtyViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowUniversityDialogAsync(InteractionContext<UniversityViewModel, UniversityViewModel?> interaction)
    {
        var dialog = new UniversityWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<UniversityViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowUniversityPropertyDialogAsync(InteractionContext<UniversityPropertyViewModel, UniversityPropertyViewModel?> interaction)
    {
        var dialog = new UniversityPropertyWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<UniversityPropertyViewModel?>(this);
        interaction.SetOutput(result);
    }
}
