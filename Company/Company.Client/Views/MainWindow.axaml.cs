using Avalonia.ReactiveUI;
using Company.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace Company.Client.Views;

public partial class MainWindow : ReactiveWindow<MainViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowDepartmentDialog.RegisterHandler(ShowDepartmentDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowJobDialog.RegisterHandler(ShowJobDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowVacationDialog.RegisterHandler(ShowVacationDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowVacationSpotDialog.RegisterHandler(ShowVacationSpotDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowWorkerDialog.RegisterHandler(ShowWorkerDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowWorkersAndDepartmentsDialog.RegisterHandler(ShowWorkersAndDepartmentsDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowWorkersAndJobsDialog.RegisterHandler(ShowWorkersAndJobsDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowWorkersAndVacationsDialog.RegisterHandler(ShowWorkersAndVacationsDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowWorkshopDialog.RegisterHandler(ShowWorkshopDialogAsync)));
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

    private async Task ShowJobDialogAsync(InteractionContext<JobViewModel, JobViewModel?> interaction)
    {
        var dialog = new JobWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<JobViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowVacationDialogAsync(InteractionContext<VacationViewModel, VacationViewModel?> interaction)
    {
        var dialog = new VacationWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<VacationViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowVacationSpotDialogAsync(InteractionContext<VacationSpotViewModel, VacationSpotViewModel?> interaction)
    {
        var dialog = new VacationSpotWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<VacationSpotViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowWorkerDialogAsync(InteractionContext<WorkerViewModel, WorkerViewModel?> interaction)
    {
        var dialog = new WorkerWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<WorkerViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowWorkersAndDepartmentsDialogAsync(InteractionContext<WorkersAndDepartmentsViewModel, WorkersAndDepartmentsViewModel?> interaction)
    {
        var dialog = new WorkersAndDepartmentsWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<WorkersAndDepartmentsViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowWorkersAndJobsDialogAsync(InteractionContext<WorkersAndJobsViewModel, WorkersAndJobsViewModel?> interaction)
    {
        var dialog = new WorkersAndJobsWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<WorkersAndJobsViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowWorkersAndVacationsDialogAsync(InteractionContext<WorkersAndVacationsViewModel, WorkersAndVacationsViewModel?> interaction)
    {
        var dialog = new WorkersAndVacationsWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<WorkersAndVacationsViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowWorkshopDialogAsync(InteractionContext<WorkshopViewModel, WorkshopViewModel?> interaction)
    {
        var dialog = new WorkshopWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<WorkshopViewModel?>(this);
        interaction.SetOutput(result);
    }
}
