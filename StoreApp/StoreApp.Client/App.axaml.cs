using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;
using StoreApp.Client.ViewModels;
using StoreApp.Client.Views;

namespace StoreApp.Client;
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
                cfg.CreateMap<ProductGetDto, ProductViewModel>();
                cfg.CreateMap<ProductPostDto, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, ProductGetDto>();
                cfg.CreateMap<ProductViewModel, ProductPostDto>();

                cfg.CreateMap<CustomerGetDto, CustomerViewModel>();
                cfg.CreateMap<CustomerPostDto, CustomerViewModel>();
                cfg.CreateMap<CustomerViewModel, CustomerGetDto>();
                cfg.CreateMap<CustomerViewModel, CustomerPostDto>();

                cfg.CreateMap<StoreGetDto, StoreViewModel>();
                cfg.CreateMap<StorePostDto, StoreViewModel>();
                cfg.CreateMap<StoreViewModel, StoreGetDto>();
                cfg.CreateMap<StoreViewModel, StorePostDto>();
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