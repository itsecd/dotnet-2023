using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EnterpriseWarehouseClient.ViewModels;
using EnterpriseWarehouseClient.Views;
using Splat;

namespace EnterpriseWarehouseClient;
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
                cfg.CreateMap<ProductViewModel, ProductPostDto>();
                cfg.CreateMap<StorageCellGetDto, StorageCellViewModel>();
                cfg.CreateMap<StorageCellViewModel, StorageCellPostDto>();
                cfg.CreateMap<InvoiceGetDto, InvoiceViewModel>();
                cfg.CreateMap<InvoiceViewModel, InvoicePostDto>();
                cfg.CreateMap<InvoiceContentGetDto, InvoiceContentViewModel>();
                cfg.CreateMap<InvoiceContentViewModel, InvoiceContentPostDto>();
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