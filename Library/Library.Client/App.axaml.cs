using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Library.Client.ViewModels;
using Library.Client.Views;
using Splat;

namespace Library.Client;
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
                cfg.CreateMap<BookGetDto, BookViewModel>();
                cfg.CreateMap<BookViewModel, BookGetDto>();
                cfg.CreateMap<BookViewModel, BookPostDto>();
                cfg.CreateMap<BookPostDto, BookViewModel>();

                cfg.CreateMap<CardGetDto, CardViewModel>();
                cfg.CreateMap<CardViewModel, CardGetDto>();
                cfg.CreateMap<CardViewModel, CardPostDto>();
                cfg.CreateMap<CardPostDto, CardViewModel>();

                cfg.CreateMap<DepartmentGetDto, DepartmentViewModel>();
                cfg.CreateMap<DepartmentViewModel, DepartmentGetDto>();
                cfg.CreateMap<DepartmentViewModel, DepartmentPostDto>();
                cfg.CreateMap<DepartmentPostDto, DepartmentViewModel>();

                cfg.CreateMap<ReaderGetDto, ReaderViewModel>();
                cfg.CreateMap<ReaderViewModel, ReaderGetDto>();
                cfg.CreateMap<ReaderViewModel, ReaderPostDto>();
                cfg.CreateMap<ReaderPostDto, ReaderViewModel>();

                cfg.CreateMap<TypeEditionGetDto, TypeEditionViewModel>();
                cfg.CreateMap<TypeEditionViewModel, TypeEditionGetDto>();

                cfg.CreateMap<TypeDepartmentGetDto, TypeDepartmentViewModel>();
                cfg.CreateMap<TypeDepartmentViewModel, TypeDepartmentGetDto>();
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