using Airline.Client.ViewModels;
using Airline.Client.Views;
using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;

namespace Airline.Client;
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
                cfg.CreateMap<AirplaneViewModel, AirplaneGetDto>();
                cfg.CreateMap<AirplaneViewModel, AirplanePostDto>();
                cfg.CreateMap<AirplanePostDto, AirplaneViewModel>();

                cfg.CreateMap<PassengerGetDto, PassengerViewModel>();
                cfg.CreateMap<PassengerViewModel, PassengerGetDto>();
                cfg.CreateMap<PassengerViewModel, PassengerPostDto>();
                cfg.CreateMap<PassengerPostDto, PassengerViewModel>();

                cfg.CreateMap<TicketGetDto, TicketViewModel>();
                cfg.CreateMap<TicketViewModel, TicketGetDto>();
                cfg.CreateMap<TicketViewModel, TicketPostDto>();
                cfg.CreateMap<TicketPostDto, TicketViewModel>();
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