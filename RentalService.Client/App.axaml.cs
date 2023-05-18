using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RentalService.Client.ViewModels;
using RentalService.Client.Views;
using Splat;

namespace RentalService.Client;

public class App : Application
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
                cfg.CreateMap<ClientGetDto, ClientViewModel>();
                cfg.CreateMap<ClientViewModel, ClientGetDto>();
                cfg.CreateMap<ClientPostDto, ClientViewModel>();
                cfg.CreateMap<ClientViewModel, ClientPostDto>();
                
                cfg.CreateMap<IssuedCar, IssuedCarViewModel>();
                cfg.CreateMap<IssuedCarViewModel, IssuedCar>();
                cfg.CreateMap<IssuedCarPostDto, IssuedCarViewModel>();
                cfg.CreateMap<IssuedCarViewModel, IssuedCarPostDto>();
                
                cfg.CreateMap<RefundInformation, RefundInformationViewModel>();
                cfg.CreateMap<RefundInformationViewModel, RefundInformation>();
                cfg.CreateMap<RefundInformationPostDto, RefundInformationViewModel>();
                cfg.CreateMap<RefundInformationViewModel, RefundInformationPostDto>();
                
                cfg.CreateMap<RentalInformation, RentalInformationViewModel>();
                cfg.CreateMap<RentalInformationViewModel, RentalInformation>();
                cfg.CreateMap<RentalInformationPostDto, RentalInformationViewModel>();
                cfg.CreateMap<RentalInformationViewModel, RentalInformationPostDto>();
                
                cfg.CreateMap<RentalPointGetDto, RentalPointViewModel>();
                cfg.CreateMap<RentalPointViewModel, RentalPointGetDto>();
                cfg.CreateMap<RentalPointPostDto, RentalPointViewModel>();
                cfg.CreateMap<RentalPointViewModel, RentalPointPostDto>();
                
                cfg.CreateMap<VehicleModelGetDto, VehicleModelViewModel>();
                cfg.CreateMap<VehicleModelViewModel, VehicleModelGetDto>();
                cfg.CreateMap<VehicleModelPostDto, VehicleModelViewModel>();
                cfg.CreateMap<VehicleModelViewModel, VehicleModelPostDto>();
                
                cfg.CreateMap<VehicleGetDto, VehicleViewModel>();
                cfg.CreateMap<VehicleViewModel, VehicleGetDto>();
                cfg.CreateMap<VehiclePostDto, VehicleViewModel>();
                cfg.CreateMap<VehicleViewModel, VehiclePostDto>();

                
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