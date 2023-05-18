using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TaxiDepo.Client.ViewModels;
using TaxiDepo.Client.Views;
using AutoMapper;
using Splat;

namespace TaxiDepo.Client;

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
            var config = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<CarDto, CarViewModel>().ReverseMap();

                configuration.CreateMap<DriverDto, DriverViewModel>().ReverseMap();

                configuration.CreateMap<RideDto, RideViewModel>().ReverseMap();

                configuration.CreateMap<UserDto, UserViewModel>().ReverseMap();
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
