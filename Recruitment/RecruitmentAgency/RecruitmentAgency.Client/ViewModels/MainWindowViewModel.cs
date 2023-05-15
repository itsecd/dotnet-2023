using System.Collections.ObjectModel;

namespace RecruitmentAgency.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<CompanyViewModel> Companies { get; } = new();
    public MainWindowViewModel() {
        
    }
}
