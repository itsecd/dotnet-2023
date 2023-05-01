using Avalonia.ReactiveUI;
using ReactiveUI;
using SocialNetwork.Client.ViewModels;
using System.Threading.Tasks;

namespace SocialNetwork.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
	public MainWindow()
	{
		InitializeComponent();

		this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowGroupDialog.RegisterHandler(ShowGroupDialogAsync)));
		this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowNoteDialog.RegisterHandler(ShowNoteDialogAsync)));
		this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowRoleDialog.RegisterHandler(ShowRoleDialogAsync)));
		this.WhenActivated(disposableElement => disposableElement(ViewModel!.ShowUserDialog.RegisterHandler(ShowUserDialogAsync)));
	}

	private async Task ShowGroupDialogAsync(InteractionContext<GroupViewModel, GroupViewModel?> interaction)
	{
		var dialog = new GroupWindow
		{
			DataContext = interaction.Input
		};

		var result = await dialog.ShowDialog<GroupViewModel?>(this);
		interaction.SetOutput(result);
	}

	private async Task ShowNoteDialogAsync(InteractionContext<NoteViewModel, NoteViewModel?> interaction)
	{
		var dialog = new NoteWindow
		{
			DataContext = interaction.Input
		};

		var result = await dialog.ShowDialog<NoteViewModel?>(this);
		interaction.SetOutput(result);
	}

	private async Task ShowRoleDialogAsync(InteractionContext<RoleViewModel, RoleViewModel?> interaction)
	{
		var dialog = new RoleWindow
		{
			DataContext = interaction.Input
		};

		var result = await dialog.ShowDialog<RoleViewModel?>(this);
		interaction.SetOutput(result);
	}

	private async Task ShowUserDialogAsync(InteractionContext<UserViewModel, UserViewModel?> interaction)
	{
		var dialog = new UserWindow
		{
			DataContext = interaction.Input
		};

		var result = await dialog.ShowDialog<UserViewModel?>(this);
		interaction.SetOutput(result);
	}
}