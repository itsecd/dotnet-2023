using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ShopsClient.ViewModels;
using ShopsClient.Views;
using Splat;


namespace ShopsClient;
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

                cfg.CreateMap<ProductGroupGetDto, ProductGroupViewModel>().ReverseMap();
                cfg.CreateMap<ProductGroupPostDto, ProductGroupViewModel>().ReverseMap();

                cfg.CreateMap<ProductQuantityGetDto, ProductQuantityViewModel>().ReverseMap();
                cfg.CreateMap<ProductQuantityPostDto, ProductQuantityViewModel>().ReverseMap();

                cfg.CreateMap<PurchaseRecordGetDto, PurchaseRecordViewModel>().ReverseMap();
                cfg.CreateMap<PurchaseRecordPostDto, PurchaseRecordViewModel>().ReverseMap();

                cfg.CreateMap<ShopGetDto, ShopViewModel>().ReverseMap();
                cfg.CreateMap<ShopPostDto, ShopViewModel>().ReverseMap();

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