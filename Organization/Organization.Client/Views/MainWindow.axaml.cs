using Avalonia.Controls;
using Avalonia.ReactiveUI;
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
            disposableObj(ViewModel!.ShowDepartmentDialog.RegisterHandler(ShowDepartmentDialogAsync)));
        this.WhenActivated(disposableObj =>
        disposableObj(ViewModel!.ShowWorkshopDialog.RegisterHandler(ShowWorkshopDialogAsync)));
        this.WhenActivated(disposableObj =>
        disposableObj(ViewModel!.ShowEmployeeDialog.RegisterHandler(ShowEmployeeDialogAsync)));
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
}