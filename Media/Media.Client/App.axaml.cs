using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Media.Client.ViewModels;
using Media.Client.Views;
using Splat;

namespace Media.Client;
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArtistGetDto, ArtistViewModel>();
                cfg.CreateMap<ArtistViewModel, ArtistPostDto>();
                cfg.CreateMap<AlbumGetDto, AlbumViewModel>();
                cfg.CreateMap<AlbumViewModel, AlbumPostDto>();
                cfg.CreateMap<Genre, GenreViewModel>();
                cfg.CreateMap<GenreViewModel, GenrePostDto>();
            });
            Locator.CurrentMutable.RegisterConstant(new ApiWrapper());
            Locator.CurrentMutable.RegisterConstant(config.CreateMapper(), typeof(IMapper));

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}