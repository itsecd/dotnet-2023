using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SelectionCommittee.Client.ViewModels;
using SelectionCommittee.Client.Views;
using Splat;

namespace SelectionCommittee.Client;
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
                cfg.CreateMap<EnrolleeDtoGet, EnrolleeViewModel>();
                cfg.CreateMap<EnrolleeViewModel, EnrolleeDtoGet>();
                cfg.CreateMap<ExamResultDtoGet, ExamResultViewModel>();
                cfg.CreateMap<ExamResultViewModel, ExamResultDtoGet>();
                cfg.CreateMap<FacultyDtoGet, FacultyViewModel>();
                cfg.CreateMap<FacultyViewModel, FacultyDtoGet>();
                cfg.CreateMap<SpecializationDtoGet, SpecializationViewModel>();
                cfg.CreateMap<SpecializationViewModel, SpecializationDtoGet>();

                cfg.CreateMap<EnrolleeDtoPostOrPut, EnrolleeViewModel>();
                cfg.CreateMap<EnrolleeViewModel, EnrolleeDtoPostOrPut>();
                cfg.CreateMap<ExamResultDtoPostOrPut, ExamResultViewModel>();
                cfg.CreateMap<ExamResultViewModel, ExamResultDtoPostOrPut>();
                cfg.CreateMap<FacultyDtoPostOrPut, FacultyViewModel>();
                cfg.CreateMap<FacultyViewModel, FacultyDtoPostOrPut>();
                cfg.CreateMap<SpecializationDtoPostOrPut, SpecializationViewModel>();
                cfg.CreateMap<SpecializationViewModel, SpecializationDtoPostOrPut>();
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