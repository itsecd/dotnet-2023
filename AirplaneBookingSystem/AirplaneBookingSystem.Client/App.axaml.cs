using AirplaneBookingSystem.Client.ViewModels;
using AirplaneBookingSystem.Client.Views;
using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;

namespace AirplaneBookingSystem.Client;
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
                cfg.CreateMap<AirplaneGetDto, AirplaneViewModel>();
                cfg.CreateMap<AirplaneViewModel, AirplanePostDto>();

                cfg.CreateMap<FlightGetDto, FlightViewModel>();
                cfg.CreateMap<FlightViewModel, FlightPostDto>();

                cfg.CreateMap<TicketGetDto, TicketViewModel>();
                cfg.CreateMap<TicketViewModel, TicketPostDto>();

                cfg.CreateMap<ClientGetDto, ClientViewModel>();
                cfg.CreateMap<ClientViewModel, ClientPostDto>();
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