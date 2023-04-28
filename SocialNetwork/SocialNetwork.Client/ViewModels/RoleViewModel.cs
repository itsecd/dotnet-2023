
using ReactiveUI;

namespace SocialNetwork.Client.ViewModels;

public class RoleViewModel : ViewModelBase
{
	private int _id;

	public int Id 
	{
		get => _id;
		set => this.RaiseAndSetIfChanged(ref _id, value);
	}

	private string _name = string.Empty;

	public string Name 
	{
		get => _name;
		set => this.RaiseAndSetIfChanged(ref _name, value);
	}
}
