using Organization.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace Organization.Client.Views;
public partial class MainWindow : BaseWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableObj =>
            disposableObj(ViewModel!.ShowDepartmentEmployeeDialog.RegisterHandler(ShowDepartmentEmployeeDialogAsync)));

        this.WhenActivated(disposableObj =>
            disposableObj(ViewModel!.ShowDepartmentDialog.RegisterHandler(ShowDepartmentDialogAsync)));

        this.WhenActivated(disposableObj =>
            disposableObj(ViewModel!.ShowEmployeeOccupationDialog.RegisterHandler(ShowEmployeeOccupationDialogAsync)));

        this.WhenActivated(disposableObj =>
            disposableObj(ViewModel!.ShowEmployeeDialog.RegisterHandler(ShowEmployeeDialogAsync)));

        this.WhenActivated(disposableObj =>
            disposableObj(ViewModel!.ShowEmployeeVacationVoucherDialog
            .RegisterHandler(ShowEmployeeVacationVoucherDialogAsync)));

        this.WhenActivated(disposableObj =>
            disposableObj(ViewModel!.ShowOccupationDialog.RegisterHandler(ShowOccupationDialogAsync)));

        this.WhenActivated(disposableObj =>
            disposableObj(ViewModel!.ShowVacationVoucherDialog.RegisterHandler(ShowVacationVoucherDialogAsync)));

        this.WhenActivated(disposableObj =>
            disposableObj(ViewModel!.ShowVoucherTypeDialog.RegisterHandler(ShowVoucherTypeDialogAsync)));

        this.WhenActivated(disposableObj =>
            disposableObj(ViewModel!.ShowWorkshopDialog.RegisterHandler(ShowWorkshopDialogAsync)));
    }
    private async Task ShowDepartmentEmployeeDialogAsync(InteractionContext<DepartmentEmployeeViewModel,
        DepartmentEmployeeViewModel?> interaction)
    {
        var dialog = new DepartmentEmployeeWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<DepartmentEmployeeViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowDepartmentDialogAsync(InteractionContext<DepartmentViewModel,
        DepartmentViewModel?> interaction)
    {
        var dialog = new DepartmentWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<DepartmentViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowEmployeeOccupationDialogAsync(InteractionContext<EmployeeOccupationViewModel,
    EmployeeOccupationViewModel?> interaction)
    {
        var dialog = new EmployeeOccupationWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<EmployeeOccupationViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowEmployeeDialogAsync(InteractionContext<EmployeeViewModel,
        EmployeeViewModel?> interaction)
    {
        var dialog = new EmployeeWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<EmployeeViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowEmployeeVacationVoucherDialogAsync
        (InteractionContext<EmployeeVacationVoucherViewModel, EmployeeVacationVoucherViewModel?> interaction)
    {
        var dialog = new EmployeeVacationVoucherWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<EmployeeVacationVoucherViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowOccupationDialogAsync(InteractionContext<OccupationViewModel,
    OccupationViewModel?> interaction)
    {
        var dialog = new OccupationWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<OccupationViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowVacationVoucherDialogAsync(InteractionContext<VacationVoucherViewModel,
        VacationVoucherViewModel?> interaction)
    {
        var dialog = new VacationVoucherWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<VacationVoucherViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowVoucherTypeDialogAsync(InteractionContext<VoucherTypeViewModel,
        VoucherTypeViewModel?> interaction)
    {
        var dialog = new VoucherTypeWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<VoucherTypeViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowWorkshopDialogAsync(InteractionContext<WorkshopViewModel,
    WorkshopViewModel?> interaction)
    {
        var dialog = new WorkshopWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<WorkshopViewModel?>(this);
        interaction.SetOutput(result);
    }
}