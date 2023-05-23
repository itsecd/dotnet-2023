using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LibrarySchool.Desktop.ViewModels;
using LibrarySchool.Desktop.Views;
using Splat;

namespace LibrarySchool.Desktop;
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
            var mapperBulder = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentGetDto, StudentViewModel>();
                cfg.CreateMap<StudentPostDto, StudentViewModel>().ReverseMap();
                cfg.CreateMap<ClassTypeGetDto, ClassTypeViewModel>();
                cfg.CreateMap<ClassTypePostDto, ClassTypeViewModel>().ReverseMap();
                cfg.CreateMap<SubjectGetDto, SubjectViewModel>();
                cfg.CreateMap<SubjectPostDto, SubjectViewModel>().ReverseMap();
                cfg.CreateMap<MarkGetDto, MarkViewModel>();
                cfg.CreateMap<MarkPostDto, MarkViewModel>().ReverseMap();
            });
            Locator.CurrentMutable.RegisterConstant(new ClientApiWrapper());
            Locator.CurrentMutable.RegisterConstant(mapperBulder.CreateMapper(), typeof(IMapper));
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}