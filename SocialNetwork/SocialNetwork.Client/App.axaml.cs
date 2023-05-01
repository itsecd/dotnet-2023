using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SocialNetwork.Client.ViewModels;
using SocialNetwork.Client.Views;
using Splat;

namespace SocialNetwork.Client;
public partial class App : Application
{
	public override void Initialize()
	{
		AvaloniaXamlLoader.Load(this);
	}

	public override void OnFrameworkInitializationCompleted()
	{
		if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
		{
			Locator.CurrentMutable.RegisterConstant(new ApiWrapper());

			var config = new MapperConfiguration(configuration =>
			{
				configuration.CreateMap<GroupDtoGet, GroupViewModel>();
				configuration.CreateMap<GroupViewModel, GroupDtoGet>();
				configuration.CreateMap<NoteDtoGet, NoteViewModel>();
				configuration.CreateMap<NoteViewModel, NoteDtoGet>();
				configuration.CreateMap<RoleDtoGet, RoleViewModel>();
				configuration.CreateMap<RoleViewModel, RoleDtoGet>();
				configuration.CreateMap<UserDtoGet, UserViewModel>();
				configuration.CreateMap<UserViewModel, UserDtoGet>();

				configuration.CreateMap<GroupViewModel, GroupDtoPostOrPut>();
				configuration.CreateMap<GroupDtoPostOrPut, GroupViewModel>();
				configuration.CreateMap<NoteViewModel, NoteDtoPostOrPut>();
				configuration.CreateMap<NoteDtoPostOrPut, NoteViewModel>();
				configuration.CreateMap<RoleViewModel, RoleDtoPostOrPut>();
				configuration.CreateMap<RoleDtoPostOrPut, RoleViewModel>();
				configuration.CreateMap<UserViewModel, UserDtoPostOrPut>();
				configuration.CreateMap<UserDtoPostOrPut, UserViewModel>();
			});

			Locator.CurrentMutable.RegisterConstant(config.CreateMapper(), typeof(IMapper));

			desktop.MainWindow = new MainWindow
			{
				DataContext = new MainWindowViewModel(),
			};
		}

		base.OnFrameworkInitializationCompleted();
	}
}