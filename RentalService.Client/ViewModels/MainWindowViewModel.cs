using System.Collections.ObjectModel;

namespace RentalService.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ClientViewModel> Clients { get; } = new();

    public MainWindowViewModel()
    {
        
    }
}