using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;
using UniversityData.Client.ViewModels;
using UniversityData.Client.Views;

namespace UniversityData.Client;
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
                cfg.CreateMap<ConstructionPropertyGetDto, ConstructionPropertyViewModel>();
                cfg.CreateMap<ConstructionPropertyViewModel, ConstructionPropertyPostDto>();
                cfg.CreateMap<UniversityPropertyGetDto, UniversityPropertyViewModel>();
                cfg.CreateMap<UniversityPropertyViewModel, UniversityPropertyPostDto>();
                cfg.CreateMap<DepartmentGetDto, DepartmentViewModel>();
                cfg.CreateMap<DepartmentViewModel, DepartmentPostDto>();
                cfg.CreateMap<FacultyGetDto, FacultyViewModel>();
                cfg.CreateMap<FacultyViewModel, FacultyPostDto>();
                cfg.CreateMap<RectorGetDto, RectorViewModel>();
                cfg.CreateMap<RectorViewModel, RectorPostDto>();
                cfg.CreateMap<SpecialtyGetDto, SpecialtyViewModel>();
                cfg.CreateMap<SpecialtyViewModel, SpecialtyPostDto>();
                cfg.CreateMap<SpecialtyTableNodeGetDto, SpecialtyTableNodeViewModel>();
                cfg.CreateMap<SpecialtyTableNodeViewModel, SpecialtyTableNodePostDto>();
                cfg.CreateMap<UniversityGetDto, UniversityViewModel>();
                cfg.CreateMap<UniversityViewModel, UniversityPostDto>();
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