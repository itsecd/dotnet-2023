using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using PonrfClient.ViewModels;
using PonrfClient.Views;
using Splat;

namespace PonrfClient;
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
                //cfg.CreateMap<AuctionGetDto, AuctionViewModel>().ReverseMap();
                //cfg.CreateMap<BuildingGetDto, BuildingViewModel>().ReverseMap();
                //cfg.CreateMap<CustomerGetDto, CustomerViewModel>().ReverseMap();
                cfg.CreateMap<PrivatizedBuildingGetDto, PrivatizedBuildingViewModel>().ReverseMap();
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