using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace SocialNetwork.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
	private readonly ApiWrapper _apiClient;

	private readonly IMapper _mapper;

	private GroupViewModel? _selectedGroup;

	private string _groupExceptionValue = string.Empty;

	public string GroupExceptionValue
	{
		get => _groupExceptionValue;
		set => this.RaiseAndSetIfChanged(ref _groupExceptionValue, value);
	}

	private string _noteExceptionValue = string.Empty;

	public string NoteExceptionValue
	{
		get => _noteExceptionValue;
		set => this.RaiseAndSetIfChanged(ref _noteExceptionValue, value);
	}

	private string _roleExceptionValue = string.Empty;

	public string RoleExceptionValue
	{
		get => _roleExceptionValue;
		set => this.RaiseAndSetIfChanged(ref _roleExceptionValue, value);
	}

	private string _userExceptionValue = string.Empty;

	public string UserExceptionValue
	{
		get => _userExceptionValue;
		set => this.RaiseAndSetIfChanged(ref _userExceptionValue, value);
	}

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

	public ReactiveCommand<Unit, Unit> OnAddRoleCommand { get; set; }

	public ReactiveCommand<Unit, Unit> OnChangeRoleCommand { get; set; }

	public ReactiveCommand<Unit, Unit> OnDeleteRoleCommand { get; set; }

	public ReactiveCommand<Unit, Unit> OnAddUserCommand { get; set; }

	public ReactiveCommand<Unit, Unit> OnChangeUserCommand { get; set; }

	public ReactiveCommand<Unit, Unit> OnDeleteUserCommand { get; set; }

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
				try
				{
					groupViewModel.Id = await _apiClient
						.CreateGroup(_mapper.Map<GroupDtoPostOrPut>(groupViewModel));				
					Groups.Add(groupViewModel);

					if (Roles.FirstOrDefault(role => role.Name == "Админ") == null)
					{
						Roles.Add(new RoleViewModel
						{
							Id = await _apiClient.CreateRole(new RoleDtoPostOrPut
							{
								Name = "Админ"
							}),
							Name = "Админ"
						});
					}

					ClearExceptionsValues();
				}
				catch (Exception ex)
				{
					GroupExceptionValue = ex.Message;
				}
			}
		});

		OnChangeGroupCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			var groupViewModel = await ShowGroupDialog.Handle(SelectedGroup!);

			if (groupViewModel != null)
			{
				try
				{
					await _apiClient.UpdateGroup(SelectedGroup!.Id,
						_mapper.Map<GroupDtoPostOrPut>(groupViewModel));
					_mapper.Map(groupViewModel, SelectedGroup);
					ClearExceptionsValues();
				}
				catch (Exception ex)
				{
					GroupExceptionValue = ex.Message;
				}

			}
		}, this.WhenAnyValue(vm => vm.SelectedGroup)
			.Select(selectGroup => selectGroup != null));

		OnDeleteGroupCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			try
			{
				await _apiClient.DeleteGroup(SelectedGroup!.Id);

				foreach (var note in Notes.Where(note => note.GroupId == SelectedGroup!.Id).ToList())
				{
					Notes.Remove(note);
				}

				Groups.Remove(SelectedGroup!);
				ClearExceptionsValues();
			}
			catch (Exception ex)
			{
				GroupExceptionValue = ex.Message;
			}
			
		}, this.WhenAnyValue(vm => vm.SelectedGroup)
			.Select(selectGroup => selectGroup != null));

		OnAddNoteCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			var noteViewModel = await ShowNoteDialog.Handle(new NoteViewModel());

			if (noteViewModel != null)
			{
				try
				{
					noteViewModel.Id = await _apiClient
						.CreateNote(_mapper.Map<NoteDtoPostOrPut>(noteViewModel));
					Notes.Add(_mapper.Map<NoteViewModel>(noteViewModel));
					ClearExceptionsValues();
				}
				catch (Exception ex)
				{
					NoteExceptionValue = ex.Message;
				}
			}
		});

		OnChangeNoteCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			var noteViewModel = await ShowNoteDialog.Handle(SelectedNote!);

			if (noteViewModel != null)
			{
				try
				{
					await _apiClient.UpdateNote(SelectedNote!.Id,
						_mapper.Map<NoteDtoPostOrPut>(noteViewModel));
					_mapper.Map(noteViewModel, SelectedNote);
					ClearExceptionsValues();
				}
				catch (Exception ex)
				{
					NoteExceptionValue = ex.Message;
				}
			}
		}, this.WhenAnyValue(vm => vm.SelectedNote)
			.Select(selectNote => selectNote != null));

		OnDeleteNoteCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			try
			{
				await _apiClient.DeleteNote(SelectedNote!.Id);
				Notes.Remove(SelectedNote);
				ClearExceptionsValues();
			}
			catch (Exception ex)
			{
				NoteExceptionValue = ex.Message;
			}
		}, this.WhenAnyValue(vm => vm.SelectedNote)
			.Select(selectNote => selectNote != null));

		OnAddRoleCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			var roleViewModel = await ShowRoleDialog.Handle(new RoleViewModel());

			if (roleViewModel != null)
			{
				try
				{
					roleViewModel.Id = await _apiClient
						.CreateRole(_mapper.Map<RoleDtoPostOrPut>(roleViewModel));
					Roles.Add(roleViewModel);
					ClearExceptionsValues();
				}
				catch (Exception ex)
				{
					RoleExceptionValue = ex.Message;
				}
			}
		});

		OnChangeRoleCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			var roleViewModel = await ShowRoleDialog.Handle(SelectedRole!);

			if (roleViewModel != null)
			{
				try
				{
					await _apiClient.UpdateRole(SelectedRole!.Id,
						_mapper.Map<RoleDtoPostOrPut>(roleViewModel));
					_mapper.Map(roleViewModel, SelectedRole);
					ClearExceptionsValues();
				}
				catch (Exception ex)
				{
					RoleExceptionValue = ex.Message;
				}
			}
		}, this.WhenAnyValue(vm => vm.SelectedRole)
			.Select(selectRole => selectRole != null));

		OnDeleteRoleCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			try
			{
				await _apiClient.DeleteRole(SelectedRole!.Id);
				Roles.Remove(SelectedRole);
				ClearExceptionsValues();
			}
			catch (Exception ex)
			{
				RoleExceptionValue = ex.Message;
			}

		}, this.WhenAnyValue(vm => vm.SelectedRole)
			.Select(selectRole => selectRole != null));

		OnAddUserCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			var userViewModel = await ShowUserDialog.Handle(new UserViewModel());

			if (userViewModel != null)
			{
				try
				{
					userViewModel.Id = await _apiClient
						.CreateUser(_mapper.Map<UserDtoPostOrPut>(userViewModel));
					Users.Add(_mapper.Map<UserViewModel>(userViewModel));
					ClearExceptionsValues();
				}
				catch (Exception ex)
				{
					UserExceptionValue = ex.Message;
				}
			}
		});

		OnChangeUserCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			var userViewModel = await ShowUserDialog.Handle(SelectedUser!);

			if (userViewModel != null)
			{
				try
				{
					await _apiClient.UpdateUser(SelectedUser!.Id,
						_mapper.Map<UserDtoPostOrPut>(userViewModel));
					_mapper.Map(userViewModel, SelectedUser);
					ClearExceptionsValues();
				}
				catch (Exception ex)
				{
					UserExceptionValue = ex.Message;
				}
			}
		}, this.WhenAnyValue(vm => vm.SelectedUser)
			.Select(selectUser => selectUser != null));

		OnDeleteUserCommand = ReactiveCommand.CreateFromTask(async () =>
		{
			try
			{
				await _apiClient.DeleteUser(SelectedUser!.Id);

				foreach (var note in Notes.Where(note => note.UserId == SelectedUser!.Id).ToList())
				{
					Notes.Remove(note);
				}

				foreach (var group in Groups
					.Where(group => group.UserId == SelectedUser!.Id).ToList())
				{
					Groups.Remove(group);
				}

				Users.Remove(SelectedUser!);
				ClearExceptionsValues();
			}
			catch (Exception ex)
			{
				UserExceptionValue = ex.Message;
			}
		}, this.WhenAnyValue(vm => vm.SelectedUser)
			.Select(selectUser => selectUser != null));
	}

	private void ClearExceptionsValues()
	{
		GroupExceptionValue = string.Empty;
		NoteExceptionValue = string.Empty;
		RoleExceptionValue = string.Empty;
		UserExceptionValue = string.Empty;
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
