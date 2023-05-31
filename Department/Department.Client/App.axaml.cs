using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Department.Client.ViewModels;
using Department.Client.Views;
using Splat;

namespace Department.Client;
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
                cfg.CreateMap<GroupViewModel, GroupSetDto>();
                cfg.CreateMap<GroupGetDto, GroupViewModel>();

                cfg.CreateMap<TeacherViewModel, TeacherSetDto>();
                cfg.CreateMap<TeacherGetDto, TeacherViewModel>();

                cfg.CreateMap<SubjectViewModel, SubjectSetDto>();
                cfg.CreateMap<SubjectGetDto, SubjectViewModel>();

                cfg.CreateMap<CourseViewModel, CourseSetDto>();
                cfg.CreateMap<CourseGetDto, CourseViewModel>();
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