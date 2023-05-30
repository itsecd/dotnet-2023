using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using School.Client.ViewModels;
using School.Client.Views;
using Splat;

namespace School.Client;
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
                cfg.CreateMap<ClassGetDto, ClassViewModel>();
                cfg.CreateMap<ClassViewModel, ClassGetDto>();
                cfg.CreateMap<GradeGetDto, GradeViewModel>();
                cfg.CreateMap<GradeViewModel, GradeGetDto>();
                cfg.CreateMap<StudentGetDto, StudentViewModel>();
                cfg.CreateMap<StudentViewModel, StudentGetDto>();
                cfg.CreateMap<SubjectGetDto, SubjectViewModel>();
                cfg.CreateMap<SubjectViewModel, SubjectGetDto>();

                cfg.CreateMap<ClassPostDto, ClassViewModel>();
                cfg.CreateMap<ClassViewModel, ClassPostDto>();
                cfg.CreateMap<GradePostDto, GradeViewModel>();
                cfg.CreateMap<GradeViewModel, GradePostDto>();
                cfg.CreateMap<StudentPostDto, StudentViewModel>();
                cfg.CreateMap<StudentViewModel, StudentPostDto>();
                cfg.CreateMap<SubjectPostDto, SubjectViewModel>();
                cfg.CreateMap<SubjectViewModel, SubjectPostDto>();
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