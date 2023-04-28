using Splat;
using System.Collections.ObjectModel;

namespace SocialNetwork.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
	private readonly ApiWrapper _apiClient;

	public ObservableCollection<GroupViewModel> Groups { get; } = new();

	public ObservableCollection<NoteViewModel> Notes { get; } = new();

	public ObservableCollection<RoleViewModel> Roles { get; } = new();

	public ObservableCollection<UserViewModel> Users { get; } = new();

	public MainWindowViewModel()
	{
		_apiClient = Locator.Current.GetService<ApiWrapper>();
		LoadGroupsAsync();
	}

	private async void LoadGroupsAsync()
	{
		var groups = await _apiClient.GetAllGroups();
	}
}
