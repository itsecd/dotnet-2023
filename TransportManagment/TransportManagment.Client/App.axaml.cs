using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;
using TransportManagment.Client.ViewModels;
using TransportManagment.Client.Views; 

namespace TransportManagment.Client;
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
                cfg.CreateMap<DriverGetDto, DriverViewModel>();
                cfg.CreateMap<DriverViewModel, DriverGetDto>();
                cfg.CreateMap<DriverPostDto, DriverViewModel>();
                cfg.CreateMap<DriverViewModel, DriverPostDto>();

                cfg.CreateMap<TransportGetDto, TransportViewModel>();
                cfg.CreateMap<TransportViewModel, TransportGetDto>();
                cfg.CreateMap<TransportPostDto, TransportViewModel>();
                cfg.CreateMap<TransportViewModel, TransportPostDto>();

                cfg.CreateMap<RouteGetDto, RouteViewModel>();
                cfg.CreateMap<RouteViewModel, RouteGetDto>();
                cfg.CreateMap<RoutePostDto, RouteViewModel>();
                cfg.CreateMap<RouteViewModel, RoutePostDto>();
                
                cfg.CreateMap<DriverPropertiesRouteDto, DriverPropertiesRouteViewModel>();
                cfg.CreateMap<DriverPropertiesRouteViewModel, DriverPropertiesRouteDto>();

                cfg.CreateMap<TopDriversDto, TopDriversViewModel>();
                cfg.CreateMap<TopDriversViewModel, TopDriversDto>();

                cfg.CreateMap<TransportInfoDto, TransportInfoViewModel>();
                cfg.CreateMap<TransportInfoViewModel, TransportInfoDto>();

                cfg.CreateMap<TransportTimeModelDto, TransportTimeViewModel>();
                cfg.CreateMap<TransportTimeViewModel, TransportTimeModelDto>();
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