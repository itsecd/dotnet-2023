using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CarSharingClient.ViewModels;
using CarSharingClient.Views;
using Splat;

namespace CarSharingClient;
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
                cfg.CreateMap<CarGetDto, CarViewModel>();
                cfg.CreateMap<CarViewModel, CarPostDto>();
                cfg.CreateMap<CarPostDto, CarViewModel>();
                cfg.CreateMap<CarViewModel, CarGetDto>();

                cfg.CreateMap<RentalPointViewModel, RentalPointPostDto>();
                cfg.CreateMap<RentalPointPostDto, RentalPointViewModel>();

                cfg.CreateMap<ClientGetDto, ClientViewModel>();
                cfg.CreateMap<ClientViewModel, ClientPostDto>();
                cfg.CreateMap<ClientPostDto, ClientViewModel>();
                cfg.CreateMap<ClientViewModel, ClientGetDto>();

                cfg.CreateMap<RentedCarGetDto, RentedCarViewModel>();
                cfg.CreateMap<RentedCarViewModel, RentedCarPostDto>();
                cfg.CreateMap<RentedCarPostDto, RentedCarViewModel>();
                cfg.CreateMap<RentedCarViewModel, RentedCarGetDto>();

                cfg.CreateMap<QueryViewModel, TopCarsGetDto>();
                cfg.CreateMap<TopCarsGetDto, QueryViewModel>();
            }
            );
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