using Avalonia.Controls;
using Avalonia.ReactiveUI;
using OrganizationClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace OrganizationClient.Views;
public partial class MainWindow : BaseWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableObj => 
            disposableObj(ViewModel!.ShowDepartmentDialog.RegisterHandler(ShowDialogAsync)));
    }

    private async Task ShowDialogAsync(InteractionContext<DepartmentViewModel, DepartmentViewModel?> interaction)
    {
        var dialog = new DepartmentWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<DepartmentViewModel?>(this);
        interaction.SetOutput(result);
    }
}