using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace SocialNetwork.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
	private readonly ApiWrapper _apiClient;

	private readonly IMapper _mapper;

	private GroupViewModel? _selectedGroup;

	public GroupViewModel? SelectedGroup
	{
		get => _selectedGroup;
		set => this.RaiseAndSetIfChanged(ref _selectedGroup, value);
	}

	private NoteViewModel? _selectedNote;

	public NoteViewModel? SelectedNote
	{
		get => _selectedNote;
		set => this.RaiseAndSetIfChanged(ref _selectedNote, value);
	}

	private RoleViewModel? _selectedRole;

	public RoleViewModel? SelectedRole
	{
		get => _selectedRole;
		set => this.RaiseAndSetIfChanged(ref _selectedRole, value);
	}

	private UserViewModel? _selectedUser;

	public UserViewModel? SelectedUser
	{
		get => _selectedUser;
		set => this.RaiseAndSetIfChanged(ref _selectedUser, value);
	}

	public ObservableCollection<GroupViewModel> Groups { get; } = new();

	public ObservableCollection<NoteViewModel> Notes { get; } = new();

	public ObservableCollection<RoleViewModel> Roles { get; } = new();

	public ObservableCollection<UserViewModel> Users { get; } = new();

	public ReactiveCommand<Unit, Unit> OnAddGroupCommand { get; set; }

	public ReactiveCommand<Unit, Unit> OnChangeGroupCommand { get; set; }

	public ReactiveCommand<Unit, Unit> OnDeleteGroupCommand { get; set; }

	public ReactiveCommand<Unit, Unit> OnAddNoteCommand { get; set; }

	public ReactiveCommand<Unit, Unit> OnChangeNoteCommand { get; set; }

	public ReactiveCommand<Unit, Unit> OnDeleteNoteCommand { get; set; }

	//public ReactiveCommand<Unit, Unit> OnAddRoleCommand { get; set; }

	//public ReactiveCommand<Unit, Unit> OnChangeRoleCommand { get; set; }

	//public ReactiveCommand<Unit, Unit> OnDeleteRoleCommand { get; set; }

	//public ReactiveCommand<Unit, Unit> OnAddUserCommand { get; set; }

	//public ReactiveCommand<Unit, Unit> OnChangeUserCommand { get; set; }

	//public ReactiveCommand<Unit, Unit> OnDeleteUserCommand { get; set; }

	public Interaction<GroupViewModel, GroupViewModel?> ShowGroupDialog { get; set; }

	public Interaction<NoteViewModel, NoteViewModel?> ShowNoteDialog { get; set; }

	public Interaction<RoleViewModel, RoleViewModel?> ShowRoleDialog { get; set; }

	public Interaction<UserViewModel, UserViewModel?> ShowUserDialog { get; set; }

	public MainWindowViewModel()
	{
		_apiClient = Locator.Current.GetService<ApiWrapper>();
		_mapper = Locator.Current.GetService<IMapper>();

		ShowGroupDialog = new Interaction<GroupViewModel, GroupViewModel?>();
		ShowNoteDialog = new Interaction<NoteViewModel, NoteViewModel?>();
		ShowRoleDialog = new Interaction<RoleViewModel, RoleViewModel?>();
		ShowUserDialog = new Interaction<UserViewModel, UserViewModel?>();

		RxApp.MainThreadScheduler.Schedule(LoadGroupsAsync);
		RxApp.MainThreadScheduler.Schedule(LoadNotesAsync);
		RxApp.MainThreadScheduler.Schedule(LoadRolesAsync);
		RxApp.MainThreadScheduler.Schedule(LoadUsersAsync);

		OnAddGroupCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			var groupViewModel = await ShowGroupDialog.Handle(new GroupViewModel());

			if (groupViewModel != null)
			{
				await _apiClient.CreateGroup(_mapper.Map<GroupDtoPostOrPut>(groupViewModel));

				Groups.Add(groupViewModel);
			}
		});

		OnChangeGroupCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			var groupViewModel = await ShowGroupDialog.Handle(SelectedGroup!);

			if (groupViewModel != null)
			{
				await _apiClient.UpdateGroup(SelectedGroup!.Id, 
					_mapper.Map<GroupDtoPostOrPut>(groupViewModel));

				_mapper.Map(groupViewModel, SelectedGroup);

			}
		}, this.WhenAnyValue(vm => vm.SelectedGroup)
			.Select(selectGroup => selectGroup != null));

		OnDeleteGroupCommand = ReactiveCommand.CreateFromTask(async () =>
		{

			await _apiClient.DeleteGroup(SelectedGroup!.Id);

			Groups.Remove(SelectedGroup);
			
		}, this.WhenAnyValue(vm => vm.SelectedGroup)
			.Select(selectGroup => selectGroup != null));

		OnAddNoteCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			var noteViewModel = await ShowNoteDialog.Handle(new NoteViewModel());

			if (noteViewModel != null)
			{
				await _apiClient.CreateNote(_mapper.Map<NoteDtoPostOrPut>(noteViewModel));

				Notes.Add(noteViewModel);
			}
		});

		OnChangeNoteCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			var noteViewModel = await ShowNoteDialog.Handle(SelectedNote!);

			if (noteViewModel != null)
			{
				await _apiClient.UpdateNote(SelectedNote!.Id,
					_mapper.Map<NoteDtoPostOrPut>(noteViewModel));

				_mapper.Map(noteViewModel, SelectedNote);

			}
		}, this.WhenAnyValue(vm => vm.SelectedNote)
			.Select(selectNote => selectNote != null));

		OnDeleteNoteCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			await _apiClient.DeleteNote(SelectedNote!.Id);
			Notes.Remove(SelectedNote);
		}, this.WhenAnyValue(vm => vm.SelectedNote)
			.Select(selectNote => selectNote != null));
	}

	private async void LoadGroupsAsync()
	{
		foreach (var group in await _apiClient.GetAllGroups())
		{
			Groups.Add(_mapper.Map<GroupViewModel>(group));
		}
	}

	private async void LoadNotesAsync()
	{
		foreach (var note in await _apiClient.GetAllNotes())
		{
			Notes.Add(_mapper.Map<NoteViewModel>(note));
		}
	}

	private async void LoadRolesAsync()
	{
		foreach (var role in await _apiClient.GetAllRoles())
		{
			Roles.Add(_mapper.Map<RoleViewModel>(role));
		}
	}

	private async void LoadUsersAsync()
	{
		foreach (var user in await _apiClient.GetAllUsers())
		{
			Users.Add(_mapper.Map<UserViewModel>(user));
		}
	}
}
