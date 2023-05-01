using ReactiveUI;
using System;
using System.Reactive;

namespace SocialNetwork.Client.ViewModels;

public class GroupViewModel : ViewModelBase
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

    private string _description = string.Empty;

	public string Description 
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

	private DateTime? _creationDate;

	public DateTime? CreationDate 
    {
        get => _creationDate;
        set => this.RaiseAndSetIfChanged(ref _creationDate, value); 
    }

    private int _userId;

	public int UserId 
    {
        get => _userId;
        set => this.RaiseAndSetIfChanged(ref _userId, value);
    }

	public ReactiveCommand<Unit, GroupViewModel> OnSubmitCommand { get; set; } 

    public GroupViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
