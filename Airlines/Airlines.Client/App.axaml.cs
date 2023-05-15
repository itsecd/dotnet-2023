using Airlines.Client.ViewModels;
using Airlines.Client.Views;
using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;

namespace Airlines.Client;
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
                cfg.CreateMap<PassengerGetDto, PassengerViewModel>();
                cfg.CreateMap<PassengerViewModel, PassengerPostDto>();
                cfg.CreateMap<TicketGetDto, TicketViewModel>();
                cfg.CreateMap<TicketViewModel, TicketPostDto>();
                cfg.CreateMap<AirplaneGetDto, AirplaneViewModel>();
                cfg.CreateMap<AirplaneViewModel, AirplanePostDto>();
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