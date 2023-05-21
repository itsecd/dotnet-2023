using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;
using Warehouse.Client.ViewModels;
using Warehouse.Client.Views;

namespace Warehouse.Client;
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
                cfg.CreateMap<ProductsGetDto, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, ProductsGetDto>();
                cfg.CreateMap<ProductViewModel, ProductsPostDto>();
                cfg.CreateMap<ProductsPostDto, ProductViewModel>();

                cfg.CreateMap<SuppliesGetDto, SupplyViewModel>();
                cfg.CreateMap<SupplyViewModel, SuppliesGetDto>();
                cfg.CreateMap<SupplyViewModel, SuppliesPostDto>();
                cfg.CreateMap<SuppliesPostDto, SupplyViewModel>();

                cfg.CreateMap<WarehouseCellsDto, WarehouseCellViewModel>();
                cfg.CreateMap<WarehouseCellViewModel, WarehouseCellsDto>();
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