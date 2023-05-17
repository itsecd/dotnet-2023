using Splat;
using System.Collections.ObjectModel;

namespace Factory.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<EnterpriseViewModel> Enterprises { get; set; } = new();

    private readonly ApiWrapper _apiClient;
    public MainWindowViewModel() 
    { 
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        
    }

    private async void LoadEnterprisesAsync()
    {
        var enterprises = await _apiClient.GetEnterpriseAsync();
    }
}
