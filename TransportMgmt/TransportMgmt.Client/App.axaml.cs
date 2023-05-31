using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;
using TransportMgmt.Client.ViewModels;
using TransportMgmt.Client.Views;

namespace TransportMgmt.Client;
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
                cfg.CreateMap<RoutesGetDto, RoutesViewModel>();

                cfg.CreateMap<DriverGetDto, DriverViewModel>();
                cfg.CreateMap<DriverViewModel, DriverGetDto>();
                cfg.CreateMap<DriverViewModel, DriverPostDto>();

                cfg.CreateMap<ModelGetDto, ModelViewModel>();
                cfg.CreateMap<ModelPostDto, ModelViewModel>();
                cfg.CreateMap<ModelViewModel, ModelPostDto>();

                cfg.CreateMap<TransportGetDto, TransportViewModel>();
                cfg.CreateMap<TransportPostDto, TransportViewModel>();
                cfg.CreateMap<TransportViewModel, TransportPostDto>();

                cfg.CreateMap<TransportTypesGetDto, TransportTypesViewModel>();

                cfg.CreateMap<TripGetDto, TripViewModel>();
                cfg.CreateMap<TripPostDto, TripViewModel>();
                cfg.CreateMap<TripViewModel, TripPostDto>();

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