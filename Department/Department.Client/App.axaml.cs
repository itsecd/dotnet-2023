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
                cfg.CreateMap<GroupViewModel, GroupGetDto>();
                cfg.CreateMap<GroupViewModel, GroupSetDto>();
                cfg.CreateMap<GroupGetDto, GroupViewModel>();
                cfg.CreateMap<GroupSetDto, GroupViewModel>();

                cfg.CreateMap<TeacherViewModel, TeacherGetDto>();
                cfg.CreateMap<TeacherViewModel, TeacherSetDto>();
                cfg.CreateMap<TeacherGetDto, TeacherViewModel>();
                cfg.CreateMap<TeacherSetDto, TeacherViewModel>();

                cfg.CreateMap<SubjectViewModel, SubjectGetDto>();
                cfg.CreateMap<SubjectViewModel, SubjectSetDto>();
                cfg.CreateMap<SubjectGetDto, SubjectViewModel>();
                cfg.CreateMap<SubjectSetDto, SubjectViewModel>();

                cfg.CreateMap<CourseViewModel, CourseGetDto>();
                cfg.CreateMap<CourseViewModel, CourseSetDto>();
                cfg.CreateMap<CourseGetDto, CourseViewModel>();
                cfg.CreateMap<CourseSetDto, CourseViewModel>();
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