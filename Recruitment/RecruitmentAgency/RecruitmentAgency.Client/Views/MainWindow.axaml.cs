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

        this.WhenActivated(d => d(ViewModel!.ShowCompanyDialog.RegisterHandler(ShowDialogAsync)));
    }
    private async Task ShowDialogAsync(InteractionContext<CompanyViewModel, CompanyViewModel?> interaction) {
        var dialog = new CompanyWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<CompanyViewModel?>(this);
        interaction.SetOutput(result);
    }
}