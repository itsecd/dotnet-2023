using System.Collections.ObjectModel;

namespace PonrfClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<PrivatizedBuildingViewModel> PrivatizedBuildings { get;} = new();
}
