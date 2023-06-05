using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MusicMarket.Client.ViewModels;
using MusicMarket.Client.Views;
using MusicMarketClient;
using Splat;
using System.Net.Http;

namespace MusicMarket.Client;
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
                cfg.CreateMap<CustomerGetDto, CustomerViewModel>().ReverseMap();
                cfg.CreateMap<CustomerPostDto, CustomerViewModel>().ReverseMap();

                cfg.CreateMap<ProductGetDto, ProductViewModel>().ReverseMap();
                cfg.CreateMap<ProductPostDto, ProductViewModel>().ReverseMap();

                cfg.CreateMap<SellerGetDto, SellerViewModel>().ReverseMap();
                cfg.CreateMap<SellerPostDto, SellerViewModel>().ReverseMap();

                cfg.CreateMap<PurchaseGetDto, PurchaseViewModel>().ReverseMap();
                cfg.CreateMap<PurchasePostDto, PurchaseViewModel>().ReverseMap();

              
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