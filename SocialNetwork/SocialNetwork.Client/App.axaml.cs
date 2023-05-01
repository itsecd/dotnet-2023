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

			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<GroupDtoGet, GroupViewModel>();
				cfg.CreateMap<GroupViewModel, GroupDtoGet>();
				cfg.CreateMap<NoteDtoGet, NoteViewModel>();
				cfg.CreateMap<NoteViewModel, NoteDtoGet>();
				cfg.CreateMap<RoleDtoGet, RoleViewModel>();
				cfg.CreateMap<RoleViewModel, RoleDtoGet>();
				cfg.CreateMap<UserDtoGet, UserViewModel>();
				cfg.CreateMap<UserViewModel, UserDtoGet>();

				cfg.CreateMap<GroupViewModel, GroupDtoPostOrPut>();
				cfg.CreateMap<GroupDtoPostOrPut, GroupViewModel>();
				cfg.CreateMap<NoteViewModel, NoteDtoPostOrPut>();
				cfg.CreateMap<NoteDtoPostOrPut, NoteViewModel>();
				cfg.CreateMap<RoleViewModel, RoleDtoPostOrPut>();
				cfg.CreateMap<RoleDtoPostOrPut, RoleViewModel>();
				cfg.CreateMap<UserViewModel, UserDtoPostOrPut>();
				cfg.CreateMap<UserDtoPostOrPut, UserViewModel>();
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