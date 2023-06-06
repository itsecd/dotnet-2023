using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RealtorClient.ViewModels;
using RealtorClient.Views;
using Splat;

namespace RealtorClient;

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
                cfg.CreateMap<HouseGetDto, HouseViewModel>();
                cfg.CreateMap<HousePostDto, HouseViewModel>();
                cfg.CreateMap<HouseViewModel, HouseGetDto>();
                cfg.CreateMap<HouseViewModel, HousePostDto>();

                cfg.CreateMap<ApplicationGetDto, ApplicationViewModel>();
                cfg.CreateMap<ApplicationPostDto, ApplicationViewModel>();
                cfg.CreateMap<ApplicationViewModel, ApplicationGetDto>();
                cfg.CreateMap<ApplicationViewModel, ApplicationPostDto>();

                cfg.CreateMap<ClientGetDto, ClientViewModel>();
                cfg.CreateMap<ClientPostDto, ClientViewModel>();
                cfg.CreateMap<ClientViewModel, ClientGetDto>();
                cfg.CreateMap<ClientViewModel, ClientPostDto>();

                cfg.CreateMap<ApplicationHasHouseDto, ApplicationHasHouseViewModel>();
                cfg.CreateMap<ApplicationHasHouseViewModel, ApplicationHasHouseDto>();
                cfg.CreateMap<ClientGetDto,BuyersViewModel>();
                cfg.CreateMap<BuyersViewModel, ClientGetDto>();
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