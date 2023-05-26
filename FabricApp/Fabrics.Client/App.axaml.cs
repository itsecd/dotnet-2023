using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Fabrics.Client.ViewModels;
using Fabrics.Client.Views;
using Splat;

namespace Fabrics.Client;
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
                cfg.CreateMap<FabricGetDto, FabricViewModel>();
                cfg.CreateMap<FabricViewModel, FabricPostDto>();
                cfg.CreateMap<ProviderGetDto, ProviderViewModel>();
                cfg.CreateMap<ProviderViewModel, ProviderPostDto>();
                cfg.CreateMap<ShipmentGetDto, ShipmentViewModel>();
                cfg.CreateMap<ShipmentViewModel, ShipmentPostDto>();
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