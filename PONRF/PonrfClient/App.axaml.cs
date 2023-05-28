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
                cfg.CreateMap<PrivatizedBuildingGetDto, PrivatizedBuildingViewModel>();
                cfg.CreateMap<PrivatizedBuildingViewModel, PrivatizedBuildingPostDto>();
                cfg.CreateMap<AuctionGetDto, AuctionViewModel>();
                cfg.CreateMap<AuctionViewModel, AuctionPostDto>();
                cfg.CreateMap<BuildingGetDto, BuildingViewModel>();
                cfg.CreateMap<BuildingViewModel, BuildingPostDto>();
                cfg.CreateMap<CustomerGetDto, CustomerViewModel>();
                cfg.CreateMap<CustomerViewModel, CustomerPostDto>();
                cfg.CreateMap<AuctionsWithoutFullSalesViewModel, AuctionGetDto>().ReverseMap();
                cfg.CreateMap<TopCustomerViewModel, TopCustomerGetDto>().ReverseMap();
                cfg.CreateMap<TopAuctionViewModel, TopAuctionGetDto>().ReverseMap();
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