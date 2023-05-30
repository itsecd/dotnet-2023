using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Poluclinic.Client;
using Polyclinic.Client.ViewModels;
using Polyclinic.Client.Views;
using Splat;

namespace Polyclinic.Client;
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
                cfg.CreateMap<PatientGetDto, PatientViewModel>();
                cfg.CreateMap<PatientViewModel, PatientGetDto>();
                cfg.CreateMap<PatientViewModel, PatientPostDto>();
                cfg.CreateMap<PatientPostDto, PatientViewModel>();

                cfg.CreateMap<DoctorGetDto, DoctorViewModel>();
                cfg.CreateMap<DoctorViewModel, DoctorGetDto>();
                cfg.CreateMap<DoctorViewModel, DoctorPostDto>();
                cfg.CreateMap<DoctorPostDto, DoctorViewModel>();
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