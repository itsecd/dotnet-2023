
using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

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

	[Required]
	public string Name 
	{
		get => _name;
		set => this.RaiseAndSetIfChanged(ref _name, value);
	}

	public ReactiveCommand<Unit, RoleViewModel> OnSubmitCommand { get; set; }

	public RoleViewModel()
	{
		OnSubmitCommand = ReactiveCommand.Create(() => this);
	}
}
