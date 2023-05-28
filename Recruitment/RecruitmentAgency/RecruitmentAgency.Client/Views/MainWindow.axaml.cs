using Avalonia.ReactiveUI;
using ReactiveUI;
using RecruitmentAgency.Client.ViewModels;
using System.Threading.Tasks;

namespace RecruitmentAgency.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowCompanyDialog.RegisterHandler(ShowCompanyDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowCompanyApplicationDialog.RegisterHandler(ShowCompanyApplicationDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowEmployeeDialog.RegisterHandler(ShowEmployeeDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowJobApplicationDialog.RegisterHandler(ShowJobApplicationDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowTitleDialog.RegisterHandler(ShowTitleDialogAsync)));
    }

    private async Task ShowCompanyDialogAsync(InteractionContext<CompanyViewModel, CompanyViewModel?> interaction)
    {
        var dialog = new CompanyWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<CompanyViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowCompanyApplicationDialogAsync(InteractionContext<CompanyApplicationViewModel, CompanyApplicationViewModel?> interaction)
    {
        var dialog = new CompanyApplicationWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<CompanyApplicationViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowEmployeeDialogAsync(InteractionContext<EmployeeViewModel, EmployeeViewModel?> interaction)
    {
        var dialog = new EmployeeWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<EmployeeViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowJobApplicationDialogAsync(InteractionContext<JobApplicationViewModel, JobApplicationViewModel?> interaction)
    {
        var dialog = new JobApplicationWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<JobApplicationViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task ShowTitleDialogAsync(InteractionContext<TitleViewModel, TitleViewModel?> interaction)
    {
        var dialog = new TitleWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<TitleViewModel?>(this);
        interaction.SetOutput(result);
    }
}